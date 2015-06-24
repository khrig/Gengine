namespace Gengine.Entities {
    public interface IEntityComponent {
        void SetRelation(AbstractEntity abstractEntity);
        void Update(float deltaTime);
        void HandleCommand(string message);
    }
}