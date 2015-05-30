using System.Collections.Generic;
using Gengine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gengine.Resources;
using System;

namespace Gengine.Systems {
    public class RenderingSystem {
        private readonly SpriteBatch _spriteBatch;
        private Texture2D pointTexture;
        private IResourceManager _resourceManager;
        private RenderTarget2D _renderTarget;
        private int _windowWidth;
        private int _windowHeight;

        public RenderingSystem(IResourceManager resourceManager, SpriteBatch batch, RenderTarget2D renderTarget, int windowWidth, int windowHeight) {
            _spriteBatch = batch;
            _resourceManager = resourceManager;
            _renderTarget = renderTarget;
            _windowWidth = windowWidth;
            _windowHeight = windowHeight;
        }

        public void Draw(IRenderable renderTarget) {
            switch(renderTarget.Type) {
                case RenderType.Sprite: {
                        DrawSprite(renderTarget);
                        break;
                    }
                case RenderType.Text: {
                        DrawText(renderTarget);
                        break;
                    }
                default:
                    throw new ArgumentException(renderTarget.Type.ToString());
            }
        }

        private void DrawText(IRenderable renderTarget) {
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

        public void Draw(IEnumerable<IRenderable> list) {
            foreach(IRenderable renderable in list) {
                Draw(renderable);
            }
        }

        public void DrawRectangle(SpriteBatch batch, Rectangle area, int width, Color color) {
            if(pointTexture == null) {
                pointTexture = new Texture2D(_spriteBatch.GraphicsDevice, 1, 1);
                pointTexture.SetData<Color>(new Color[] { Color.Red });
            }

            batch.Draw(pointTexture, new Rectangle(area.X, area.Y, area.Width, width), color);
            batch.Draw(pointTexture, new Rectangle(area.X, area.Y, width, area.Height), color);
            batch.Draw(pointTexture, new Rectangle(area.X + area.Width - width, area.Y, width, area.Height), color);
            batch.Draw(pointTexture, new Rectangle(area.X, area.Y + area.Height - width, area.Width, width), color);
        }

        public void DrawWithRenderTarget(IEnumerable<IRenderable> targets, Matrix? transformMatrix) {
            // Set the device to the render target
            _spriteBatch.GraphicsDevice.SetRenderTarget(_renderTarget);
            _spriteBatch.GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, transformMatrix);
            //stateManager.Draw(spriteBatch);
            Draw(targets);
            _spriteBatch.End();

            // Reset the device to the back buffer
            _spriteBatch.GraphicsDevice.SetRenderTarget(null);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            _spriteBatch.Draw((Texture2D)_renderTarget, new Rectangle(0, 0, _windowWidth, _windowHeight), Color.White);
            _spriteBatch.End();
        }
    }
}
