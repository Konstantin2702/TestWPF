using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using UI.Events;
using UI.Models;
using UI.ViewModels;
using UI.Views;

namespace UI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Controls = new ObservableCollection<ControlInfo>();

            AddBuildingCommand = new RelayCommand(AddBuildingControl);
            AddParcelCommand = new RelayCommand(AddParcelControl);

            Errors = new ObservableCollection<ErrorInfo>();
            FocusEvent = new FocusEvent();
        }

        private ControlInfo _currentControl;

        public FocusEvent FocusEvent;

        public string CurrentFocusTextBox { get; set; }

        public ObservableCollection<ControlInfo> Controls { get; set; }

        public static ObservableCollection<ErrorInfo> Errors { get; set; }

        public ControlInfo CurrentControl
        {
            get
            {
                return _currentControl;
            }
            set
            {
                _currentControl = value;
                OnPropertyChanged(nameof(CurrentControl));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand AddBuildingCommand { get; private set; }

        public RelayCommand AddParcelCommand { get; private set; }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddBuildingControl()
        {
            var view = new BuildingView(this);
            var newBuilding = new ControlInfo(view.ViewModel.Guid, view, nameof(BuildingViewModel));
            Controls.Add(newBuilding);

            if (Controls.Count == 1)
            {
                CurrentControl = newBuilding;
            }
        }

        private void AddParcelControl()
        {
            var view = new ParcelView(this);
            var newParcel = new ControlInfo(view.ViewModel.Guid, view, nameof(ParcelViewModel));
            Controls.Add(newParcel);

            if (Controls.Count == 1)
            {
                CurrentControl = newParcel;
            }
        }

        public void HandleError(Guid viewModelGuid, string propertyName, string errorMessage, ValidationErrorEventAction action)
        {
            if (action == ValidationErrorEventAction.Removed)
            {
                var removedErrorInfo = Errors.FirstOrDefault(e => e.ModelGuid == viewModelGuid && propertyName == e.PropertyName);
                Errors.Remove(removedErrorInfo);
            }
            else
            {
                var errorInfo = new ErrorInfo
                {
                    ErrorMessage = errorMessage,
                    ModelGuid = viewModelGuid,
                    PropertyName = propertyName

                };
                Errors.Add(errorInfo);
            }
        }

        public void ChangeCurrentControl(Guid modelGuid)
        {
            var control = Controls.SingleOrDefault(c => c.Guid == modelGuid);

            if (control != null) 
            {
                CurrentControl = control;
            }
        }

        public void HandleFocusEvent(Guid guid, string propertyName)
        {
            var control = Controls.SingleOrDefault(c => c.Guid == guid);

            if (control != null)
            {
                var isWindowUpdated = control.Guid != CurrentControl?.Guid;
                CurrentControl = control;
                FocusEvent.Invoke(propertyName, control.ViewModelName, isWindowUpdated);
            }
        }
    }
}
