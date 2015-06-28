namespace Gengine.CollisionDetection {
    public interface ICollisionHandler : ICollidable {
        void Collide(ICollidable target);
    }
}
