namespace Gengine.Entities {
    public abstract class EntityComponent : IEntityComponent {
        protected Entity Entity;
        public virtual void Update(float deltaTime) { }

        public void SetRelation(Entity entity) {
            Entity = entity;
        }
    }
}
