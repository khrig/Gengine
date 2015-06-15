using Microsoft.Xna.Framework;

namespace Gengine.Background {
    public class ParallaxBackgroundTile : IBackgroundTile {
        private readonly Vector2 _speed;
        private readonly Rectangle _sourceRectangle;

        public string TextureName { get; private set; }

        private Vector2 _renderPosition;
        public Vector2 RenderPosition { get { return _renderPosition; } }

        public Rectangle SourceRectangle {
            get { return _sourceRectangle; }
        }

        public ParallaxBackgroundTile(string textureName, Vector2 renderPosition, Rectangle sourceRectangle, Vector2 speed) {
            _speed = speed;
            TextureName = textureName;
            _renderPosition = renderPosition;
            _sourceRectangle = sourceRectangle;
        }

        public void Update(float dt, Vector2 direction) {
            //Calculate the distance to move our image, based on speed
            var distance = direction * _speed * dt;
            
            _renderPosition -= distance;
            _renderPosition.X = _renderPosition.X < 0 ? 0 : _renderPosition.X;
            _renderPosition.Y = _renderPosition.Y < 0 ? 0 : _renderPosition.Y;
        }
    }
}
