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
