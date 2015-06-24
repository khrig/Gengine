using Gengine.Resources;
using Microsoft.Xna.Framework;

namespace Gengine.Utils {
    public class TextExtensions {
        private static IResourceManager _resourceManager;
        public static void AddResourceManager(IResourceManager resourceManager){
            _resourceManager = resourceManager;
        }

        public static Vector2 GetContentLength(string fontName, string content) {
            return _resourceManager.GetFont(fontName).MeasureString(content);
        }
    }
}
