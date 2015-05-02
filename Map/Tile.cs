using Gengine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine.Map {
    public class Tile : IRenderable, ICollidable {
        public Tile(Texture2D texture, Vector2 position, Rectangle sourceRectangle) {
            Texture = texture;
            Position = position;
            SourceRectangle = sourceRectangle;
            BoundingBox = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width, sourceRectangle.Height);
        }

        public Texture2D Texture { get; private set; }
        public Vector2 Position { get; private set; }
        public Rectangle SourceRectangle { get; private set; }
        public Rectangle BoundingBox { get; private set; }

        public void Collide(ICollidable target) {}
        public string Identifier {
            get { return "ground"; }
        }
    }
}
