using System.Collections.Generic;

namespace Gengine.EntityComponentSystem {
    public class EntityWorld {
        private readonly EntityManager _entityManager;
        private readonly List<EntitySystem> _entityUpdateSystems;
        private readonly List<EntitySystem> _entityRenderingSystems;

        public EntityWorld() {
            _entityManager = new EntityManager();
            _entityUpdateSystems = new List<EntitySystem>();
            _entityRenderingSystems = new List<EntitySystem>();
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
        public void RegisterUpdateSystem(EntitySystem system) {
            system.EntityManagerInstance = _entityManager;
            _entityUpdateSystems.Add(system);
        }

        public void RegisterRenderSystem(EntitySystem system) {
            system.EntityManagerInstance = _entityManager;
            _entityRenderingSystems.Add(system);
        }

        public void RegisterUpdateSystems(params EntitySystem[] systems) {
            RegisterSystems(_entityUpdateSystems, systems);
        }

        public void RegisterRenderSystems(params EntitySystem[] systems){
            RegisterSystems(_entityRenderingSystems, systems);
        }

        private void RegisterSystems(List<EntitySystem> systemCollection, params EntitySystem[] systems){
            foreach (var system in systems) {
                system.EntityManagerInstance = _entityManager;
                systemCollection.Add(system);
            }
        }

        /// <summary>
        /// Updates all systems in order from when they are registered
        /// </summary>
        /// <param name="dt"></param>
        public void Update(float dt) {
            foreach (var system in _entityUpdateSystems) {
                system.Update(dt);
            }
        }

        public void UpdateBeforeDraw(float dt) {
            foreach (var system in _entityRenderingSystems) {
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

        public void Remove(Entity entity){
            _entityManager.Remove(entity);
        }

        public void RemoveAll(){
            _entityManager.RemoveAll();
        }
    }
}
