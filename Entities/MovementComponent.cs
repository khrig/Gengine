using Microsoft.Xna.Framework;

namespace Gengine.Entities {
    public class MovementComponent : EntityComponent {
        public Vector2 Position { get; private set; }
        private Vector2 velocity;
        public float Direction { get; set; }

        private const float MoveAcceleration = 0.1f;
        private const float MaxMoveSpeed = 0.4f;
        private const float GroundDragFactor = 0.7f;

        public MovementComponent(Vector2 position) {
            Position = position;
            velocity = new Vector2();
        }

        public override void Update(float deltaTime) {
            velocity.X += Direction * MoveAcceleration * deltaTime;
            velocity.X = MathHelper.Clamp(velocity.X, -MaxMoveSpeed, MaxMoveSpeed);
            velocity.X *= GroundDragFactor;

            Position += velocity*deltaTime;
            Direction = 0.0f;
            base.Update(deltaTime);
        }
    }
}
