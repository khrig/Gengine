using System;
using System.Collections.Generic;
using Gengine.Entities;
using Gengine.Map;

namespace Gengine.Systems {
    public interface ICollisionSystem {
        void Collide(IEnumerable<ICollidable> first, ICollidableMap map);
        /// <summary>
        /// Tests if the collidable is overlapping the list of collidables.
        /// Returns if onOverlap returns true
        /// </summary>
        /// <param name="collidable"></param>
        /// <param name="collidables"></param>
        /// <param name="onOverlap">a func to do if there is an overlap, return true if checking should stop</param>
        void Overlap(ICollidable collidable, IEnumerable<ICollidable> collidables, Func<ICollidable, ICollidable, bool> onOverlap);
        void Overlap(IEnumerable<ICollidable> first, IEnumerable<ICollidable> second, Action<ICollidable, ICollidable> onOverlap);
        IEnumerable<IRenderable> Collisions { get; }
    }
}
