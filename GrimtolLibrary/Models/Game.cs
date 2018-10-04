using System;
using System.Collections.Generic;
using System.Linq;

namespace GrimtolLibrary.Models
{
    internal class Game
    {
        internal Room CurrentRoom { get; set; }
        internal Player Player { get; set; }

        internal string LogCurrentRoom()
        {
            string itemName = "";
            List<Exits> exits = new List<Exits>();
            
            foreach (var exit in CurrentRoom.RoomExits)
            {
                exits.Add(exit.Key);
            }

            if (CurrentRoom.Items != null)
            {
                itemName = CurrentRoom.Items.Name;
            }
            return $"{CurrentRoom.Name}\n{CurrentRoom.Description}\n{string.Join("; ", exits)}\n{itemName}\n------------------------\n";
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
            else
            {
                return "invalid move";
            }
        }

        internal string Look()
        {
            Console.WriteLine("You look around the room");
            return CurrentRoom.Description;
        }

        internal void LookAt(string item)
        {
            throw new System.NotImplementedException();
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
            return $"taking {item}";
        }

        internal void Use(string item)
        {
            throw new System.NotImplementedException();
        }

        internal void Inventory()
        {
            throw new System.NotImplementedException();
        }

        internal void Quit()
        {
            throw new System.NotImplementedException();
        }

        public void Restart()
        {
            throw new System.NotImplementedException();
        }
    }
}