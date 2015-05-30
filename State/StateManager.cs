using System;
using System.Linq;
using System.Collections.Generic;
using Gengine.Commands;
using Microsoft.Xna.Framework.Graphics;
using Gengine.Entities;

namespace Gengine.State {
    public class StateManager {
        private readonly Stack<State> stateStack;
        private readonly Queue<Action> stateQueue;
        private readonly Dictionary<string, State> availableStates = new Dictionary<string, State>();

        public StateManager() {
            stateStack = new Stack<State>();
            stateQueue = new Queue<Action>();
            _renderTargets = new List<IRenderable>();
        }

        public void Add(string stateId, State state) {
            InitState(state);
            availableStates.Add(stateId, state);
        }

        public void PopState() {
            stateQueue.Enqueue(() => stateStack.Pop());
        }

        public void PushState(string stateId) {
            if (availableStates.ContainsKey(stateId))
                stateQueue.Enqueue(() => {
                    availableStates[stateId].Init();
                    stateStack.Push(availableStates[stateId]);
                });
        }

        public void HandleCommands(CommandQueue commands) {
            if (stateStack.Count == 0)
                return;

            var currentState = stateStack.Peek();
            currentState.HandleCommands(commands);
        }

        public void ChangeState() {
            while (stateQueue.Count != 0) {
                var action = stateQueue.Dequeue();
                action();
            }
        }

        public bool IsEmpty() {
            return stateStack.Count == 0;
        }

        public void Update(float deltaTime) {
            foreach (var state in stateStack) {
                if (!state.Update(deltaTime))
                    return;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (var state in stateStack) {
                if (!state.Draw(spriteBatch))
                    return;
            }
        }

        private void InitState(State state) {
            state.StateManager = this;
            state.Init();
        }

        private List<IRenderable> _renderTargets;
        public IEnumerable<IRenderable> GetRenderTargets() {
            _renderTargets.Clear();
            foreach (var state in stateStack) {
                _renderTargets.AddRange(state.GetRenderTargets());
            }
            return _renderTargets;
        }
    }
}
