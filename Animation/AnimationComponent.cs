using System.Collections.Generic;
using Gengine.EntityComponentSystem;

namespace Gengine.Animation {
    public class AnimationComponent : IComponent {
        public AnimationComponent(Dictionary<string, Animation> animations){
            Animations = animations;
        }

        public string CurrentAnimationId { get; set; }
        public Dictionary<string, Animation> Animations { get; set; }
        public float Elapsed { get; set; }
    }
}
