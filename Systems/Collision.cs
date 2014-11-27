using System.Collections.Generic;
using Gengine.Entities;

namespace Gengine.Systems {
    public class Collision {
        public void HandleCollisions(IEnumerable<ICollidable> collidableObjects) {
            foreach (var first in collidableObjects) {
                foreach (var second in collidableObjects) {
                    TestCollision(first, second);
                }
            }
        }

        private void TestCollision(ICollidable first, ICollidable second) {
            if (first == second)
                return;

            if(first.BoundingBox.Intersects(second.BoundingBox)) {
                first.Collide(second);
            }
        }
    }
}
