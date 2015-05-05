using System.Linq;
using System.Collections.Generic;
using Gengine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine.Map {
    public class TileMap {
        private List<Tile> tiles;
        private List<Layer> _Layers;
        public TileMap(string environmentTextureName) {
            _Layers = new List<Layer>();
            this.tiles = new List<Tile>();

            Vector2 groundPos = new Vector2(0, 328);
            for (int i = 1; i < 26; i++) {
                tiles.Add(new Tile(environmentTextureName, groundPos, new Rectangle(0, 0, 32, 32)));
                groundPos.X += 32;
            }
        }

        public TileMap(int width, int height) {
            Width = width;
            Height = height;
            _Layers = new List<Layer>();

            // TEMP
            this.tiles = new List<Tile>();
            Vector2 groundPos = new Vector2(0, 328);
            for (int i = 1; i < 26; i++) {
                tiles.Add(new Tile("", groundPos, new Rectangle(0, 0, 32, 32)));
                groundPos.X += 32;
            }
        }

        public IEnumerable<IRenderable> Tiles { 
            get {
                return _Layers.SelectMany(l => l.Tiles);
            } 
        }

        public IEnumerable<ICollidable> CollisionMap { get { return tiles; } }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public IEnumerable<Layer> Layers { get {
                return _Layers;
            }
        }

        public void AddLayer(Layer layer) {
            _Layers.Add(layer);
        }
    }
}
