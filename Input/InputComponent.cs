using System;
using Gengine.EntityComponentSystem;

namespace Gengine.Input {
    [Flags]
    public enum InputKey{
        None = 0,
        Left = 1,
        Right = 2,        
        Up = 4,
        Down = 8,        
        Shoot = 16
    }

    public class InputComponent : IComponent {
        public InputKey Input { get; set; }
    }
}
