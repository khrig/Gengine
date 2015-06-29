using System;
using System.Collections.Generic;

namespace Gengine.EntityComponentSystem{
    public sealed class EntityManager {
        private int _lastEntityId = 0;
        private const int MaxComponents = 100;
        // These can be enhanced to use less memory and in concurrent memory
        // Like creating a specialized collection that auto increases size
        private readonly Dictionary<int, Entity> _uniqueIdToEntities;
        private readonly Dictionary<int, List<IComponent>> _entityToComponents;

        // Can also try some kind of bitmask to know which components an entity has

        public EntityManager(){
            _uniqueIdToEntities = new Dictionary<int, Entity>();
            _entityToComponents = new Dictionary<int, List<IComponent>>();
        }

        public Entity Create(params IComponent[] components){
            var entityId = ++_lastEntityId;
            var entity = new Entity(entityId, this);
            _uniqueIdToEntities.Add(entityId, entity);
            _entityToComponents.Add(entityId, new List<IComponent>(MaxComponents));
            foreach (IComponent component in components){
                AddComponent(entity, component);
            }
            return entity;
        }

        public void Remove(Entity entity){
            _uniqueIdToEntities.Remove(entity.Id);
            _entityToComponents.Remove(entity.Id);
        }

        public void AddComponent(Entity entity, IComponent component){
            List<IComponent> components = _entityToComponents[entity.Id];
            components.Add(component);
        }

        internal IComponent GetComponent(Entity entity, Type componentType){
            List<IComponent> components = _entityToComponents[entity.Id];
            foreach (var component in components){
                if (component.GetType() == componentType)
                    return component;
            }
            return null;
        }

        public T GetComponent<T>(Entity entity) where T : IComponent{
            List<IComponent> components = _entityToComponents[entity.Id];
            foreach (var component in components){
                if (component.GetType() == typeof (T))
                    return (T) component;
            }
            return default(T);
        }

        public IEnumerable<Entity> EntitiesWithComponents(params Type[] types){
            foreach (var entity in _uniqueIdToEntities.Values){
                bool hasComponents = true;
                foreach (var type in types){
                    hasComponents = hasComponents && GetComponent(entity, type) != null;
                }
                if (hasComponents)
                    yield return entity;
            }
        }

        public IEnumerable<T> GetAllComponents<T>(){
            foreach (var entity in _uniqueIdToEntities.Values){
                var component = entity.GetComponent(typeof (T));
                if (component != null)
                    yield return (T)component;
            }
        }

        public void RemoveAll() {
            _uniqueIdToEntities.Clear();
            _entityToComponents.Clear();
        }
    }
}
