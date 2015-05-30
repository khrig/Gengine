using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gengine.Camera
{
    public class SimpleCamera2D
    {
        public SimpleCamera2D()
        {
            Position = Vector2.Zero;
            Zoom = 1f;
        }

        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Zoom { get; set; }

        public Matrix GetTransformMatrix()
        {
            return Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(Zoom) *
                   Matrix.CreateTranslation(Position.X, Position.Y, 0);
        }
    }
}
