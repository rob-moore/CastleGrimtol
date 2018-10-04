using System.Collections.Generic;

namespace GrimtolLibrary.Models
{
    internal class Room
    {
        internal string Name { get; }
        internal string Description { get; }
        internal Dictionary<Exits, Room> RoomExits { get;  }
        internal List<Item> Items { get; }

        internal Room(string name, string desc, Dictionary<Exits, Room> exits, List<Item> item)
        {
            Name = name;
            Description = desc;
            RoomExits = exits;
            Items = item;
        }

    }

    internal class RoomFactory
    {
        internal Room Entryway { get; private set; }
        internal Room Kitchen { get; private set; }
        internal Room Dungeon { get; private set; }
        internal Room Shower { get; private set; }
        
        internal void SetupRooms()
        {   
             Entryway = new Room(
                "Entryway",
                "it's a spooky entryway",
                new Dictionary<Exits, Room>(),
                new List<Item>());

            Kitchen = new Room("Kitchen", 
                "wow this kitchen is really clean!",
                new Dictionary<Exits, Room>(), null);
            
            Dungeon = new Room("Dungeon", 
                "the dungeon is also pretty clean nice!",
                new Dictionary<Exits, Room>(), null);
            
            Shower = new Room("Shower", 
                "why is there a shower here?",
                new Dictionary<Exits, Room>(), null);

            #region Setup Items
            Entryway.Items.Add(new Item("Sword", "this sword is dope"));
            

            #endregion
            
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