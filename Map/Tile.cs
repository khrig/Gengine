using Gengine.Entities;
using Microsoft.Xna.Framework;

namespace Gengine.Map {
    public class Tile : IRenderable, ICollidable {
        private readonly Vector2 _pixelPosition;
        public string TextureName { get; private set; }
        public Vector2 Position { get; set; }
        public Rectangle SourceRectangle { get; private set; }
        public Rectangle BoundingBox { get; private set; }
        public bool IsSolid { get; set; }

        public string Identifier {
            get { return "ground"; }
        }

        public Vector2 RenderPosition {
            get { return new Vector2(_pixelPosition.X, _pixelPosition.Y); }
        }

        public Tile(string textureName, Vector2 position, Rectangle sourceRectangle, bool solid = true){
            _pixelPosition = position;
            TextureName = textureName;
            Position = position;
            SourceRectangle = sourceRectangle;
            BoundingBox = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width, sourceRectangle.Height);
            IsSolid = solid;
        }

        public Tile(string textureName, Vector2 gridPosition, Vector2 pixelPosition, Rectangle sourceRectangle, bool solid = true) {
            _pixelPosition = pixelPosition;
            TextureName = textureName;
            Position = gridPosition;
            SourceRectangle = sourceRectangle;
            BoundingBox = new Rectangle((int)pixelPosition.X, (int)pixelPosition.Y, sourceRectangle.Width, sourceRectangle.Height);
            IsSolid = solid;
        }

        public void Collide(ICollidable target) {}
    }
}
