using System.Linq;
using Gengine.Background;
using Gengine.Entities;
using Gengine.Map;
using Microsoft.Xna.Framework;

namespace Gengine.Level {
    public class LevelManager {
        private readonly IMapRepository _mapRepository;
        private readonly BackgroundFactory _backgroundFactory;
        private readonly IEntityFactory _enemyFactory;
        private readonly IPickupFactory _pickupFactory;

        public LevelManager(IEntityFactory entityFactory, IPickupFactory pickupFactory){
            _mapRepository = new MapRepository(true);
            _backgroundFactory = new BackgroundFactory();
            _enemyFactory = entityFactory;
            _pickupFactory = pickupFactory;
        }

        // Should load everything from files
        public Level LoadLevel(int id){
            var tileMap = _mapRepository.LoadMap("Maps\\largeroom.tmap");
            var level = new Level(tileMap, new Vector2(100, 100), _backgroundFactory.CreateBackgroundLayers("testrepeat"));
            level.AddEntity(_enemyFactory.Create("slime", new Vector2(608, 288), tileMap));
            level.AddEntity(_enemyFactory.Create("slime", new Vector2(1184, 288), tileMap));
            level.AddPickup(_pickupFactory.CreatePickup("GravityReverse", new Vector2(448, 96)));
            level.AddPickup(_pickupFactory.CreatePickup("Health", new Vector2(480, 96)));
            return level;
        }
    }
}
