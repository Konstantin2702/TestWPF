using System.ComponentModel;
using UI.Events;

namespace UI.ViewModels
{
    public class BuildingViewModel : BaseViewModel, IDataErrorInfo, INotifyPropertyChanged
    {
        public BuildingViewModel(MainViewModel mainViewModel) : base(mainViewModel) 
        {
        }

        

        public int FloorCount { get; set; }

        public bool IsFloorCountFocused { get; set; } = false;

        public string Address { get; set; }

        public bool IsLiving { get; set; }

        public string Error => null;

        public string this[string columnName]
        {
            get 
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(FloorCount):
                        if (FloorCount <= 0)
                        {
                            error = "Неверное количество этажей";
                        }
                        break;

                    case nameof(Address):
                        if (string.IsNullOrEmpty(Address)) 
                        {
                            error = "Заполните поле";
                        }
                        break;
                }

                return error;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}