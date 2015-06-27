using Microsoft.Xna.Framework;

namespace Gengine.Entities {
    public interface ICollidable{
        Rectangle GetBoundingBox();
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
    }
}
