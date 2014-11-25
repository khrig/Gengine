using Gengine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine {
    public class Tile : IRenderable {
        public Tile(Texture2D texture, Vector2 position, Rectangle sourceRectangle) {
            Texture = texture;
            Position = position;
            SourceRectangle = sourceRectangle;
        }

        public Texture2D Texture { get; private set; }
        public Vector2 Position { get; private set; }
        public Rectangle SourceRectangle { get; private set; }
    }
}
