namespace Gengine.Entities {
    public interface IPickup : ICollidable, IRenderable {
        bool IsPickedUp { get; }
    }
}
