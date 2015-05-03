using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gengine.Resources {
    public interface IResourceManager {
        Texture2D GetTexture(string textureName);
        void AddTexture(string textureName, Texture2D texture2D);
    }
}
