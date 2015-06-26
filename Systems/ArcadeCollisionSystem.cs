using System.Collections.Generic;
using Gengine.Entities;

namespace Gengine.Systems {
    public class ArcadeCollisionSystem : ICollisionSystem {
        public void CheckCollisions(IEnumerable<ICollidable> collidables){
            foreach (var first in collidables){
                foreach (var second in collidables){
                    
                }
            }
        }
    }
}
