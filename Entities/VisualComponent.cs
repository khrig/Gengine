using Microsoft.Xna.Framework.Graphics;

namespace Gengine.Entities {
    public class VisualComponent : EntityComponent {
        public Texture2D Texture { get; private set; }

        public VisualComponent(Texture2D texture) {
            Texture = texture;
        }
    }
}
