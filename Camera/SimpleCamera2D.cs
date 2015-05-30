using Microsoft.Xna.Framework;

namespace Gengine.Camera {
    public class SimpleCamera2D {
        private readonly IWorld _world;

        public SimpleCamera2D(IWorld world) {
            _world = world;
            Position = Vector2.Zero;
            Zoom = 1f;
        }

        public void SetPosition(Vector2 position) {
            var newPos = new Vector2(-(position.X - _world.View.Width / 2), -(position.Y - _world.View.Height / 2));
            if (newPos.Y < 0)
                newPos.Y = 0;
            if (newPos.Y > 0)
                newPos.Y = 0;
            if (newPos.X > 0)
                newPos.X = 0;
            if (newPos.X < -_world.View.Width)
                newPos.X = -_world.View.Width;
            Position = newPos;
        }

        public Vector2 Position { get; private set; }
        public float Rotation { get; private set; }
        public float Zoom { get; private set; }

        public Matrix GetTransformMatrix() {
            return Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(Zoom) *
                   Matrix.CreateTranslation(Position.X, Position.Y, 0);
        }
    }
}
