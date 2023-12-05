using System.Windows.Controls;

namespace UI.Models
{
    public class ControlInfo
    {
        public ControlInfo(Guid guid, UserControl control) 
        {
            Guid = guid;
            Control = control;
        }

        public Guid Guid { get; set; }

        public UserControl Control { get; set; }
    }
}
