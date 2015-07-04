using System;
using System.Linq;

namespace Gengine.DungeonGenerators {
    public class CornerToMidGenerator : IDungeonGenerator {
        private readonly Random _rand;
        private readonly PathGenerator _pathGenerator;
        private readonly DoorBuilder _doorBuilder;
        private int _sideRoomId = 100;

        public CornerToMidGenerator() {
            _rand = new Random();
            _pathGenerator = new PathGenerator();
            _doorBuilder = new DoorBuilder();
        }

        public DungeonMap CreateDungeon(int width, int height) {
            DungeonMap dungeonMap;
            while (true){
                dungeonMap = CreateStartDungeon(width, height);
                _pathGenerator.GeneratePathToEnd(dungeonMap, 60);
                if (dungeonMap.ReachedEnd && dungeonMap.RoomsInPath < 25)
                    break;
            }

            AddSideRooms(dungeonMap);
            _doorBuilder.AddDoors(dungeonMap);
            RemoveUnconnectedRooms(dungeonMap);
            return dungeonMap;
        }

        private DungeonMap CreateStartDungeon(int width, int height) {
            var map = new DungeonMap(width, height);
            map.SetEnd(6, 5);
            map.SetRandomCornerStart(0);
            return map;
        }

        private DungeonMap CreateRandomStartDungeon(int width, int height) {
            var map = new DungeonMap(width, height);
            map.SetEnd(6, 5);
            map.SetRandomCornerStart(_rand.Next(4));
            return map;
        }

        private void AddSideRooms(DungeonMap dungeonMap){
            AddSideRooms(dungeonMap, 70);
        }

        private void AddSideRooms(DungeonMap dungeonMap, int probability) {
            for (int y = 0;y < dungeonMap.Height;y++) {
                for (int x = 0;x < dungeonMap.Width;x++) {
                    if (dungeonMap[x, y].Id == 0 && _rand.Next(100) < probability)
                        dungeonMap[x, y].Id = _sideRoomId++;
                }
            }
        }

        private void RemoveUnconnectedRooms(DungeonMap dungeonMap) {
            for (int y = 0; y < dungeonMap.Height; y++) {
                for (int x = 0; x < dungeonMap.Width; x++) {
                    if (dungeonMap.CountNeighbours(dungeonMap[x, y]) == 0)
                        dungeonMap[x, y] = new Room { X = x, Y = y, Type = RoomType.NoRoom};
                    else if (RoomHasOnlySideRoomConnections(dungeonMap, dungeonMap[x, y]))
                        dungeonMap[x, y] = new Room { X = x, Y = y, Type = RoomType.NoRoom };
                }
            }
        }

        private bool RoomHasOnlySideRoomConnections(DungeonMap dungeonMap, Room room) {
            var neighbours = dungeonMap.GetNeighbours(room);
            if (room.Id == 88 && neighbours.All(n => n.Id == 88 || n.Id == 0))
                return true;

            return false;
        }
    }
}
