namespace Gengine.Events {
    public interface IEventListener {
        void HandleEvent(IEvent @event);
    }
}