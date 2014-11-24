using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine.Entities {
    public abstract class Entity {
        private readonly Dictionary<string, IEntityComponent> components = new Dictionary<string, IEntityComponent>();

        public void AddComponent(string id, IEntityComponent entityComponent) {
            components.Add(id, entityComponent);
        }

        public IEntityComponent GetComponent(string id) {
            return components[id];
        }

        public void Update(float deltaTime) {
            foreach (IEntityComponent entityComponent in components.Values) {
                entityComponent.Update(deltaTime);
            }
        }

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
