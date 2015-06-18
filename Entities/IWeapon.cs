using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Gengine.Entities{
    public interface IWeapon {
        float Delay { get; }
        string Name { get; }
        IEnumerable<IProjectile> Fire(Vector2 position, float direction);
    }
}