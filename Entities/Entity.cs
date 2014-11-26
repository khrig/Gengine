using System.Collections.Generic;
using System.Linq;

namespace Gengine.Entities {
    public abstract class Entity {
        private readonly List<IEntityComponent> components = new List<IEntityComponent>();

        public void AddComponent(IEntityComponent entityComponent) {
            entityComponent.SetRelation(this);
            components.Add(entityComponent);
        }

        public T GetComponent<T>() {
            return (T)components.First(c => c.GetType() == typeof(T));
        }

        public void Update(float deltaTime) {
            foreach (IEntityComponent entityComponent in components) {
                entityComponent.Update(deltaTime);
            }
        }

        public void HandleCommand(string message) {
            foreach (IEntityComponent entityComponent in components) {
                entityComponent.HandleCommand(message);
            }
        }
    }
}
