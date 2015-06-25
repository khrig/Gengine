using Microsoft.Xna.Framework;

namespace Gengine.Entities {
    public interface ICollidable {
        Rectangle BoundingBox { get; }
    }
}
