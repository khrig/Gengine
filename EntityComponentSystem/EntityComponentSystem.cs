using System;
using System.Collections.Generic;

namespace Gengine.EntityComponentSystem {
    public class EntityComponentSystem {
        private readonly EntityManager _entityManager;
        private readonly List<EntitySystem> _entitySystems;

        public EntityComponentSystem() {
            _entityManager = new EntityManager();
            _entitySystems = new List<EntitySystem>();
        }

        /// <summary>
        /// Creates an entity with the specified components
        /// </summary>
        /// <param name="components">A list of components that the entity will have</param>
        /// <returns>The entity created</returns>
        public Entity Create(params IComponent[] components) {
            return _entityManager.Create(components);
        }

        /// <summary>
        /// Systems get updated in the order they are registered
        /// </summary>
        /// <param name="system">The system to add in order</param>
        public void RegisterSystem(EntitySystem system) {
            system.EntityManagerInstance = _entityManager;
            _entitySystems.Add(system);
        }

        public void RegisterSystems(params EntitySystem[] systems) {
            foreach (var system in systems){
                system.EntityManagerInstance = _entityManager;
                _entitySystems.Add(system);    
            }
        }

        /// <summary>
        /// Updates all systems in order from when they are registered
        /// </summary>
        /// <param name="dt"></param>
        public void Update(float dt) {
            foreach (var system in _entitySystems) {
                system.Update(dt);
            }
        }

        /// <summary>
        /// Returns all components of a specific type from all entities
        /// </summary>
        /// <typeparam name="T">The component to fetch</typeparam>
        /// <returns>A list of all components with the specific type</returns>
        public IEnumerable<T> GetAllComponents<T>(){
            return _entityManager.GetAllComponents<T>();
        }
    }
}
