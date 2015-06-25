using System;

namespace Gengine.EntityComponentSystem{
    public abstract class EntityProcessingSystem : EntitySystem{
        protected EntityProcessingSystem(params Type[] components) : base(components){}
        public abstract void Process(Entity entity, float dt);

        public override void Update(float dt){
            foreach (Entity entity in EntityManagerInstance.EntitiesWithComponents(ComponentTypes)) {
                Process(entity, dt);
            }
        }
    }
}
