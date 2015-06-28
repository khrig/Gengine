using Microsoft.Xna.Framework;

namespace Gengine.Rendering{
    public interface IRenderableText {
        string FontName { get; }
        string Text { get; }
        Vector2 RenderPosition { get; }
        Color Color { get; }
    }
}