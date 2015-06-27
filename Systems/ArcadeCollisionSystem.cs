using System;
using System.Collections.Generic;
using System.Linq;
using Gengine.Entities;
using Gengine.Map;
using Microsoft.Xna.Framework;

namespace Gengine.Systems {
    public class ArcadeCollisionSystem : ICollisionSystem{
        private readonly List<IRenderable> _collisions;
        public IEnumerable<IRenderable> Collisions { get { return _collisionRenderingEnabled ? _collisions : Enumerable.Empty<IRenderable>(); } }
        private readonly bool _collisionRenderingEnabled;
        public ArcadeCollisionSystem(bool enableCollisionRendering = false){
            _collisionRenderingEnabled = enableCollisionRendering;
            _collisions = new List<IRenderable>();
        }
        
        public void Collide(IEnumerable<ICollidable> collidables, ICollidableMap map){
            _collisions.Clear();
            map.ClearDebug();
            foreach (var collidable in collidables){
                Rectangle collidableBoundingBox = collidable.BoundingBox;
                int leftTile = collidableBoundingBox.Left / map.TileSize;
                int topTile = collidableBoundingBox.Top / map.TileSize;
                int rightTile = (int)Math.Ceiling((float)collidableBoundingBox.Right / map.TileSize);
                int bottomTile = (int)Math.Ceiling(((float)collidableBoundingBox.Bottom / map.TileSize));

                for (int y = topTile; y <= bottomTile; ++y){
                    for (int x = leftTile; x <= rightTile; ++x){
                        Tile tile = map.Tile(x, y);
                        if (tile.IsSolid && tile.BoundingBox.Intersects(collidableBoundingBox)){
                            if (_collisionRenderingEnabled){
                                tile.DebugDraw = true;
                                _collisions.Add(tile);
                            }
                        }
                    }
                }

                /*
                 * 
	int leftTile = playerBounds.Left / TileSize;
	int topTile = playerBounds.Top / TileSize;
	int rightTile = (int)Math.Ceiling((float)playerBounds.Right / TileSize) - 1;
	int bottomTile = (int)Math.Ceiling(((float)playerBounds.Bottom / TileSize)) - 1;

	for (int y = topTile; y <= bottomTile; ++y)
	{
		for (int x = leftTile; x <= rightTile; ++x)
		{
                 * */
            }
        }

        public void Overlap(IEnumerable<ICollidable> first, IEnumerable<ICollidable> second, Action<ICollidable, ICollidable> onOverlap){
            

        }


        /*
         * //collision from phaser
         * 
            this.game.physics.arcade.collide(this.player, this.blockedLayer);
            this.game.physics.arcade.overlap(this.player, this.items, this.collect, null, this);
            this.game.physics.arcade.overlap(this.player, this.doors, this.enterDoor, null, this);
            Implementing collect():

            collect: function(player, collectable) {
                console.log('yummy!');
 
                //remove sprite
                collectable.destroy();
              },
            And enterDoor(), which is something left for a follow-up tutorial:

            enterDoor: function(player, door) {
                console.log('entering door that will take you to '+door.targetTilemap+' on x:'+door.targetX+' and y:'+door.targetY);
              },
         * */
    }
}
