using System;
using System.Collections.Generic;
using Gengine.Commands;
using Gengine.Entities;
using Microsoft.Xna.Framework;

namespace Gengine.State {
    public class StateManager {
        private readonly Stack<State> _stateStack;
        private readonly Queue<Action> _stateQueue;
        private readonly Dictionary<string, State> _availableStates = new Dictionary<string, State>();

        private readonly List<IRenderable> _renderTargets;
        private Matrix? _transformationMatrix;

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
            _stateQueue.Enqueue(() =>
            {
                var state = _stateStack.Pop();
                state.Unload();
            });
        }

        public void ClearStates() {
            _stateQueue.Enqueue(() => {
                while (_stateStack.Count != 0){
                    var state = _stateStack.Pop();
                    state.Unload();
                }
            });
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
        }

        public IEnumerable<IRenderable> GetRenderTargets() {
            return _renderTargets;
        }

        public void AddRenderTarget(IRenderable renderTarget) {
            _renderTargets.Add(renderTarget);
        }

        public void AddRenderTarget(IEnumerable<IRenderable> renderTargets) {
            _renderTargets.AddRange(renderTargets);
        }

        public void UnregisterRenderTarget(IRenderable renderTarget) {
            _renderTargets.Remove(renderTarget);
        }

        public void UnregisterRenderTarget(IEnumerable<IRenderable> renderTargets) {
            foreach (var renderable in renderTargets) {
                UnregisterRenderTarget(renderable);
            }
        }

        public Matrix? GetRenderTransformation() {
            return _transformationMatrix;
        }

        public void SetTransformationMatrix(Matrix? transformationMatrix) {
            _transformationMatrix = transformationMatrix;
        }
    }
}
