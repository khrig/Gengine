namespace Gengine.Entities {
    public interface IEntity : ICollisionHandler, IRenderable {
        void Update(float deltaTime);
        bool IsDestroyed { get; }
    }
}
