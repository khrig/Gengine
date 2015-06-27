using System;
using System.Collections.Generic;
using Gengine.Entities;
using Gengine.Map;

namespace Gengine.Systems {
    public interface ICollisionSystem {
        void Collide(IEnumerable<ICollidable> first, ICollidableMap map);
        void Overlap(IEnumerable<ICollidable> first, IEnumerable<ICollidable> second, Action<ICollidable, ICollidable> onOverlap);
        IEnumerable<IRenderable> Collisions { get; }
    }
}
