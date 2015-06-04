using System;
using Gengine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine.Examples
{
    public class PlayerEntity : Entity, IRenderable, ICollidable {
        public PlayerEntity(InputComponent input, MovementComponent movement) {
            // Order matters
            AddComponent(input);
            AddComponent(movement);
        }

        public string TextureName { get { return null; } }
        public Vector2 Position { get { return GetComponent<MovementComponent>().Position; } }
        public Rectangle SourceRectangle { get { return new Rectangle(0,0,0,0); } }

        public void Collide(ICollidable target) {
        }

        public Rectangle BoundingBox { get; private set; }

        public string Identifier
        {
            get { return "player"; }
        }

        public Vector2 RenderPosition {
            get { return Position; }
        }

        public RenderType Type {
            get { return RenderType.Sprite; }
        }

        public string FontName { get { throw new System.NotImplementedException(); } }
        public string Text { get { throw new System.NotImplementedException(); } }
        public Color Color { get { throw new System.NotImplementedException(); } }
    }
}
