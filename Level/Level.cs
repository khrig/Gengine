using System.Collections.Generic;
using System.Linq;
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
        private readonly List<IPickup> _pickups; 
        public IEnumerable<IPickup> Pickups { get { return _pickups.Where(p => !p.IsPickedUp); } } 

        public Level(TileMap tileMap, Vector2 playerStart, BackgroundLayers backgroundLayers) {
            StartPosition = playerStart;
            TileMap = tileMap;
            BackgroundLayers = backgroundLayers;
            SpawnList = new List<IEntity>(30);
            _pickups = new List<IPickup>(10);
        }

        public void Unload(){
            TileMap = null;
            BackgroundLayers = null;
            SpawnList = null;
        }

        public void AddEntity(IEntity entity){
            SpawnList.Add(entity);
        }

        public void AddPickup(IPickup pickup){
            _pickups.Add(pickup);
        }
    }
}
