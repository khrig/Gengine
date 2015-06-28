using Gengine.Rendering;
using Microsoft.Xna.Framework;

namespace Gengine.UI {
    public class MenuOption : IRenderableText {
        public MenuOption(string fontName, string text, Color color, Vector2 position) {
            FontName = fontName;
            Text = text;
            Color = color;
            RenderPosition = position;
        }

        public string Text { get; private set; }
        public Vector2 RenderPosition { get; set; }
        public string FontName { get; set; }
        public Color Color { get; set; }
    }
}
