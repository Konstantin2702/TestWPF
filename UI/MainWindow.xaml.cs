using System.Windows;
using System.Windows.Controls;
using UI.Events;
using UI.Models;
using UI.ViewModels;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        public MainViewModel ViewModel
        {
            get
            {
                return (MainViewModel)DataContext;
            }

            set
            {
                DataContext = value;
            }
        }

        private void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var listBox = (ListBox)sender;

            if(listBox.SelectedItem == null)
            {
                return;
            }

            var selectedItem = (ErrorInfo)listBox.SelectedItem;

            ViewModel.HandleFocusEvent(selectedItem.ModelGuid, selectedItem.PropertyName);
        }
    }
}