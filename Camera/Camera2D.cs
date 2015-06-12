using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Gengine.Camera
{
    public class Camera2D
    {
        private const float ZoomUpperLimit = 1.5f;
        private const float ZoomLowerLimit = .5f;

        private float _zoom;
        private Matrix _transform;
        private Vector2 _pos;
        private readonly int _viewportWidth;
        private readonly int _viewportHeight;
        private readonly int _worldWidth;
        private readonly int _worldHeight;

        public Camera2D(Viewport viewport, int worldWidth,
           int worldHeight, float initialZoom)
        {
            _zoom = initialZoom;
            Rotation = 0.0f;
            _pos = Vector2.Zero;
            _viewportWidth = viewport.Width;
            _viewportHeight = viewport.Height;
            _worldWidth = worldWidth;
            _worldHeight = worldHeight;
        }

        public float Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                if (_zoom < ZoomLowerLimit)
                    _zoom = ZoomLowerLimit;
                if (_zoom > ZoomUpperLimit)
                    _zoom = ZoomUpperLimit;
            }
        }

        public float Rotation { get; set; }

        public void Move(Vector2 amount)
        {
            _pos += amount;
        }

        public Vector2 Pos
        {
            get { return _pos; }
            set
            {
                float leftBarrier = (float)_viewportWidth *
                       .5f / _zoom;
                float rightBarrier = _worldWidth -
                       (float)_viewportWidth * .5f / _zoom;
                float topBarrier = _worldHeight -
                       (float)_viewportHeight * .5f / _zoom;
                float bottomBarrier = (float)_viewportHeight *
                       .5f / _zoom;
                _pos = value;
                if (_pos.X < leftBarrier)
                    _pos.X = leftBarrier;
                if (_pos.X > rightBarrier)
                    _pos.X = rightBarrier;
                if (_pos.Y > topBarrier)
                    _pos.Y = topBarrier;
                if (_pos.Y < bottomBarrier)
                    _pos.Y = bottomBarrier;
            }
        }

        public Matrix GetTransformation()
        {
            _transform =
               Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
               Matrix.CreateRotationZ(Rotation) *
               Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
               Matrix.CreateTranslation(new Vector3(_viewportWidth * 0.5f,
                   _viewportHeight * 0.5f, 0));

            return _transform;
        }
    }
}
