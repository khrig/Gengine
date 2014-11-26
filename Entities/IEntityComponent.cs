namespace Gengine.Entities {
    public interface IEntityComponent {
        void SetRelation(Entity entity);
        void Update(float deltaTime);
        void HandleCommand(string message);
    }
}