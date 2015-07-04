using System.Collections.Generic;

namespace Gengine.DungeonGenerators {
    public static class DungeonMapExtensions {
        public static int CountNeighbours(this DungeonMap dungeonMap, Room room) {
            int neighbourCount = 0;
            // left
            if (room.X - 1 >= 0 && dungeonMap[room.X - 1, room.Y].Id != 0)
                neighbourCount++;
            // right
            if (room.X + 1 < dungeonMap.Width && dungeonMap[room.X + 1, room.Y].Id != 0)
                neighbourCount++;
            // top
            if (room.Y - 1 >= 0 && dungeonMap[room.X, room.Y - 1].Id != 0)
                neighbourCount++;
            // bottom
            if (room.Y + 1 < dungeonMap.Height && dungeonMap[room.X, room.Y + 1].Id != 0)
                neighbourCount++;
            return neighbourCount;
        }

        public static IEnumerable<Room> GetNeighbours(this DungeonMap dungeonMap, Room room) {
            List<Room> neighbours = new List<Room>();
            // left
            if (room.X - 1 >= 0)
                neighbours.Add(dungeonMap[room.X - 1, room.Y]);
            // right
            if (room.X + 1 < dungeonMap.Width)
                neighbours.Add(dungeonMap[room.X + 1, room.Y]);
            // top
            if (room.Y - 1 >= 0)
                neighbours.Add(dungeonMap[room.X, room.Y - 1]);
            // bottom
            if (room.Y + 1 < dungeonMap.Height)
                neighbours.Add(dungeonMap[room.X, room.Y + 1]);
            return neighbours;
        }

        public static void SetRandomCornerStart(this DungeonMap dungeonMap, int corner) {
            switch (corner) {
                case 0:
                    dungeonMap.StartX = 0;
                    dungeonMap.StartY = 0;
                    break;
                case 1:
                    dungeonMap.StartX = dungeonMap.Width - 1;
                    dungeonMap.StartY = 0;
                    break;
                case 2:
                    dungeonMap.StartX = 0;
                    dungeonMap.StartY = dungeonMap.Height - 1;
                    break;
                case 3:
                    dungeonMap.StartX = dungeonMap.Width - 1;
                    dungeonMap.StartY = dungeonMap.Height - 1;
                    break;
            }
            dungeonMap[dungeonMap.StartX, dungeonMap.StartY].Id = 1;
        }
    }
}
