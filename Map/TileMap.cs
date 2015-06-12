using System.Linq;
using System.Collections.Generic;
using Gengine.Entities;
using Microsoft.Xna.Framework;

namespace Gengine.Map {
    public class TileMap {
        private readonly List<Layer> _layers;

        public Tile[,] Tiles { get; set; }

        public TileMap(int width, int height) {
            Width = width;
            Height = height;
            _layers = new List<Layer>();
        }

        public Tile PositionToTile(Vector2 position) {
            return PositionToTile(position.X, position.Y);
        }

        public Tile PositionToTile(float x, float y) {
            int tileX = (int)(x / 32);
            int tileY = (int)(y / 32);
            return Tiles[tileX, tileY];
        }

        public IEnumerable<IRenderable> RenderableTiles {
            get {
                return _layers.SelectMany(l => l.Tiles);
            } 
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public IEnumerable<Layer> Layers { get {
                return _layers;
            }
        }

        public void AddLayer(Layer layer) {
            _layers.Add(layer);
        }

        public void CreateCollisionLayer() {
            int tileCountX = Width / 32;
            int tileCountY = Height / 32;

            // Temp, only gets one layer now (maybe collision layer?)
            Tiles = new Tile[tileCountX, tileCountY];

            for (int x = 0; x < tileCountX; x++) {
                for (int y = 0; y < tileCountY; y++) {
                    Tile tile = _layers.SelectMany(l => l.Tiles).FirstOrDefault(t => t.Position.X == x * 32 && t.Position.Y == y * 32);
                    if (tile == null) {
                        Tiles[x, y] = new Tile(null, new Vector2(x, y), new Rectangle(0, 0, 32, 32), false);
                    } else {
                        tile.Position = new Vector2(x, y);
                        Tiles[x, y] = tile;
                    }
                    //Tiles[x, y] = new Tile(string.Format("{0}:{1}", x * _tileSize, y * _tileSize)) {
                    //    Position = new Vector2(x, y)
                    //};

                    /*
                    if (x == 0 || x == gridSize.X - 1 || y == 0 || y == gridSize.Y - 1)
                        Tiles[x, y].IsSolid = true;
                    if (y == gridSize.Y - 2 && x == 5) {
                        Tiles[x, y].IsSolid = true;
                    }

                    if (y == gridSize.Y - 4 && x == _gridSize.X - 3) {
                        Tiles[x, y].IsSolid = true;
                    }
                    if (y == 4 && x >= 0 && x < 6) {
                        Tiles[x, y].IsSolid = true;
                    }
                     * */
                }
            }
        }
    }
}
