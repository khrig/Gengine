using Microsoft.Xna.Framework;

namespace Gengine.Entities {
    public class MovementComponent : EntityComponent {
        public Vector2 Position { get; private set; }
        private Vector2 velocity;
        public float Direction { get; set; }
        public bool IsOnGround { get; set; }

        private const float MoveAcceleration = 0.1f;
        private const float MaxMoveSpeed = 0.4f;
        private const float GroundDragFactor = 0.7f;
        private const float Gravity = 0.00581f;

        public MovementComponent(Vector2 position) {
            Position = position;
            velocity = new Vector2();
        }

        public override void Update(float deltaTime) {
            velocity.X += Direction * MoveAcceleration * deltaTime;
            velocity.X = MathHelper.Clamp(velocity.X, -MaxMoveSpeed, MaxMoveSpeed);
            velocity.X *= GroundDragFactor;

            if (!IsOnGround)
                velocity.Y += Gravity;
            else
                velocity.Y = 0;

            Position += velocity*deltaTime;
            Direction = 0.0f;
            base.Update(deltaTime);
        }

        public void CorrectPositionAfterCollision(ICollidable target) {
            Position = new Vector2(Position.X, target.BoundingBox.Top - target.BoundingBox.Height);
        }
    }
}
