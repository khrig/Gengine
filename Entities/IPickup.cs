using Gengine.CollisionDetection;
using Gengine.Rendering;

namespace Gengine.Entities {
    public interface IPickup : ICollisionHandler, IRenderable {
        bool IsPickedUp { get; }
    }
}
