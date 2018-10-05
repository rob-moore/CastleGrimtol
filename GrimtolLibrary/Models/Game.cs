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
            var monsters = new List<string>();

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

            if (CurrentRoom.Monsters != null)
            {
                foreach (var i in CurrentRoom.Monsters)
                {
                    monsters.Add(i.Name);
                }
            }

            return Environment.NewLine +
                   CurrentRoom.Name +
                   Environment.NewLine +
                   CurrentRoom.Description +
                   Environment.NewLine +
                   "Exits: " + string.Join(", ", exits) +
                   Environment.NewLine +
                   "Items: " + string.Join(", ", items) +
                   Environment.NewLine +
                   "Monsters: " + string.Join(", ", monsters) +
                   Environment.NewLine +
                   "------------------------";
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

        internal string Look(string item = "")
        {
            if (item == "")
            {
                Console.WriteLine("You look around the room:");
                return LogCurrentRoom();     
            }
            
            if (CurrentRoom.Items.Any(x => x.Name.ToLower() == item))
            {
                var targetItem = CurrentRoom.Items.FirstOrDefault(x => x.Name.ToLower() == item);
                return $"{targetItem.Name}: {targetItem.Description}";
            }       
            
            if (CurrentRoom.Monsters.Any(x => x.Name.ToLower() == item))
            {
                var targetMonster = CurrentRoom.Monsters.FirstOrDefault(x => x.Name.ToLower() == item);
                return $"{targetMonster.Name}: {targetMonster.Description}";
            }

            return "You don't see that.";

        }

        internal string Help(string helpItem)
        {
            switch (helpItem)
            {
                case "move":
                    return "syntax: move [direction], go [direction]";
                case "use":
                    return "syntax: use [item] [target]";                
                case "take":
                    return "syntax: take [item]";                
                case "look":
                    return "syntax: look, look [item]";
                default:
                    return "What do you need help with? Ask [move], [use], [take], or [look]";
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

        internal string Use(string item, string target)
        {
            switch (target)
            {
                case "vampire":
                case "monster":
                case "steve":
                    if(CurrentPlayer.Inventory.Any(x => x.Name.ToLower() != item) || CurrentPlayer.Inventory.Count == 0)
                        return "You don't have that!";
                    CurrentRoom.Monsters.Remove(CurrentRoom.Monsters.FirstOrDefault());
                    CurrentRoom.Items.Add(new Item("Corpse", "What have you done?"));
                    return "Wow you killed him. He was really nice too.";
                case "self":
                case "myself":
                    GameState = 0;
                    return "Probably not the best idea";
                default:
                    return "What do you want to use?";
            }
        }

        internal string Quit()
        {
            GameState = 0;
            return "Bye";
        }
    }
}