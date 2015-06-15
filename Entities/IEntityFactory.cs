using Gengine.Map;
using Microsoft.Xna.Framework;

namespace Gengine.Entities{
    public interface IEntityFactory {
        IEntity Create(string name, Vector2 position, TileMap tileMap);
    }
}