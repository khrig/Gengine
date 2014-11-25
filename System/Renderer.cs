using System.Collections.Generic;
using Gengine.Entities;

namespace Gengine.System {
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
