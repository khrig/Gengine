using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine.Entities {
    public enum RenderType
    {
        Sprite,
        Text
    }

    public interface IRenderable {
        RenderType Type { get; }
        string TextureName { get; }
        Vector2 RenderPosition { get; }
        Rectangle SourceRectangle { get; }
        string FontName { get; }
    }
}
