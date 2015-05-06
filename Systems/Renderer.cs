using System.Collections.Generic;
using Gengine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gengine.Resources;

namespace Gengine.Systems {
    public class RenderingSystem {
        private readonly SpriteBatch spriteBatch;
        private Texture2D pointTexture;
        private IResourceManager _resourceManager;

        public RenderingSystem(IResourceManager resourceManager, SpriteBatch batch) {
            this.spriteBatch = batch;
            _resourceManager = resourceManager;
        }

        public void Draw(IEnumerable<IRenderable> list) {
            foreach (IRenderable renderable in list) {
                spriteBatch.Draw(
                    _resourceManager.GetTexture(renderable.TextureName),
                    renderable.Position,
                    renderable.SourceRectangle,
                    Color.White);

                // DEBUG
                //DrawRectangle(spriteBatch, new Rectangle((int)renderable.Position.X, (int)renderable.Position.Y, renderable.SourceRectangle.Width, renderable.SourceRectangle.Height), 1, Color.Red);
            }
        }

        public void DrawRectangle(SpriteBatch batch, Rectangle area, int width, Color color) {
            if (pointTexture == null) {
                pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                pointTexture.SetData<Color>(new Color[] { Color.Red });
            }

            batch.Draw(pointTexture, new Rectangle(area.X, area.Y, area.Width, width), color);
            batch.Draw(pointTexture, new Rectangle(area.X, area.Y, width, area.Height), color);
            batch.Draw(pointTexture, new Rectangle(area.X + area.Width - width, area.Y, width, area.Height), color);
            batch.Draw(pointTexture, new Rectangle(area.X, area.Y + area.Height - width, area.Width, width), color);
        }
    }
}
