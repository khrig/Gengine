using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gengine.Resources {
    public class ResourceManager : IResourceManager {
        private readonly Dictionary<string, Texture2D> textures;

        public ResourceManager() {
            textures = new Dictionary<string, Texture2D>();
        }

        public Texture2D GetTexture(string textureName) {
            return textures[textureName];
        }

        public void AddTexture(string textureName, Texture2D texture) {
            textures.Add(textureName, texture);
        }
    }
}
