using System.Collections.Generic;
using System.Linq;

namespace Gengine.Entities {
    public abstract class AbstractEntity {
        private readonly List<IEntityComponent> _components = new List<IEntityComponent>();

        public void AddComponent(IEntityComponent entityComponent) {
            entityComponent.SetRelation(this);
            _components.Add(entityComponent);
        }

        public T GetComponent<T>() {
            return (T)_components.First(c => c.GetType() == typeof(T));
        }

        public void Update(float deltaTime) {
            foreach (IEntityComponent entityComponent in _components) {
                entityComponent.Update(deltaTime);
            }
        }

        public void HandleCommand(string message) {
            foreach (IEntityComponent entityComponent in _components) {
                entityComponent.HandleCommand(message);
            }
        }
    }
}
