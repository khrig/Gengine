using System;
using System.Collections.Generic;

namespace Gengine.State {
    public class GameStateManager {
        public static GameStateManager Instance { get { return _instance; } }
        private static readonly GameStateManager _instance = new GameStateManager();
        private readonly Dictionary<string, object> _stateObjects;
        private GameStateManager(){
            _stateObjects = new Dictionary<string, object>();
        }

        protected T GetValue<T>(string id) {
            object data;
            if (_stateObjects.TryGetValue(id, out data)) {
                return (T)data;
            }
            throw new Exception("Game state value with id not found: " + id);
        }

        protected void SetValue<T>(string id, T value) {
            if (!_stateObjects.ContainsKey(id))
                _stateObjects.Add(id, value);
            else 
                _stateObjects[id] = value;
        }
    }
}
