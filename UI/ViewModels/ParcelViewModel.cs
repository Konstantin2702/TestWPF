using System.ComponentModel;

namespace UI.ViewModels
{
    public class ParcelViewModel : BaseViewModel, IDataErrorInfo
    {
        public ParcelViewModel(MainViewModel viewModel) : base(viewModel) { }

        public string Number { get; set; }

        public string Location { get; set; }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(Number):
                        if (string.IsNullOrEmpty(Number))
                        {
                            error = "Заполните поле";
                        }
                        break;

                    case nameof(Location):
                        if (string.IsNullOrEmpty(Location))
                        {
                            error = "Заполните поле";
                        }
                        break;
                }

                return error;
            }
        }
    }
}
