using System.Collections.Generic;
using System.Linq;

namespace Gengine.Events {
    public sealed class EventManager {
        private static readonly EventManager _instance = new EventManager();
        private EventManager() { }
        public static EventManager Instance { get { return _instance; } }
        private readonly Queue<IEvent> _eventQueue = new Queue<IEvent>(); 
        private readonly Dictionary<string, IList<IEventListener>> _eventListeners = new Dictionary<string, IList<IEventListener>>();

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

        public void DetachAll() {
            IEnumerable<string> keys = _eventListeners.Keys.ToList();
            foreach (var key in keys) {
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
