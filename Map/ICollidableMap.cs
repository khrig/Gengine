namespace Gengine.Map {
    public interface ICollidableMap {
        int TileSize { get; }
        Tile Tile(int x, int y);
        void ClearDebug();
    }
}
