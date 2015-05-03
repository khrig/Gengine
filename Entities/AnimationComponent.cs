using Microsoft.Xna.Framework;

namespace Gengine.Entities {
    public class AnimationComponent : EntityComponent {
        public Rectangle SourceRectangle { get; private set; }

        public AnimationComponent(string textureName, Rectangle sourceRectangle) {
            TextureName = textureName;
            SourceRectangle = sourceRectangle;
        }

        public override void Update(float deltaTime) {
            base.Update(deltaTime);
        }

        public string TextureName { get; set; }
    }
}
