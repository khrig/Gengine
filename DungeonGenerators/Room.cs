using System.Collections.Generic;

namespace Gengine.DungeonGenerators {
    public enum RoomType {
        VisitedRoom,
        Current,
        Start,
        UnvisitedRoom,
        Boss,
        NoRoom
    }

    public class Room {
        public Room() {
            Doors = new List<Door>(4);
            Type = RoomType.UnvisitedRoom;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public bool HasDoors { get; set; }
        public RoomType Type { get; set; }

        public bool IsLegitRoom { get { return Id != 0; } }

        public List<Door> Doors { get; set; }

        public void AddDoor(int roomId, DoorPosition doorPosition) {
            Doors.Add(new Door(doorPosition, roomId));
        }
    }
}
