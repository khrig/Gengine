using System.Collections.Generic;
using Gengine.Entities;
using Gengine.Map;

namespace Gengine.Systems {
    public class CollisionSystem {
        public void HandleCollisions(IEnumerable<ICollidable> collidableObjects) {
            foreach (var first in collidableObjects) {
                foreach (var second in collidableObjects) {
                    TestCollision(first, second);
                }
            }
        }

        public bool IsColliding(ICollidable collidable, TileMap tileMap){
            // Find the four tiles we are in
            Tile t1 = tileMap.PositionToTile(collidable.BoundingBox.Right, collidable.BoundingBox.Top);
            Tile t2 = tileMap.PositionToTile(collidable.BoundingBox.Right, collidable.BoundingBox.Bottom);
            Tile t3 = tileMap.PositionToTile(collidable.BoundingBox.Left, collidable.BoundingBox.Top);
            Tile t4 = tileMap.PositionToTile(collidable.BoundingBox.Left, collidable.BoundingBox.Bottom);

            if (t1.IsSolid || t2.IsSolid || t3.IsSolid || t4.IsSolid)
                return true;
            return false;
        }

        public void HandleCollision(ICollidable first, ICollidable second) {
            TestCollision(first, second);
        }

        private void TestCollision(ICollidable first, ICollidable second) {
            if (first == second)
                return;

            if(first.BoundingBox.Intersects(second.BoundingBox)) {
                first.Collide(second);
                second.Collide(first);
            }
        }
    }
}
