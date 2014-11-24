namespace Gengine.Events
{
    public class BaseEvent : IEvent {
        public string GetName() { return GetType().Name; }
    }
}
