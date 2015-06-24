using Microsoft.Xna.Framework;

namespace Gengine.Camera {
    public class SimpleCamera2D : ICamera {
        private readonly IWorld _world;

        public SimpleCamera2D(IWorld world) {
            _world = world;
            _position = Vector2.Zero;
            Zoom = 1f;
        }

        public void SetPosition(Vector2 position) {
            _position.X = -(position.X - _world.View.Width / 2);
            _position.Y = -(position.Y - _world.View.Height / 2);
            if (_position.Y < 0)
                _position.Y = 0;
            if (_position.Y > 0)
                _position.Y = 0;
            if (_position.X > 0)
                _position.X = 0;
            if (_position.X < -_world.View.Width)
                _position.X = -_world.View.Width;
        }

        private Vector2 _position;
        private Vector2 Position { get { return _position; } }
        private float Rotation { get; set; }
        private float Zoom { get; set; }

        public Matrix GetTransformMatrix() {
            return Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(Zoom) *
                   Matrix.CreateTranslation(Position.X, Position.Y, 0);
        }
    }
}
