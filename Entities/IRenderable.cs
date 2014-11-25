using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gengine.Entities {
    public interface IRenderable {
        Texture2D Texture { get; }
        Vector2 Position { get; }
        Rectangle SourceRectangle { get; }
    }
}
