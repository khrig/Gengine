using System.Collections.Generic;
using System.Linq;
using Gengine.Entities;
using Microsoft.Xna.Framework;

namespace Gengine.Background {
    public class BackgroundLayers {
        private readonly List<BackgroundLayer> _layers;
        public BackgroundLayers() {
            _layers = new List<BackgroundLayer>();
        }

        public void AddLayer(BackgroundLayer layer){
            _layers.Add(layer);
        }

        public IEnumerable<IRenderable> GetRenderables(){
            return _layers.SelectMany(l => l.GetRenderables());
        }

        public void Update(float dt, Vector2 direction){
            foreach (var layer in _layers){
                layer.Update(dt, direction);
            }
        }
    }
}
