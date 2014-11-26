namespace Gengine.Entities {
    public abstract class EntityComponent : IEntityComponent {
        protected Entity Entity;
        public virtual void Update(float deltaTime) { }
        public virtual void HandleCommand(string message) { }

        public void SetRelation(Entity entity) {
            Entity = entity;
        }
    }
}
