using Gengine.EntityComponentSystem;

namespace Gengine.Input {
    public class InputComponent : IComponent {
        public int DirectionX { get; set; }
        public int DirectionY { get; set; }
    }
}
