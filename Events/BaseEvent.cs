namespace Gengine.Events
{
    public class BaseEvent : IEvent {
        public string GetName() { return GetType().Name; }
        public object Data { get; private set; }
    }
}
