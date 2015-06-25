namespace Gengine.Entities {
    public interface ICollisionHandler : ICollidable {
        void Collide(ICollidable target);
    }
}
