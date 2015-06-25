using System.Collections.Generic;
using System.Linq;
using Gengine.Entities;
using Gengine.Map;
using Microsoft.Xna.Framework;

namespace Gengine.Systems {
    public class CollisionSystem {
        public void HandleCollisions(IEnumerable<ICollisionHandler> collidableObjects) {
            var collidables = collidableObjects as ICollisionHandler[] ?? collidableObjects.ToArray();
            foreach (var first in collidables) {
                foreach (var second in collidables) {
                    TestCollision(first, second);
                }
            }
        }

        public bool IsCenterColliding(ICollidable collidable, TileMap tileMap){
            return tileMap.PositionToTile(collidable.BoundingBox.Center.X, collidable.BoundingBox.Center.Y).IsSolid;
        }

        public void HandleCollision(ICollisionHandler first, ICollisionHandler second) {
            TestCollision(first, second);
        }

        private void TestCollision(ICollisionHandler first, ICollisionHandler second) {
            if (first == second)
                return;

            if(first.BoundingBox.Intersects(second.BoundingBox)) {
                first.Collide(second);
                second.Collide(first);
            }
        }

        public bool Collision(ICollidable collidable, Point point){
            return collidable.BoundingBox.Contains(point);
        }
    }
}
