using Gengine.Commands;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine.State {
    public abstract class State {
        public StateManager StateManager { get; set; }

        // the bool return value marks if its fall through or not
        public abstract bool Update(float deltaTime);
        public abstract bool Draw(SpriteBatch spriteBatch);
        public abstract void HandleCommands(CommandQueue commandQueue);
        public abstract void Init();
    }
}