using System.Collections.Generic;
using Gengine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine.Systems {
    public class Renderer {
        private readonly SpriteBatch spriteBatch;

        public Renderer(SpriteBatch batch) {
            this.spriteBatch = batch;
        }

        public void Draw(IEnumerable<IRenderable> list) {
            foreach (IRenderable renderable in list) {
                spriteBatch.Draw(
                    renderable.Texture,
                    renderable.Position,
                    renderable.SourceRectangle,
                    Color.White);
            }
        }
    }
}
