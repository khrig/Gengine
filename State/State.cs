using Gengine.Commands;
using Gengine.Entities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Gengine.State {
    public abstract class State {
        public StateManager StateManager { get; set; }
        protected IWorld World { get; set; }

        protected State(IWorld world) {
            World = world;
        }

        protected void RegisterRenderTarget(IRenderable renderTarget) {
            StateManager.AddRenderTarget(renderTarget);
        }

        protected void RegisterRenderTarget(IEnumerable<IRenderable> renderTargets) {
            StateManager.AddRenderTarget(renderTargets);
        }

        protected void UnregisterRenderTarget(IRenderable renderTarget) {
            StateManager.UnregisterRenderTarget(renderTarget);
        }

        protected void UnregisterRenderTarget(IEnumerable<IRenderable> renderTargets) {
            StateManager.UnregisterRenderTarget(renderTargets);
        }

        protected void SetTransformation(Matrix transformationMatrix) {
            StateManager.SetTransformationMatrix(transformationMatrix);
        }

        // the bool return value marks if its fall through or not
        public abstract bool Update(float deltaTime);
        public abstract void HandleCommands(CommandQueue commandQueue);
        public abstract void Init();
        public abstract void Unload();
    }
}