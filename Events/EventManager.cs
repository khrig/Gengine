using System.Collections.Generic;

namespace Gengine.Events {
    public sealed class EventManager {
        private static readonly EventManager _instance = new EventManager();

        private EventManager(){
            _eventQueue = new Queue<IEvent>();
            _eventListeners = new Dictionary<string, IList<IEventListener>>();
        }

        public static EventManager Instance { get { return _instance; } }
        private readonly Queue<IEvent> _eventQueue; 
        private readonly Dictionary<string, IList<IEventListener>> _eventListeners;

        public void QueueEvent(IEvent @event) {
            _eventQueue.Enqueue(@event);
        }

        public void TriggerEvent(IEvent @event) {
            if (_eventListeners.ContainsKey(@event.GetName())) {
                foreach (IEventListener eventListener in _eventListeners[@event.GetName()]) {
                    eventListener.HandleEvent(@event);
                }
            }
        }

        public void Attach(string eventName, IEventListener listener) {
            if(!_eventListeners.ContainsKey(eventName))
                _eventListeners.Add(eventName, new List<IEventListener> { listener });
            else {
                _eventListeners[eventName].Add(listener);
            }
        }

        public void Detach(string eventName, IEventListener listener) {
            if (!_eventListeners.ContainsKey(eventName))
                return;

            _eventListeners[eventName].Remove(listener);
        }

        public void DetachFromAll(IEventListener listener) {
            foreach (var key in _eventListeners.Keys) {
                _eventListeners[key].Remove(listener);
            }
        }

        public void DetachAll() {
            foreach (var key in _eventListeners.Keys) {
                _eventListeners.Remove(key);
            }
        }

        public void Update() {
            while (_eventQueue.Count != 0) {
                IEvent @event = _eventQueue.Dequeue();
                TriggerEvent(@event);
            }
        }
    }
}
