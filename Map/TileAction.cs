using Microsoft.Xna.Framework;

namespace Gengine.Map {
    public class TileAction : Tile {
        public TileAction(string textureName, Vector2 position, Rectangle sourceRectangle, bool solid = true) : base(textureName, position, sourceRectangle, solid){}
        public TileAction(string textureName, Vector2 gridPosition, Vector2 pixelPosition, Rectangle sourceRectangle, bool solid = true) : base(textureName, gridPosition, pixelPosition, sourceRectangle, solid){}

        public void OnOverlap(){
            
        }
    }
}
