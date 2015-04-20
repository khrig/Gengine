using System;
using Gengine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine.Examples
{
    public class PlayerEntity : Entity, IRenderable, ICollidable {
        public PlayerEntity(InputComponent input, VisualComponent visual, MovementComponent movement, AnimationComponent animation) {
            // Order matters
            AddComponent(input);
            AddComponent(visual);
            AddComponent(movement);
            AddComponent(animation);
        }

        public Texture2D Texture { get { return GetComponent<VisualComponent>().Texture; } }
        public Vector2 Position { get { return GetComponent<MovementComponent>().Position; } }
        public Rectangle SourceRectangle { get { return GetComponent<AnimationComponent>().SourceRectangle; } }

        public void Collide(ICollidable target) {
        }

        public Rectangle BoundingBox { get; private set; }

        public string Identifier
        {
            get { return "player"; }
        }
    }
}
