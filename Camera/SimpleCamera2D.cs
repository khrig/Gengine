using System;
using Microsoft.Xna.Framework;

namespace Gengine.Camera {
    public class SimpleCamera2D : ICamera {
        private readonly float _worldWidth;
        private readonly float _worldHeight;
        private const float ZoomUpperLimit = 1.5f;
        private const float ZoomLowerLimit = .5f;
        private float _zoom;

        public SimpleCamera2D(float worldWidth, float worldHeight) {
            _worldWidth = worldWidth;
            _worldHeight = worldHeight;
            _position = Vector2.Zero;
            _zoom = 1f;
        }

        public void SetPosition(Vector2 position) {
            _position.X = -(position.X - _worldWidth / 2);
            _position.Y = -(position.Y - _worldHeight / 2);
            if (_position.Y < 0)
                _position.Y = 0;
            if (_position.Y > 0)
                _position.Y = 0;
            if (_position.X > 0)
                _position.X = 0;
            if (_position.X < -_worldWidth)
                _position.X = -_worldWidth;
        }

        private Vector2 _position;
        private Vector2 Position { get { return _position; } }
        public float Rotation { get; set; }

        public float Zoom {
            get { return _zoom; }
            set {
                throw new NotImplementedException("Zoom not implemented, should check from Camera2D");
                _zoom = value;
                if (_zoom < ZoomLowerLimit)
                    _zoom = ZoomLowerLimit;
                if (_zoom > ZoomUpperLimit)
                    _zoom = ZoomUpperLimit;
            }
        }

        public Matrix GetTransformMatrix() {
            return Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(Zoom) *
                   Matrix.CreateTranslation(Position.X, Position.Y, 0);
        }
    }
}
