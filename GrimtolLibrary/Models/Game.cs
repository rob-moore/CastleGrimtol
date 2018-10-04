using System;
using System.Collections.Generic;
using System.Linq;

namespace GrimtolLibrary.Models
{
    internal class Game
    {
        internal Room CurrentRoom { get; set; }
        internal Player CurrentPlayer { get; set; }
        internal int GameState { get; set; }
        internal RoomFactory RoomFactory { get; set; }

        internal void SetupGame()
        {
            CurrentPlayer = new Player(new List<Item>());
            GameState = 1;
            RoomFactory = new RoomFactory();
            RoomFactory.SetupRooms();
            CurrentRoom = RoomFactory.Entryway;
        }

        internal string LogCurrentRoom()
        {
            var items = new List<string>();

            var exits = new List<Exits>();

            foreach (var exit in CurrentRoom.RoomExits)
            {
                exits.Add(exit.Key);
            }

            if (CurrentRoom.Items != null)
            {
                foreach (var i in CurrentRoom.Items)
                {
                    items.Add(i.Name);
                }
            }

            return CurrentRoom.Name +
                   Environment.NewLine +
                   CurrentRoom.Description +
                   Environment.NewLine +
                   string.Join("; ", exits) +
                   Environment.NewLine +
                   string.Join("; ", items) +
                   Environment.NewLine +
                   "------------------------" +
                   Environment.NewLine;
        }

        internal string Move(string direction)
        {
            Enum.TryParse(direction, true, out Exits exit);
            if (CurrentRoom.RoomExits.ContainsKey(exit))
            {
                var newRoom = CurrentRoom.RoomExits[exit];
                CurrentRoom = newRoom;
                return LogCurrentRoom();
            }

            return "invalid move";
        }

        internal string Look()
        {
            Console.WriteLine("You look around the room:");
            return LogCurrentRoom();
        }

        internal string Help(string helpItem)
        {
            switch (helpItem)
            {
                case "game":
                    return "It's a cool game. You're welcome for making it";
                case "life":
                    return "Stay hydrated and make sure you get enough sleep";
                case "":
                    return "What do you need help with? Ask [game], [life] or [nothing]";
                default:
                    return "Later!";
            }
        }

        internal string Take(string item)
        {
            var selectedItem = CurrentRoom.Items.Single(x => x.Name.ToLower() == item);
            CurrentPlayer.Inventory.Add(selectedItem);
            CurrentRoom.Items.Remove(selectedItem);
            return $"You take {item}";
        }

        internal string Inventory()
        {
            var items = new List<string>();
            foreach (var i in CurrentPlayer.Inventory)
            {
                items.Add(i.Name);
            }

            return !CurrentPlayer.Inventory.Any()
                ? "You're not holding anything"
                : $"You are currently holding: |{string.Join("; ", items)}|";
        }

        internal string Quit()
        {
            GameState = 0;
            return "Bye";
        }
    }
}