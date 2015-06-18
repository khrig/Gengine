using Microsoft.Xna.Framework;

namespace Gengine.Entities {
    public interface IPickupFactory{
        IPickup CreatePickup(string id, Vector2 position);
    }
}
