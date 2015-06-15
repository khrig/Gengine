using Microsoft.Xna.Framework;

namespace Gengine.Background{
    public class BackgroundTile : IBackgroundTile {
        public string TextureName { get; private set; }
        public Vector2 RenderPosition { get; private set; }
        public Rectangle SourceRectangle { get; private set; }

        public BackgroundTile(string textureName, Vector2 renderPosition, Rectangle sourceRectangle) {
            TextureName = textureName;
            RenderPosition = renderPosition;
            SourceRectangle = sourceRectangle;
        }

        public void Update(float dt, Vector2 direction) {
        }
    }
}