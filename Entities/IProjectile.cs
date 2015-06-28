using Gengine.CollisionDetection;
using Gengine.Rendering;
using Microsoft.Xna.Framework;

namespace Gengine.Entities {
    public interface IProjectile : ICollisionHandler, IRenderable {
        bool IsAlive { get; }
        bool IsDestroyed { get; }
        void Init(Vector2 position, float direction);
        void Update(float deltaTime);
        void Destroy();
    }
}
