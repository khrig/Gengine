﻿using Gengine.Commands;
using Gengine.Entities;
using System.Collections.Generic;
using Gengine.Rendering;
using Microsoft.Xna.Framework;

namespace Gengine.State {
    public abstract class State {
        public StateManager StateManager { get; set; }
        public IWorld World { get; set; }

        // the bool return value marks if its fall through or not
        public abstract bool Update(float deltaTime);
        public abstract void Init();
        public abstract void Unload();
        public abstract void HandleCommands(CommandQueue commandQueue);
        public abstract IEnumerable<IRenderable> GetRenderTargets();
        public abstract IEnumerable<IRenderableText> GetTextRenderTargets();

        protected void SetTransformation(Matrix? transformationMatrix) {
            StateManager.SetTransformationMatrix(transformationMatrix);
        }

        protected void SetColor(Color color){
            StateManager.SetColor(color);
        }
    }
}