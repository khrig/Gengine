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
        private readonly List<Tile> _collidedTiles;

        public ArcadeCollisionSystem(bool enableCollisionRendering = false){
            _collisionRenderingEnabled = enableCollisionRendering;
            _collisions = new List<IRenderable>();
            _collidedTiles = new List<Tile>(4);
        }
        
        public void Collide(IEnumerable<ICollidable> collidables, ICollidableMap map){
            if (_collisionRenderingEnabled){
                _collisions.Clear();
                map.ClearDebug();
            }

            foreach (var collidable in collidables){
                SetCollidedTiles(map, collidable);

                if (_collidedTiles.Any()){
                    foreach (var tile in _collidedTiles){
                        if (tile.GetBoundingBox().Intersects(collidable.GetBoundingBox())){
                            RenderCollision(tile);

                            float ox = 0;
                            float oy = 0;
                            var minX = 0;
                            var minY = 1;

                            if (Math.Abs(collidable.Velocity.X) > Math.Abs(collidable.Velocity.Y)){
                                //  Moving faster horizontally, check X axis first
                                minX = -1;
                            }
                            else if (Math.Abs(collidable.Velocity.X) < Math.Abs(collidable.Velocity.Y)) {
                                //  Moving faster vertically, check Y axis first
                                minY = -1;
                            }

                            if (collidable.Velocity.X != 0 && collidable.Velocity.Y != 0 && (tile.FaceLeft || tile.FaceRight) && (tile.FaceBottom || tile.FaceTop)) {
                                minX = Math.Min(Math.Abs(collidable.GetBoundingBox().X - tile.GetBoundingBox().Right), Math.Abs(collidable.GetBoundingBox().Right - tile.GetBoundingBox().Left));
                                minY = Math.Min(Math.Abs(collidable.GetBoundingBox().Y - tile.GetBoundingBox().Bottom), Math.Abs(collidable.GetBoundingBox().Bottom - tile.GetBoundingBox().Top));
                            }

                            if (minX < minY){
                                if (tile.FaceLeft || tile.FaceRight)
                                {
                                    ox = TileCheckX(collidable, tile);

                                    //  That's horizontal done, check if we still intersects? If not then we can return now
                                    if (ox != 0 && !tile.GetBoundingBox().Intersects(collidable.GetBoundingBox())){
                                        continue;
                                    }
                                }

                                if (tile.FaceTop || tile.FaceBottom) {
                                    oy = TileCheckY(collidable, tile);
                                }
                            }
                            else{
                                if (tile.FaceTop || tile.FaceBottom)
                                {
                                    oy = TileCheckY(collidable, tile);

                                    //  That's vertical done, check if we still intersects? If not then we can return now
                                    if (oy != 0 && !tile.GetBoundingBox().Intersects(collidable.GetBoundingBox())){
                                        continue;
                                    }
                                }

                                if (tile.FaceLeft || tile.FaceRight)
                                {
                                    ox = TileCheckX(collidable, tile);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SetCollidedTiles(ICollidableMap map, ICollidable collidable){
            int leftTile = collidable.GetBoundingBox().Left/map.TileSize;
            int topTile = collidable.GetBoundingBox().Top/map.TileSize;
            int rightTile = (int) Math.Ceiling((float) collidable.GetBoundingBox().Right/map.TileSize) - 1;
            int bottomTile = (int) Math.Ceiling(((float) collidable.GetBoundingBox().Bottom/map.TileSize)) - 1;

            _collidedTiles.Clear();
            for (int y = topTile; y <= bottomTile; ++y){
                for (int x = leftTile; x <= rightTile; ++x){
                    Tile tile = map.Tile(x, y);
                    if (tile.IsSolid)
                        _collidedTiles.Add(tile);
                }
            }
        }

        private float TileCheckY(ICollidable collidable, Tile tile) {
            float oy = 0.0f;
            if (collidable.Velocity.Y < 0 && tile.FaceBottom && collidable.GetBoundingBox().Y < tile.GetBoundingBox().Bottom){
                oy = collidable.GetBoundingBox().Y - tile.GetBoundingBox().Bottom;
            } else if (collidable.Velocity.Y > 0 && tile.FaceTop && collidable.GetBoundingBox().Bottom > tile.GetBoundingBox().Top){
                oy = collidable.GetBoundingBox().Bottom - tile.GetBoundingBox().Top;
            }

            if (oy != 0){
                collidable.Position = new Vector2(collidable.Position.X, (float)Math.Round(collidable.Position.Y - oy));
                collidable.Velocity = new Vector2(collidable.Velocity.X, 0);
            }
            return oy;
        }

        private float TileCheckX(ICollidable collidable, Tile tile) {
            float ox = 0.0f;
            if (collidable.Velocity.X < 0 && tile.FaceRight && collidable.GetBoundingBox().X < tile.GetBoundingBox().Right){
                ox = collidable.Position.X - tile.GetBoundingBox().Right;
                //ox = collidable.GetBoundingBox().GetHorizontalIntersectionDepth(tile.GetBoundingBox());
            } else if (collidable.Velocity.X > 0 && collidable.GetBoundingBox().Right > tile.GetBoundingBox().Left) {
                ox = collidable.GetBoundingBox().Right - tile.GetBoundingBox().Left;
            }
            if (ox != 0){
                collidable.Position = new Vector2((float)Math.Round(collidable.Position.X - ox), collidable.Position.Y);
                collidable.Velocity = new Vector2(0, collidable.Velocity.Y);
            }
            return ox;
        }

        private void RenderCollision(Tile tile){
            if (_collisionRenderingEnabled){
                tile.DebugDraw = true;
                _collisions.Add(tile);
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
