using System;
using System.Collections.Generic;
using Gengine.Rendering;
using Gengine.EntityComponentSystem;

namespace Gengine.State {
    public abstract class SceneState : State {
        private readonly SortedList<int, IRenderable> _renderables;
        private Dictionary<string, object> _stateData; 
        private EntityWorld _entityWorld;

        public Action OnUnload { private get; set; }

        public EntityWorld EntityWorld{
            get { return _entityWorld ?? (_entityWorld = new EntityWorld()); }
        }

        protected SceneState() {
            _renderables = new SortedList<int, IRenderable>();
            _stateData = new Dictionary<string, object>();
        }

        public override void Unload(){
            if (OnUnload != null)
                OnUnload();

            _renderables.Clear();
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

        public void AddRenderable(IRenderable renderable) {
            if(!_renderables.ContainsValue(renderable))
                _renderables.Add(_renderables.Count + 1, renderable);
        }

        public void RemoveRenderable(IEnumerable<IRenderable> renderables){
            foreach (var renderable in renderables) {
                RemoveRenderable(renderable);
            }
        }

        public void RemoveRenderable(IRenderable renderable){
            if (_renderables.ContainsValue(renderable)){
                int index = _renderables.IndexOfValue(renderable);
                _renderables.RemoveAt(index);
            }
        }

        public override IEnumerable<IRenderable> GetRenderTargets(){
            return _renderables.Values;
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
