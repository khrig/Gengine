using Gengine.Entities;

namespace Gengine.Examples
{
    public class PlayerEntity : Entity, IRenderable {
        public PlayerEntity(VisualComponent visual, PositionComponent position, AnimationComponent animation) {
            AddComponent(visual);
            AddComponent(position);
            AddComponent(animation);
        }

        public Texture2D Texture { get { return GetComponent<VisualComponent>().Texture; } }
        public Vector2 Position { get { return GetComponent<PositionComponent>().Position; } }
        public Rectangle SourceRectangle { get { return GetComponent<AnimationComponent>().SourceRectangle; } }
    }
}
