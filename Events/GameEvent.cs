namespace Gengine.Events {
    public class GameEvent : IEvent {
        public string GetName(){
            return GetType().Name;
        }
    }
}
