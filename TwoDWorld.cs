using Microsoft.Xna.Framework;

namespace Gengine {
    public class TwoDWorld : IWorld {
        public Rectangle View { get; private set; }
        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        public TwoDWorld(int width, int height, int windowWidth, int windowHeight) {
            View = new Rectangle(0, 0, width, height);
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
        }

    }
}
