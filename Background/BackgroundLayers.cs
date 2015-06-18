using System.Collections.Generic;
using Gengine.Entities;
using Microsoft.Xna.Framework;

namespace Gengine.Background {
    public class BackgroundLayers {
        private readonly List<BackgroundLayer> _layers;
        private readonly List<IRenderable> _renderables;
 
        public BackgroundLayers() {
            _layers = new List<BackgroundLayer>(10);
            _renderables = new List<IRenderable>();
        }

        public void AddLayer(BackgroundLayer layer){
            _layers.Add(layer);
            _renderables.AddRange(layer.GetRenderables());
        }

        public IEnumerable<IRenderable> GetRenderables(){
            return _renderables;
        }

        public void Update(float dt, Vector2 direction){
            foreach (var layer in _layers){
                layer.Update(dt, direction);
            }
        }
    }
}
