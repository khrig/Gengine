using System.Collections.Generic;
using Gengine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine {
    public class TileMap {
        private List<Tile> tiles;

        // should probably load from file or something
        public TileMap(Texture2D environmentTexture) {
            this.tiles = new List<Tile>();

            Vector2 groundPos = new Vector2(0, 480);
            for (int i = 1; i < 26; i++) {
                tiles.Add(new Tile(environmentTexture, groundPos, new Rectangle(0, 0, 32, 32)));
                groundPos.X += 32;
            }
        }

        public IEnumerable<IRenderable> Tiles { get { return tiles; } }
        public IEnumerable<ICollidable> CollisionMap { get { return tiles; } }
    }
}
