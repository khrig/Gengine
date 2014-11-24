namespace Gengine.Entities {
    public abstract class EntityComponent : IEntityComponent {
        protected Entity Entity;
        protected EntityComponent(Entity entity) {
            Entity = entity;
        }

        public abstract void Update(float deltaTime);
    }
}
