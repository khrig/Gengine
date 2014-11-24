using System.Collections.Generic;
using System.Linq;

namespace Gengine.Events {
    public sealed class EventManager {
        private static readonly EventManager instance = new EventManager();
        private EventManager() { }
        public static EventManager Instance { get { return instance; } }
        private readonly Queue<IEvent> eventQueue = new Queue<IEvent>(); 
        private readonly Dictionary<string, IList<IEventListener>> eventListeners = new Dictionary<string, IList<IEventListener>>();

        public void QueueEvent(IEvent @event) {
            eventQueue.Enqueue(@event);
        }

        public void TriggerEvent(IEvent @event) {
            if (eventListeners.ContainsKey(@event.GetName())) {
                foreach (IEventListener eventListener in eventListeners[@event.GetName()]) {
                    eventListener.HandleEvent(@event);
                }
            }
        }

        public void Attach(string eventName, IEventListener listener) {
            if(!eventListeners.ContainsKey(eventName))
                eventListeners.Add(eventName, new List<IEventListener> { listener });
            else {
                eventListeners[eventName].Add(listener);
            }
        }

        public void Detach(string eventName, IEventListener listener) {
            if (!eventListeners.ContainsKey(eventName))
                return;

            eventListeners[eventName].Remove(listener);
        }

        public void DetachAll() {
            IEnumerable<string> keys = eventListeners.Keys.ToList();
            foreach (var key in keys) {
                eventListeners.Remove(key);
            }
        }

        public void Update() {
            while (eventQueue.Count != 0) {
                IEvent @event = eventQueue.Dequeue();
                TriggerEvent(@event);
            }
        }
    }
}
