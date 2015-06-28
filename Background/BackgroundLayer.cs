using System.Collections.Generic;
using Gengine.Entities;
using Gengine.Rendering;
using Microsoft.Xna.Framework;

namespace Gengine.Background{
    public class BackgroundLayer {
        private readonly List<IBackgroundTile> _backgroundTiles; 
        public BackgroundLayer(){
            _backgroundTiles = new List<IBackgroundTile>();
        }

        public void AddTile(IBackgroundTile backgroundTile){
            _backgroundTiles.Add(backgroundTile);
        }

        public void AddRepeatedTile(string textureName, int tileWidth, int tileHeight, int mapWidth, int mapHeight){
            AddRepeatedTile(textureName, tileWidth, tileHeight, mapWidth, mapHeight, 0, 0);
        }

        public void AddRepeatedTile(string textureName, int tileWidth, int tileHeight, int mapWidth, int mapHeight, int tileSourceX, int tileSourceY) {
            for (int x = 0;x < mapWidth / tileWidth;x++) {
                for (int y = 0;y < mapHeight / tileHeight;y++) {
                    _backgroundTiles.Add(new BackgroundTile(textureName, new Vector2(x * tileWidth, y * tileHeight), new Rectangle(tileSourceX, tileSourceY, tileWidth, tileHeight)));
                }
            }
        }

        public IEnumerable<IRenderable> GetRenderables(){
            return _backgroundTiles;
        }

        public void Update(float dt, Vector2 direction){
            foreach (var backgroundTile in _backgroundTiles){
                backgroundTile.Update(dt, direction);    
            }
        }
    }
}