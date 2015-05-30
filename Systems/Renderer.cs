using System.Collections.Generic;
using Gengine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gengine.Resources;
using System;

namespace Gengine.Systems {
    public class RenderingSystem {
        private readonly SpriteBatch spriteBatch;
        private Texture2D pointTexture;
        private IResourceManager _resourceManager;
        private RenderTarget2D _renderTarget;
        private int _windowWidth;
        private int _windowHeight;

        public RenderingSystem(IResourceManager resourceManager, SpriteBatch batch, RenderTarget2D renderTarget, int windowWidth, int windowHeight) {
            this.spriteBatch = batch;
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
            spriteBatch.DrawString(_resourceManager.GetFont(renderTarget.FontName), renderTarget.Text, renderTarget.RenderPosition, renderTarget.Color);
        }

        private void DrawSprite(IRenderable renderTarget) {
            spriteBatch.Draw(
                _resourceManager.GetTexture(renderTarget.TextureName),
                new Vector2((int)renderTarget.RenderPosition.X, (int)renderTarget.RenderPosition.Y),
                renderTarget.SourceRectangle,
                Color.White);
            // DEBUG
            DrawRectangle(spriteBatch, new Rectangle((int)renderTarget.RenderPosition.X, (int)renderTarget.RenderPosition.Y, renderTarget.SourceRectangle.Width, renderTarget.SourceRectangle.Height), 1, Color.Red);
        }

        public void Draw(IEnumerable<IRenderable> list) {
            foreach(IRenderable renderable in list) {
                Draw(renderable);
            }
        }

        public void DrawRectangle(SpriteBatch batch, Rectangle area, int width, Color color) {
            if(pointTexture == null) {
                pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                pointTexture.SetData<Color>(new Color[] { Color.Red });
            }

            batch.Draw(pointTexture, new Rectangle(area.X, area.Y, area.Width, width), color);
            batch.Draw(pointTexture, new Rectangle(area.X, area.Y, width, area.Height), color);
            batch.Draw(pointTexture, new Rectangle(area.X + area.Width - width, area.Y, width, area.Height), color);
            batch.Draw(pointTexture, new Rectangle(area.X, area.Y + area.Height - width, area.Width, width), color);
        }

        public void DrawWithRenderTarget(GraphicsDeviceManager graphics, IEnumerable<IRenderable> targets) {
            // Set the device to the render target
            graphics.GraphicsDevice.SetRenderTarget(_renderTarget);
            graphics.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            //stateManager.Draw(spriteBatch);
            Draw(targets);
            spriteBatch.End();

            // Reset the device to the back buffer
            graphics.GraphicsDevice.SetRenderTarget(null);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            spriteBatch.Draw((Texture2D)_renderTarget, new Rectangle(0, 0, _windowWidth, _windowHeight), Color.White);
            spriteBatch.End();
        }
    }
}
