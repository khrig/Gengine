using Microsoft.Xna.Framework;

namespace Gengine.Entities
{
    public class PositionComponent : EntityComponent {
        public Vector2 Position { get; private set; }

        public PositionComponent(Vector2 position) {
            Position = position;
        }

        public override void Update(float deltaTime) {
            base.Update(deltaTime);
        }
    }
}
