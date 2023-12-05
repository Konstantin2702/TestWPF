namespace UI.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel(MainViewModel mainViewModel)
        {
            Guid = Guid.NewGuid();
            RootViewModel = mainViewModel;
        }
        public Guid Guid { get; set; }

        public MainViewModel RootViewModel {get; set;}
    }
}
