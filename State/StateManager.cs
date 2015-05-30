using System;
using System.Collections.Generic;
using Gengine.Commands;
using Gengine.Entities;

namespace Gengine.State {
    public class StateManager {
        private readonly Stack<State> _stateStack;
        private readonly Queue<Action> _stateQueue;
        private readonly Dictionary<string, State> _availableStates = new Dictionary<string, State>();

        public StateManager() {
            _stateStack = new Stack<State>();
            _stateQueue = new Queue<Action>();
            _renderTargets = new List<IRenderable>();
        }

        public void Add(string stateId, State state) {
            InitState(state);
            _availableStates.Add(stateId, state);
        }

        public void PopState() {
            _stateQueue.Enqueue(() => _stateStack.Pop());
        }

        public void PushState(string stateId) {
            if (_availableStates.ContainsKey(stateId))
                _stateQueue.Enqueue(() => {
                    _availableStates[stateId].Init();
                    _stateStack.Push(_availableStates[stateId]);
                });
        }

        public void HandleCommands(CommandQueue commands) {
            if (_stateStack.Count == 0)
                return;

            var currentState = _stateStack.Peek();
            currentState.HandleCommands(commands);
        }

        public void ChangeState() {
            while (_stateQueue.Count != 0) {
                var action = _stateQueue.Dequeue();
                action();
            }
        }

        public bool IsEmpty() {
            return _stateStack.Count == 0;
        }

        public void Update(float deltaTime) {
            foreach (var state in _stateStack) {
                if (!state.Update(deltaTime))
                    return;
            }
        }
        
        private void InitState(State state) {
            state.StateManager = this;
            state.Init();
        }

        private readonly List<IRenderable> _renderTargets;
        public IEnumerable<IRenderable> GetRenderTargets() {
            _renderTargets.Clear();
            foreach (var state in _stateStack) {
                _renderTargets.AddRange(state.GetRenderTargets());
            }
            return _renderTargets;
        }
    }
}
