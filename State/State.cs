using Gengine.Commands;
using Gengine.Rendering;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Gengine.State {
    public abstract class State {
        public StateManager StateManager { get; set; }
        public IWorld World { get; set; }

        internal bool Initialized { get; set; }

        // the bool return value marks if its fall through or not
        public abstract bool Update(float deltaTime);
        public abstract void Init();
        public abstract void Unload();
        protected abstract bool HandleCommand(ICommand command);
        public abstract IEnumerable<IRenderable> GetRenderTargets();
        public abstract IEnumerable<IRenderableText> GetTextRenderTargets();

        internal void HandleCommands(CommandQueue commandQueue) {
            while (commandQueue.HasCommands()) {
                var command = commandQueue.GetNext();
                if (HandleCommand(command)) return;
            }
        }

        protected void SetTransformation(Matrix? transformationMatrix) {
            StateManager.SetTransformationMatrix(transformationMatrix);
        }

        protected void SetColor(Color color){
            StateManager.SetColor(color);
        }
    }
}