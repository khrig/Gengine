using System.Collections.Generic;
using Gengine.Entities;

namespace Gengine.Systems {
    public interface ICollisionSystem {
        void CheckCollisions(IEnumerable<ICollidable> collidables);
    }
}
