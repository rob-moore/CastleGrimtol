using System;

namespace GrimtolLibrary.Models
{
    public class Game
    {
        
        internal Room CurrentRoom { get; set; }
        internal Player CurrentPlayer { get; set; }
        
        internal string Move(string direction)
        {
            if (CurrentRoom.RoomExits.Keys.ToString().ToLower() == direction)
            {
                return $"moving to {CurrentRoom.RoomExits.Keys}";
            }

            return "butts";
        }

        internal string Look()
        {
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

        internal void Take(string item)
        {
            throw new System.NotImplementedException();
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