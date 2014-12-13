using Microsoft.Xna.Framework;

namespace Gengine {
    public class TwoDWorld : IWorld {
        public Rectangle View { get; private set; }

        public TwoDWorld(int width, int height) {
            View = new Rectangle(0, 0, width, height);
        }
    }
}
