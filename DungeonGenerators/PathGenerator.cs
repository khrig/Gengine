using System;
using System.Collections.Generic;
using System.Linq;

namespace Gengine.DungeonGenerators {
    public class PathGenerator {
        private readonly Random _rand;

        public PathGenerator() {
            _rand = new Random();
        }

        public void GeneratePathToEnd(DungeonMap dungeonMap, int maxIterations) {
            GeneratePathToEnd(dungeonMap, maxIterations, dungeonMap[dungeonMap.StartX, dungeonMap.StartY]);
        }

        public void GeneratePathToEnd(DungeonMap dungeonMap, int maxIterations, Room startRoom) {
            Room room = startRoom;

            int counter = 2;
            int iteration = 0;
            while (iteration < maxIterations) {
                IEnumerable<Room> neighbours = dungeonMap.GetNeighbours(room);
                if (neighbours.Any(n => n.X == dungeonMap.EndX && n.Y == dungeonMap.EndY)) {
                    room.Id = 99;
                    dungeonMap.ReachedEnd = true;
                    break;
                }
                foreach (Room neighbour in neighbours.OrderBy(x => _rand.Next())) {
                    if (neighbour.Id == 0 && dungeonMap.CountNeighbours(neighbour) == 1) {
                        neighbour.Id = counter;
                        room = neighbour;
                        counter++;
                        break;
                    }
                }
                iteration++;
            }
            dungeonMap.RoomsInPath = counter - 2;
        }
    }
}
