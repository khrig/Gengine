using Microsoft.Xna.Framework;

namespace Gengine.Map {
    public class TileWithMapTransition : Tile {
        public TileWithMapTransition(string textureName, Vector2 position, Rectangle sourceRectangle, bool solid = true) : base(textureName, position, sourceRectangle, solid){}
        public TileWithMapTransition(string textureName, Vector2 gridPosition, Vector2 pixelPosition, Rectangle sourceRectangle, bool solid = true) : base(textureName, gridPosition, pixelPosition, sourceRectangle, solid){}


        public int TargetTileMap { get; set; }
        public float TargetX { get; set; }
        public float TargetY { get; set; }
    }
}
