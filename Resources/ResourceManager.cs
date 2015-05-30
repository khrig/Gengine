using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gengine.Resources {
    public class ResourceManager : IResourceManager {
        private readonly Dictionary<string, Texture2D> _textures;
        private readonly Dictionary<string, SpriteFont> _fonts;

        public ResourceManager() {
            _textures = new Dictionary<string, Texture2D>();
            _fonts = new Dictionary<string, SpriteFont>();
        }

        public Texture2D GetTexture(string textureName) {
            return _textures[textureName];
        }

        public void AddTexture(string textureName, Texture2D texture) {
            _textures.Add(textureName, texture);
        }

        public SpriteFont GetFont(string fontName) {
            return _fonts[fontName];
        }

        public void AddFont(string fontName, SpriteFont font) {
            _fonts.Add(fontName, font);
        }
    }
}
