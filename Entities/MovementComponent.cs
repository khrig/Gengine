using Microsoft.Xna.Framework;

namespace Gengine.Entities {
    public class MovementComponent : EntityComponent {
        public Vector2 Position { get; private set; }
        private Vector2 _velocity;
        public float Direction { get; set; }
        public bool IsOnGround { get; set; }

        private const float MoveAcceleration = 0.1f;
        private const float MaxMoveSpeed = 0.4f;
        private const float GroundDragFactor = 0.7f;
        private const float Gravity = 0.00581f;

        public MovementComponent(Vector2 position) {
            Position = position;
            _velocity = new Vector2();
        }

        public override void Update(float deltaTime) {
            _velocity.X += Direction * MoveAcceleration * deltaTime;
            _velocity.X = MathHelper.Clamp(_velocity.X, -MaxMoveSpeed, MaxMoveSpeed);
            _velocity.X *= GroundDragFactor;

            if (!IsOnGround)
                _velocity.Y += Gravity;
            else
                _velocity.Y = 0;

            Position += _velocity * deltaTime;
            Direction = 0.0f;
            base.Update(deltaTime);
        }

        public void CorrectPositionAfterCollision(ICollidable target) {
            Position = new Vector2(Position.X, target.BoundingBox.Top - 32);
            IsOnGround = true;
        }
    }
}
