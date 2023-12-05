using System.Windows;
using System.Windows.Controls;
using UI.Helpers;
using UI.ViewModels;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for BuildingView.xaml
    /// </summary>
    public partial class BuildingView : UserControl
    {
        public BuildingView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = new BuildingViewModel(mainViewModel);
            ViewModel.RootViewModel.FocusEvent.SubscribeOnBuilding(FocusHandler);
        }

        public BuildingViewModel ViewModel
        {
            get
            {
                return (BuildingViewModel)DataContext;
            }

            set
            {
                DataContext = value;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (ViewModel.RootViewModel.CurrentFocusTextBox)
            {
                case nameof(ViewModel.FloorCount):
                    FloorCountTextBox.Focus();
                    break;
                case nameof(ViewModel.Address):
                    AddressTextBox.Focus();
                    break;
            }
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            TextBoxHelper.HandleValidation(sender, ViewModel, e);
        }

        private void FocusHandler(string propertyName, bool isControlUpdate)
        {
            switch (propertyName)
            {
                case nameof(ViewModel.FloorCount):
                    ViewModel.RootViewModel.CurrentFocusTextBox = nameof(ViewModel.FloorCount);
                    break;
                case nameof(ViewModel.Address):
                    ViewModel.RootViewModel.CurrentFocusTextBox = nameof(ViewModel.Address);
                    break;
            }

            if (!isControlUpdate)
            {
                switch (propertyName)
                {
                    case nameof(ViewModel.FloorCount):
                        FloorCountTextBox.Focus();
                        break;
                    case nameof(ViewModel.Address):
                        AddressTextBox.Focus();
                        break;
                }
            }
        }
    }
}
