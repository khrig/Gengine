using Gengine.EntityComponentSystem;

namespace Gengine.Components {
    public class InputComponent : IComponent {
        public int DirectionX { get; set; }
        public int DirectionY { get; set; }
    }
}
