using System.Collections.Generic;
using Gengine.Background;
using Gengine.Entities;
using Gengine.Map;
using Microsoft.Xna.Framework;

namespace Gengine.Level {
    public class Level {
        public TileMap TileMap { get; private set; }
        public Vector2 StartPosition { get; private set; }
        public BackgroundLayers BackgroundLayers { get; private set; }
        public List<IEntity> SpawnList { get; private set; }

        public Level(TileMap tileMap, Vector2 playerStart, BackgroundLayers backgroundLayers, IEnumerable<IEntity> enemies) {
            StartPosition = playerStart;
            TileMap = tileMap;
            BackgroundLayers = backgroundLayers;
        }

        public void Unload(){
            TileMap = null;
            BackgroundLayers = null;
        }
    }
}
