using System;

namespace Gengine.EntityComponentSystem {
    public abstract class EntitySystem {
        protected Type[] ComponentTypes;
        internal EntityManager EntityManagerInstance { get; set; }
        public abstract void Update(float dt);

        protected EntitySystem(params Type[] components) {
            ComponentTypes = components;
        }
    }
}
