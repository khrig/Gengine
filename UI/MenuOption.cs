using Gengine.Entities;
using Microsoft.Xna.Framework;

namespace Gengine.UI {
    public class MenuOption : IRenderableText {
        public string Text { get; private set; }
        public Vector2 RenderPosition { get; set; }
        public string FontName { get; set; }
        public Color Color { get; set; }

        public MenuOption(string fontName, string text, Color color, Vector2 position) {
            FontName = fontName;
            Text = text;
            Color = color;
            RenderPosition = position;
        }
    }
}
