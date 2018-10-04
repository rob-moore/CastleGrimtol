using System.Collections.Generic;

namespace GrimtolLibrary.Models
{
    internal class Room
    {
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal Dictionary<Exits, Room> RoomExits { get; set; }
        internal Item Items { get; set; }

        internal Room(string name, string desc, Dictionary<Exits, Room> exits, Item item)
        {
            Name = name;
            Description = desc;
            RoomExits = exits;
            Items = item;
        }

    }

    internal class RoomFactory
    {
        internal Room Entryway { get; set; }
        internal Room Kitchen { get; set; }
        internal Room Dungeon { get; set; }
        internal Room Shower { get; set; }
        
        internal void SetupRooms()
        {   
             Entryway = new Room(
                "Entryway",
                "it's a spooky entryway",
                new Dictionary<Exits, Room>(),
                new Item("Cool Sword", "this sword is freaking dope"));

            Kitchen = new Room("Entryway", 
                "wow this kitchen is really clean!",
                new Dictionary<Exits, Room>(), null);
            
            Dungeon = new Room("Entryway", 
                "the dungeon is also pretty clean nice!",
                new Dictionary<Exits, Room>(), null);
            
            Shower = new Room("Entryway", 
                "why is there a shower here?",
                new Dictionary<Exits, Room>(), null);

            #region Setup Exits
            Entryway.RoomExits.Add(Exits.West, Kitchen);

            Kitchen.RoomExits.Add(Exits.East, Entryway);
            Kitchen.RoomExits.Add(Exits.North, Dungeon);
            
            Dungeon.RoomExits.Add(Exits.South, Kitchen);
            Dungeon.RoomExits.Add(Exits.Down, Shower);
            
            Shower.RoomExits.Add(Exits.Up, Dungeon);
            #endregion
           
        }
    }
}