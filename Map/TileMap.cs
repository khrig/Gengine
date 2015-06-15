using System;
using System.Linq;
using System.Collections.Generic;
using Gengine.Entities;
using Microsoft.Xna.Framework;

namespace Gengine.Map {
    public class TileMap {
        private readonly List<Layer> _layers;
        public Tile[,] Tiles { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public IEnumerable<Layer> Layers {
            get {
                return _layers;
            }
        }
        public Point ExitPoint { get; set; }

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

        private IEnumerable<IRenderable> _tiles;
        public IEnumerable<IRenderable> RenderableTiles {
            get { return _tiles ?? (_tiles = _layers.OrderBy(l => l.Index).SelectMany(l => l.Tiles)); }
        }

        public void AddLayer(Layer layer) {
            _layers.Add(layer);
        }

        public void CreateCollisionLayer() {
            int tileCountX = Width / 32;
            int tileCountY = Height / 32;

            Tiles = new Tile[tileCountX, tileCountY];

            for (int x = 0; x < tileCountX; x++) {
                for (int y = 0; y < tileCountY; y++) {
                    Tile tile = _layers.First(l => l.Name == "Collision").Tiles.FirstOrDefault(t => t.Position.X == x * 32 && t.Position.Y == y * 32);
                    if (tile == null) {
                        Tiles[x, y] = new Tile(null, new Vector2(x, y), new Rectangle(0, 0, 32, 32), false);
                    } else {
                        Tiles[x, y] = new Tile(null, new Vector2(x, y), tile.Position, new Rectangle(0, 0, 32, 32));
                    }
                }
            }
        }

        public void SetExitPoint(){
            Tile tile = _layers.First(l => l.Name == "Exit").Tiles.FirstOrDefault();
            if(tile == null)
                throw new Exception("Exit point not found! A Layer with name Exit with one tile in it is required!");

            ExitPoint = new Point((int)tile.RenderPosition.X + 16, (int)tile.RenderPosition.Y + 16);
        }
    }
}
