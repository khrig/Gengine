namespace Gengine.Entities {
    public interface ICollidable {
        void Collide(ICollidable target);
        Rectangle BoundingBox { get; }
    }
}
