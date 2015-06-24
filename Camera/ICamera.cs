using Microsoft.Xna.Framework;

namespace Gengine.Camera {
    public interface ICamera {
        void SetPosition(Vector2 position);
        Matrix GetTransformMatrix();
    }
}
