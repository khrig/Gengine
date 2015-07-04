namespace Gengine.DungeonGenerators {
    public interface IDungeonGenerator{
        DungeonMap CreateDungeon(int width, int height);
    }
}
