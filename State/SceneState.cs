using System;
using System.Collections.Generic;
using System.Linq;
using Gengine.Rendering;
using Gengine.EntityComponentSystem;

namespace Gengine.State {
    public abstract class SceneState : State {
        private readonly Dictionary<string, object> _stateData;
        private readonly Dictionary<int, SortedList<int, IRenderable>> _renderLayers;
        private EntityWorld _entityWorld;

        public Action OnUnload { private get; set; }

        public EntityWorld EntityWorld{
            get { return _entityWorld ?? (_entityWorld = new EntityWorld()); }
        }

        protected SceneState() {
            _stateData = new Dictionary<string, object>();
            _renderLayers = new Dictionary<int, SortedList<int, IRenderable>>();
        }

        public override void Unload(){
            if (OnUnload != null)
                OnUnload();

            _renderLayers.Clear();
            _entityWorld.RemoveAll();
        }

        public Entity AddEntity(params IComponent[] components){
            return _entityWorld.Create(components);
        }

        public void AddRenderable(IEnumerable<IRenderable> renderables) {
            foreach (var renderable in renderables){
                AddRenderable(renderable);
            }
        }

        public void AddRenderable(IRenderable renderable){
            AddRenderable(renderable, 0);
        }

        public void AddRenderable(IEnumerable<IRenderable> renderables, int layer) {
            foreach (var renderable in renderables) {
                AddRenderable(renderable, layer);
            }
        }
        
        public void AddRenderable(IRenderable renderable, int layer) {
            if (!_renderLayers.ContainsKey(layer)){
                _renderLayers.Add(layer, new SortedList<int, IRenderable>());
            }
            if (!_renderLayers[layer].ContainsValue(renderable))
                _renderLayers[layer].Add(_renderLayers[layer].Count + 1, renderable);
        }

        public void RemoveRenderable(IEnumerable<IRenderable> renderables){
            foreach (var renderable in renderables) {
                RemoveRenderable(renderable);
            }
        }

        public void RemoveRenderable(IRenderable renderable){
            foreach (var layer in _renderLayers){
                if (layer.Value.ContainsValue(renderable)) {
                    var index = _renderLayers[layer.Key].IndexOfValue(renderable);
                    _renderLayers[layer.Key].RemoveAt(index);
                    return;
                }    
            }
        }

        public override IEnumerable<IEnumerable<IRenderable>> GetRenderLayers(){
            foreach (var layerKey in _renderLayers.Keys.OrderBy(key => key))
                yield return _renderLayers[layerKey].Values;
        }

        protected T GetStateValue<T>(string id){
            object data;
            if (_stateData.TryGetValue(id, out data)){
                return (T) data;
            }
            throw new Exception("State value with id not found: " + id);
        }

        protected void SetStateValue<T>(string id, T value) {
            if (!_stateData.ContainsKey(id))
                _stateData.Add(id, value);
            else
                _stateData[id] = value;
        }
    }
}
