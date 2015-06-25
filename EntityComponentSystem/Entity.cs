using System;

namespace Gengine.EntityComponentSystem{
    public sealed class Entity{
        public int Id { get; private set; }
        private readonly EntityManager _entityManager;

        public Entity(int id, EntityManager enitityManager){
            Id = id;
            _entityManager = enitityManager;
        }

        public void AddComponent(IComponent component){
            _entityManager.AddComponent(this, component);
        }

        public void AddComponentFromPool<T>(){
            throw new NotImplementedException();

            // create a pool of components
            // return from the pool next item that is available
        }

        public IComponent GetComponent(Type componentType){
            return _entityManager.GetComponent(this, componentType);
        }
    }
}
