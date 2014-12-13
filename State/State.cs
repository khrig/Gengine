using Gengine.Commands;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine.State {
    public abstract class State {
        public StateManager StateManager { get; set; }
        protected IWorld World { get; set; }

        protected State(IWorld world) {
            World = world;
        }

        // the bool return value marks if its fall through or not
        public abstract bool Update(float deltaTime);
        public abstract bool Draw(SpriteBatch spriteBatch);
        public abstract void HandleCommands(CommandQueue commandQueue);
        public abstract void Init();
    }
}