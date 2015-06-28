using Gengine.CollisionDetection;
using Gengine.Entities;
using Gengine.Rendering;
using Microsoft.Xna.Framework;

namespace Gengine.Map {
    public class Tile : IRenderable, ICollidable {
        private readonly Vector2 _pixelPosition;
        public string TextureName { get; private set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        public Rectangle SourceRectangle { get; private set; }
        private readonly Rectangle _boundingBox;
        public bool FaceRight { get; set; }
        public bool FaceLeft { get; set; }
        public bool FaceTop { get; set; }
        public bool FaceBottom { get; set; }

        public bool IsSolid { get; set; }
        public bool DebugDraw { get; set; }

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
            _boundingBox = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width, sourceRectangle.Height);
            IsSolid = solid;
        }

        public Tile(string textureName, Vector2 gridPosition, Vector2 pixelPosition, Rectangle sourceRectangle, bool solid = true) {
            _pixelPosition = pixelPosition;
            TextureName = textureName;
            Position = gridPosition;
            SourceRectangle = sourceRectangle;
            _boundingBox = new Rectangle((int)pixelPosition.X, (int)pixelPosition.Y, sourceRectangle.Width, sourceRectangle.Height);
            IsSolid = solid;
        }

        public Rectangle GetBoundingBox(){
            return _boundingBox;
        }

        public virtual void Collide(ICollidable second) {
        }
    }
}
