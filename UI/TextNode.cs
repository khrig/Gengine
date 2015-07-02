using Gengine.Rendering;
using Microsoft.Xna.Framework;

namespace Gengine.UI {
    public class TextNode : IRenderableText {
        public TextNode(string fontName, string text, Vector2 renderPosition, Color color){
            FontName = fontName;
            Text = text;
            RenderPosition = renderPosition;
            Color = color;
        }

        public string FontName { get; private set; }
        public string Text { get; set; }
        public Vector2 RenderPosition { get; set; }
        public Color Color { get; private set; }
    }
}
