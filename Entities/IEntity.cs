namespace Gengine.Entities {
    public interface IEntity : ICollidable, IRenderable {
        void Update(float deltaTime);
        bool IsDestroyed { get; }
    }
}
