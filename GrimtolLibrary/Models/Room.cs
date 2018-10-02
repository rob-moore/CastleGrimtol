using System;
using System.Collections.Generic;

namespace GrimtolLibrary.Models
{
    public class Room
    {
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal List<Tuple<Exits, Room>> RoomExits { get; set; }

        public Room(string name, string desc, List<Tuple<Exits, Room>> exits)
        {
            Name = name;
            Description = desc;
            RoomExits = exits;
        }
    }

    public class RoomFactory
    {
        public Room CurrentRoom { get; set; }


        public void CreateRoom(string roomName)
        {
            var Kitchen = new Room("Entryway", "it's a spooky entryway",
                new List<Tuple<Exits, Room>>(Exits.West, Entryway));
            
            var Entryway = new Room(
                "Entryway",
                "it's a spooky entryway",
                new List<Tuple<Exits, Room>>(Exits.East, Kitchen)
            );

            var Dungeon = new Room("Entryway", "it's a spooky entryway", Exits.East);
            
            var Shower = new Room("Entryway", "it's a spooky entryway", Exits.East);
            switch (roomName)
            {
                case "entryway":
                    CurrentRoom = Entryway;
                    break;
                case "kitchen":
                    CurrentRoom = Kitchen;
                    break;
                case "Dungeon":
                    CurrentRoom = Dungeon;
                    break;
                case "Shower":
                    CurrentRoom = Shower;
                    break;
            }
        }
    }
}