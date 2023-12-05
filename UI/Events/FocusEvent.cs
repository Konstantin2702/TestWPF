using UI.ViewModels;

namespace UI.Events
{
    public class FocusEvent
    {
        public delegate void EventHandler(string propertyName, bool isWindowUpdated);

        public event EventHandler BuildingEvent;

        public event EventHandler ParcelEvent;

        public void SubscribeOnBuilding(EventHandler handler)
        {
            BuildingEvent += handler;
        }

        public void SubscribeOnParcel(EventHandler handler) 
        {
            ParcelEvent += handler;
        }

        public void Invoke(string propertyName, string viewModelName, bool isWindowUpdated)
        {
            switch (viewModelName)
            {
                case nameof(BuildingViewModel):
                    BuildingEvent?.Invoke(propertyName, isWindowUpdated);
                    break;
                case nameof(ParcelViewModel):
                    ParcelEvent?.Invoke(propertyName, isWindowUpdated);
                    break;
            }
        }
    }
}
