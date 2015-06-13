using System.Collections.Generic;
using Gengine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gengine.Resources;

namespace Gengine.Systems {
    public class RenderingSystem {
        private readonly SpriteBatch _spriteBatch;
        private Texture2D _pointTexture;
        private readonly IResourceManager _resourceManager;
        private readonly RenderTarget2D _renderTarget;
        private readonly int _windowWidth;
        private readonly int _windowHeight;

        public RenderingSystem(IResourceManager resourceManager, SpriteBatch batch, RenderTarget2D renderTarget, int windowWidth, int windowHeight) {
            _spriteBatch = batch;
            _resourceManager = resourceManager;
            _renderTarget = renderTarget;
            _windowWidth = windowWidth;
            _windowHeight = windowHeight;
        }

        public void DrawWithRenderTarget(IEnumerable<IRenderable> renderables, IEnumerable<IRenderableText> texts, Matrix? transformMatrix, Color color) {
            // Set the device to the render target
            _spriteBatch.GraphicsDevice.SetRenderTarget(_renderTarget);
            _spriteBatch.GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, transformMatrix);
            Draw(renderables);
            Draw(texts);
            _spriteBatch.End();

            // Reset the device to the back buffer
            _spriteBatch.GraphicsDevice.SetRenderTarget(null);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            _spriteBatch.Draw(_renderTarget, new Rectangle(0, 0, _windowWidth, _windowHeight), color);
            _spriteBatch.End();
        }

        private void Draw(IEnumerable<IRenderable> list) {
            foreach (IRenderable renderable in list) {
                DrawSprite(renderable);
            }
        }

        private void Draw(IEnumerable<IRenderableText> list) {
            foreach (IRenderableText renderable in list) {
                DrawText(renderable);
            }
        }

        private void DrawText(IRenderableText renderTarget) {
            _spriteBatch.DrawString(_resourceManager.GetFont(renderTarget.FontName), renderTarget.Text, renderTarget.RenderPosition, renderTarget.Color);
        }

        private void DrawSprite(IRenderable renderTarget) {
            _spriteBatch.Draw(
                _resourceManager.GetTexture(renderTarget.TextureName),
                new Vector2((int)renderTarget.RenderPosition.X, (int)renderTarget.RenderPosition.Y),
                renderTarget.SourceRectangle,
                Color.White);
            
            // DEBUG
            DrawRectangle(_spriteBatch, new Rectangle((int)renderTarget.RenderPosition.X, (int)renderTarget.RenderPosition.Y, renderTarget.SourceRectangle.Width, renderTarget.SourceRectangle.Height), 1, Color.Red);
        }

        private void DrawRectangle(SpriteBatch batch, Rectangle area, int width, Color color) {
            if(_pointTexture == null) {
                _pointTexture = new Texture2D(_spriteBatch.GraphicsDevice, 1, 1);
                _pointTexture.SetData(new[] { Color.Red });
            }

            batch.Draw(_pointTexture, new Rectangle(area.X, area.Y, area.Width, width), color);
            batch.Draw(_pointTexture, new Rectangle(area.X, area.Y, width, area.Height), color);
            batch.Draw(_pointTexture, new Rectangle(area.X + area.Width - width, area.Y, width, area.Height), color);
            batch.Draw(_pointTexture, new Rectangle(area.X, area.Y + area.Height - width, area.Width, width), color);
        }

    }
}
