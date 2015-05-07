using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gengine.Entities {
    public interface IRenderable {
        string TextureName { get; }
        Vector2 RenderPosition { get; }
        Rectangle SourceRectangle { get; }
    }
}
