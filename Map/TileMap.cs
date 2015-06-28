using System;
using System.Linq;
using System.Collections.Generic;
using Gengine.Rendering;
using Microsoft.Xna.Framework;

namespace Gengine.Map {
    public class TileMap : ICollidableMap {
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

        public int TileSize { get { return 32; } }
        public Tile Tile(int x, int y) {
            return Tiles[x, y];
        }

        public Tile PositionToTile(Vector2 position) {
            return PositionToTile(position.X, position.Y);
        }

        public Tile PositionToTile(float x, float y) {
            int tileX = (int)(x / TileSize);
            int tileY = (int)(y / TileSize);
            return Tiles[tileX, tileY];
        }

        public void ForeachTile(Action<Tile> tileAction) {
            int tileCountX = Width / TileSize;
            int tileCountY = Height / TileSize;
            for (int x = 0; x < tileCountX; x++){
                for (int y = 0; y < tileCountY; y++){
                    tileAction(Tiles[x, y]);
                }
            }
        }

        private IEnumerable<IRenderable> _tiles;
        public IEnumerable<IRenderable> RenderableTiles {
            get { return _tiles ?? (_tiles = _layers.OrderBy(l => l.Index).SelectMany(l => l.Tiles)); }
        }

        public void AddLayer(Layer layer) {
            _layers.Add(layer);
        }

        public void CreateCollisionLayer() {
            int tileCountX = Width / TileSize;
            int tileCountY = Height / TileSize;

            Tiles = new Tile[tileCountX, tileCountY];

            for (int x = 0; x < tileCountX; x++) {
                for (int y = 0; y < tileCountY; y++) {
                    Tile tile = _layers.First(l => l.Name == "Collision").Tiles.FirstOrDefault(t => t.Position.X == x * TileSize && t.Position.Y == y * TileSize);
                    if (tile == null) {
                        Tiles[x, y] = new Tile(null, new Vector2(x, y), new Rectangle(0, 0, TileSize, TileSize), false);
                    } else {
                        Tiles[x, y] = new Tile(null, new Vector2(x, y), tile.Position, new Rectangle(0, 0, TileSize, TileSize));
                    }
                }
            }
        }

        public void SetExitPoint(){
            Tile tile = _layers.First(l => l.Name == "Exit").Tiles.FirstOrDefault();
            if(tile == null)
                throw new Exception("Exit point not found! A Layer with name Exit with one tile in it is required!");

            ExitPoint = new Point((int)tile.RenderPosition.X + TileSize / 2, (int)tile.RenderPosition.Y + TileSize/2);
        }
    }
}
