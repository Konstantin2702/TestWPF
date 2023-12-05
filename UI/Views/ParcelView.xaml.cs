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
        }

        public BaseViewModel ViewModel
        {
            get
            {
                return (BaseViewModel)DataContext;
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
    }
}
