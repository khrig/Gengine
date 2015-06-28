using Gengine.CollisionDetection;
using Gengine.Rendering;

namespace Gengine.Entities {
    public interface IEntity : ICollisionHandler, IRenderable {
        void Update(float deltaTime);
        bool IsDestroyed { get; }
    }
}
