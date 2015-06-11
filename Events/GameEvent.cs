using System;

namespace Gengine.Events {
    public class GameEvent : IEvent {
        public object Data { get; private set; }
        public GameEvent(object data){
            Data = data;
        }

        public string GetName(){
            throw new NotImplementedException();
        }
    }
}
