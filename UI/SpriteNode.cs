using Gengine.Rendering;
using Microsoft.Xna.Framework;

namespace Gengine.UI {
    public class SpriteNode : IRenderable {
        public SpriteNode(string textureName, Vector2 renderPosition, Rectangle sourceRectangle){
            TextureName = textureName;
            RenderPosition = renderPosition;
            SourceRectangle = sourceRectangle;
        }

        public string TextureName { get; private set; }
        public Vector2 RenderPosition { get; private set; }
        public Rectangle SourceRectangle { get; private set; }
        public bool DebugDraw { get; set; }
    }
}
