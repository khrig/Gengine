using System;
using System.Diagnostics;
using Gengine.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine.Utils {
    public class PerformanceCounter {
        private readonly IResourceManager _resourceManager;
        private readonly string _fontName;
        private readonly Vector2 _position;
        private readonly Stopwatch _stopWatchUpdate;
        private readonly Stopwatch _stopWatchRender;
        
        int _frameRate;
        int _frameCounter;
        TimeSpan _elapsedTime = TimeSpan.Zero;

        public PerformanceCounter(IResourceManager resourceManager, string fontName, Vector2 position){
            _resourceManager = resourceManager;
            _fontName = fontName;
            _position = position;
            _stopWatchUpdate = new Stopwatch();
            _stopWatchRender = new Stopwatch();
        }

        public void StartUpdateTimer(){
            _stopWatchUpdate.Reset();
            _stopWatchUpdate.Start();
        }

        public void EndUpdateTimer(GameTime gameTime) {
            _stopWatchUpdate.Stop();

            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime <= TimeSpan.FromSeconds(1)) return;
            _elapsedTime -= TimeSpan.FromSeconds(1);
            _frameRate = _frameCounter;
            _frameCounter = 0;
        }

        public void StartRenderTimer(){
            _stopWatchRender.Reset();
            _stopWatchRender.Start();
        }

        public void EndRenderTimer(){
            _stopWatchRender.Stop();
        }

        public void Render(SpriteBatch spriteBatch){
            _frameCounter++;
            string info = string.Format("fps:   {0:00.0}\nupdate:{1,4:00.0}\n draw:  {2,4:00.0}\n Gc0: {3}\n Gc1: {4}\n Gc2: {5}", _frameRate,
                (float)_stopWatchUpdate.ElapsedTicks / (float)Stopwatch.Frequency * 1000.0f,
                (float)_stopWatchRender.ElapsedTicks / (float)Stopwatch.Frequency * 1000.0f,
                GC.CollectionCount(0),
                GC.CollectionCount(1),
                GC.CollectionCount(2));

            spriteBatch.Begin();
            spriteBatch.DrawString(_resourceManager.GetFont(_fontName), info, _position, Color.White);
            spriteBatch.End();
        }
    }
}
