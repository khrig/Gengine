using System.Collections.Generic;
using System.Linq;
using Gengine.Entities;
using Gengine.Map;
using Microsoft.Xna.Framework;

namespace Gengine.Systems {
    public class CollisionSystem {
        public bool IsCenterColliding(ICollidable collidable, TileMap tileMap){
            return tileMap.PositionToTile(collidable.BoundingBox.Center.X, collidable.BoundingBox.Center.Y).IsSolid;
        }
        
        public bool Collision(ICollidable collidable, Point point){
            return collidable.BoundingBox.Contains(point);
        }
    }
}
