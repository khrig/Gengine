﻿using System;
using System.Collections.Generic;

namespace Gengine.State {
    public class StateManager {
        private readonly Stack<State> stateStack;
        private readonly Queue<Action> stateQueue;
        private readonly Dictionary<string, State> availableStates = new Dictionary<string, State>();

        public StateManager() {
            stateStack = new Stack<State>();
            stateQueue = new Queue<Action>();
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

        public void HandleInput(string key) {
            var currentState = stateStack.Peek();
            currentState.HandleInput(key);
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

        public void Draw() {
            foreach (var state in stateStack) {
                if (!state.Draw())
                    return;
            }
        }

        private void InitState(State state) {
            state.StateManager = this;
        }
    }
}
