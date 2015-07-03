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

        public Map CreateDungeon(int width, int height) {
            Map map;
            while (true){
                map = CreateStartDungeon(width, height);
                _pathGenerator.GeneratePathToEnd(map, 60);
                if (map.ReachedEnd && map.RoomsInPath < 25)
                    break;
            }

            AddSideRooms(map);
            _doorBuilder.AddDoors(map);
            RemoveUnconnectedRooms(map);
            return map;
        }

        private Map CreateStartDungeon(int width, int height) {
            var map = new Map(width, height);
            map.SetEnd(6, 5);
            map.SetRandomCornerStart(0);
            return map;
        }

        private Map CreateRandomStartDungeon(int width, int height) {
            var map = new Map(width, height);
            map.SetEnd(6, 5);
            map.SetRandomCornerStart(_rand.Next(4));
            return map;
        }

        private void AddSideRooms(Map map){
            AddSideRooms(map, 70);
        }

        private void AddSideRooms(Map map, int probability) {
            for (int y = 0;y < map.Height;y++) {
                for (int x = 0;x < map.Width;x++) {
                    if (map[x, y].Id == 0 && _rand.Next(100) < probability)
                        map[x, y].Id = _sideRoomId++;
                }
            }
        }

        private void RemoveUnconnectedRooms(Map map) {
            for (int y = 0; y < map.Height; y++) {
                for (int x = 0; x < map.Width; x++) {
                    if (map.CountNeighbours(map[x, y]) == 0)
                        map[x, y] = new Room { X = x, Y = y, Type = RoomType.NoRoom};
                    else if (RoomHasOnlySideRoomConnections(map, map[x, y]))
                        map[x, y] = new Room { X = x, Y = y, Type = RoomType.NoRoom };
                }
            }
        }

        private bool RoomHasOnlySideRoomConnections(Map map, Room room) {
            var neighbours = map.GetNeighbours(room);
            if (room.Id == 88 && neighbours.All(n => n.Id == 88 || n.Id == 0))
                return true;

            return false;
        }
    }
}
