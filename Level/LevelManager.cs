using System.Collections.Generic;
using Gengine.Background;
using Gengine.Entities;
using Gengine.Map;
using Microsoft.Xna.Framework;

namespace Gengine.Level {
    public class LevelManager {
        private readonly IMapRepository _mapRepository;
        private readonly BackgroundFactory _backgroundFactory;
        private readonly IEntityFactory _enemyFactory;

        public LevelManager(IEntityFactory entityFactory){
            _mapRepository = new MapRepository(true);
            _backgroundFactory = new BackgroundFactory();
            _enemyFactory = entityFactory;
        }

        // Should load everything from files
        public Level LoadLevel(int id){
            var tileMap = _mapRepository.LoadMap("Maps\\largeroom.tmap");
            return new Level(tileMap, new Vector2(100, 100), _backgroundFactory.CreateBackgroundLayers("testrepeat"), new List<IEntity>{
                _enemyFactory.Create("slime", new Vector2(608, 288), tileMap),
                _enemyFactory.Create("slime", new Vector2(1184, 288), tileMap)
            });
        }
    }
}
