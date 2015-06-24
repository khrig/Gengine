namespace Gengine.Entities {
    public abstract class EntityComponent : IEntityComponent {
        protected AbstractEntity AbstractEntity;
        public virtual void Update(float deltaTime) { }
        public virtual void HandleCommand(string message) { }

        public void SetRelation(AbstractEntity abstractEntity) {
            AbstractEntity = abstractEntity;
        }
    }
}
