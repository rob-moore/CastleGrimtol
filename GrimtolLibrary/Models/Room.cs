using System.Collections.Generic;

namespace GrimtolLibrary.Models
{
    internal class Room
    {
        internal string Name { get; }
        internal string Description { get; }
        internal Dictionary<Exits, Room> RoomExits { get;  }
        internal List<Item> Items { get; }
        internal List<Monster> Monsters { get; }

        internal Room(string name, string desc, Dictionary<Exits, Room> exits, List<Item> item, List<Monster> monsters)
        {
            Name = name;
            Description = desc;
            RoomExits = exits;
            Items = item;
            Monsters = monsters;
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
                new List<Item>(),
                new List<Monster>());

            Kitchen = new Room("Kitchen", 
                "wow this kitchen is really clean!",
                new Dictionary<Exits, Room>(), new List<Item>(), new List<Monster>());
            
            Dungeon = new Room("Dungeon", 
                "the dungeon is also pretty clean nice!",
                new Dictionary<Exits, Room>(), new List<Item>(), new List<Monster>());
            
            Shower = new Room("Shower", 
                "why is there a shower here?",
                new Dictionary<Exits, Room>(), new List<Item>(), new List<Monster>());

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

            #region Setup Monsters
                Kitchen.Monsters.Add(new Monster("Vampire Steve", "He's a nice look vampire.", 10));
           
            #endregion
        }
    }
}