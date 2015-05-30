using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Gengine.Resources;

namespace Gengine.Utils {
    public class FrameCounter {
        int _frameRate;
        int _frameCounter;
        TimeSpan _elapsedTime = TimeSpan.Zero;
        private readonly IResourceManager _resourceManager;
        private readonly string _fontName;
        readonly Vector2 _position;

        public FrameCounter(IResourceManager resourceManager, string fontName, Vector2 position) {
            _resourceManager = resourceManager;
            _fontName = fontName;
            _position = position;
        }

        public void Update(GameTime gameTime) {
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime <= TimeSpan.FromSeconds(1)) return;
            _elapsedTime -= TimeSpan.FromSeconds(1);
            _frameRate = _frameCounter;
            _frameCounter = 0;
        }

        public void Draw(SpriteBatch spriteBatch) {
            _frameCounter++;
            var fps = string.Format("fps: {0}", _frameRate);
            spriteBatch.Begin();
            spriteBatch.DrawString(_resourceManager.GetFont(_fontName), fps, _position, Color.White);
            spriteBatch.End();
        }
    }
}
