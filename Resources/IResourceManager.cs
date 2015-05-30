using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gengine.Resources {
    public interface IResourceManager {
        Texture2D GetTexture(string textureName);
        SpriteFont GetFont(string fontName);
        void AddTexture(string textureName, Texture2D texture2D);
        void AddFont(string fontName, SpriteFont font);
    }
}
