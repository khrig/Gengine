using Microsoft.Xna.Framework;

namespace Gengine {
    public interface IWorld {
        Rectangle View { get; }
        int WindowWidth { get; }
        int WindowHeight { get; }
    }
}
