using System.Windows.Controls;

namespace UI.Models
{
    public class ControlInfo
    {
        public ControlInfo(Guid guid, UserControl control, string viewModelName) 
        {
            Guid = guid;
            Control = control;
            ViewModelName = viewModelName;
        }

        public Guid Guid { get; set; }

        public string ViewModelName { get; set; }

        public UserControl Control { get; set; }
    }
}
