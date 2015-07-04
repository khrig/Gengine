namespace Gengine.DungeonGenerators {
    public class DoorBuilder {
        public void AddDoors(DungeonMap dungeonMap) {
            for (int y = 0;y < dungeonMap.Height;y++) {
                for (int x = 0;x < dungeonMap.Width;x++) {
                    if (dungeonMap[x, y].Id != 0) {
                        AddDoors(dungeonMap, dungeonMap[x, y]);
                    }
                }
            }
        }

        private void AddDoors(DungeonMap dungeonMap, Room room) {
            if (room.X - 1 >= 0 && dungeonMap[room.X - 1, room.Y].Id != 0) {
                room.HasDoors = true;
                room.AddDoor(dungeonMap[room.X - 1, room.Y].Id, DoorPosition.Left);
            }
            if (room.X + 1 < dungeonMap.Width && dungeonMap[room.X + 1, room.Y].Id != 0) {
                room.HasDoors = true;
                room.AddDoor(dungeonMap[room.X + 1, room.Y].Id, DoorPosition.Right);
            }
            if (room.Y - 1 >= 0 && dungeonMap[room.X, room.Y - 1].Id != 0) {
                room.HasDoors = true;
                room.AddDoor(dungeonMap[room.X, room.Y - 1].Id, DoorPosition.Top);
            }
            if (room.Y + 1 < dungeonMap.Height && dungeonMap[room.X, room.Y + 1].Id != 0) {
                room.HasDoors = true;
                room.AddDoor(dungeonMap[room.X, room.Y + 1].Id, DoorPosition.Bottom);
            }
        }
    }
}
