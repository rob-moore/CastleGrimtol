using System.Collections.Generic;
using GrimtolLibrary.Interfaces;

namespace GrimtolLibrary.Models
{
    internal class Room : IRoom
    {
        public string Name { get; }
        public string Description { get; }
        public Dictionary<Exits, IRoom> RoomExits { get; }
        public List<IItem> Items { get; }
        public List<IMonster> Monsters { get; }

        internal Room(string name, string desc, Dictionary<Exits, IRoom> exits, List<IItem> item,
            List<IMonster> monsters)
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
                new Dictionary<Exits, IRoom>(),
                new List<IItem>(),
                new List<IMonster>());

            Kitchen = new Room("Kitchen",
                "wow this kitchen is really clean!",
                new Dictionary<Exits, IRoom>(), new List<IItem>(), new List<IMonster>());

            Dungeon = new Room("Dungeon",
                "the dungeon is also pretty clean nice!",
                new Dictionary<Exits, IRoom>(), new List<IItem>(), new List<IMonster>());

            Shower = new Room("Shower",
                "why is there a shower here?",
                new Dictionary<Exits, IRoom>(), new List<IItem>(), new List<IMonster>());

            #region Setup Items

            Entryway.Items.Add(new Item("Sword", "This sword is dope."));

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

            Kitchen.Monsters.Add(new Monster("Vampire", "He's a nice looking vampire. His name is Steve.", 10));

            #endregion
        }
    }
}