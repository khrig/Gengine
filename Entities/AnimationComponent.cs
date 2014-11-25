using Microsoft.Xna.Framework;

namespace Gengine.Entities {
    public class AnimationComponent : EntityComponent {
        public Rectangle SourceRectangle { get; private set; }

        public AnimationComponent(Rectangle sourceRectangle) {
            SourceRectangle = sourceRectangle;
        }

        public override void Update(float deltaTime) {
            base.Update(deltaTime);
        }
    }
}
