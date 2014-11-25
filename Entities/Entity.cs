using System.Collections.Generic;
using System.Linq;

namespace Gengine.Entities {
    public abstract class Entity {
        private readonly HashSet<IEntityComponent> components = new HashSet<IEntityComponent>();

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
    }
}
