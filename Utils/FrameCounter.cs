using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gengine.Utils {
    public class FrameCounter {
        SpriteFont font;
        int frameRate = 0;
        int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;
        Vector2 position;

        public FrameCounter(SpriteFont font, Vector2 position) {
            this.font = font;
            this.position = position;
        }

        public void Update(GameTime gameTime) {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1)) {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            frameCounter++;
            string fps = string.Format("fps: {0}", frameRate);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, fps, position, Color.White);
            spriteBatch.End();
        }
    }
}
