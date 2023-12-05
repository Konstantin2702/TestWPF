using System.Windows;
using System.Windows.Controls;
using UI.Helpers;
using UI.ViewModels;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for ParcelView.xaml
    /// </summary>
    public partial class ParcelView : UserControl
    {
        public ParcelView(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = new ParcelViewModel(viewModel);
            ViewModel.RootViewModel.FocusEvent.SubscribeOnParcel(FocusHandler);
        }

        public ParcelViewModel ViewModel
        {
            get
            {
                return (ParcelViewModel)DataContext;
            }

            set
            {
                DataContext = value;
            }
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            TextBoxHelper.HandleValidation(sender, ViewModel, e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (ViewModel.RootViewModel.CurrentFocusTextBox)
            {
                case nameof(ViewModel.Location):
                    LocationTextBox.Focus();
                    break;
                case nameof(ViewModel.Number):
                    NumberTextBox.Focus();
                    break;
            }
        }

        private void FocusHandler(string propertyName, bool isControlUpdated)
        {
            switch (propertyName)
            {
                case nameof(ViewModel.Location):
                    ViewModel.RootViewModel.CurrentFocusTextBox = nameof(ViewModel.Location);
                    break;
                case nameof(ViewModel.Number):
                    ViewModel.RootViewModel.CurrentFocusTextBox = nameof(ViewModel.Number);
                    break;
            }

            if (!isControlUpdated)
            {
                switch (propertyName)
                {
                    case nameof(ViewModel.Location):
                        LocationTextBox.Focus();
                        break;
                    case nameof(ViewModel.Number):
                        NumberTextBox.Focus();
                        break;
                }
            }
        }
    }
}
