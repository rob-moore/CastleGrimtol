using System;
using System.Collections.Generic;
using GrimtolLibrary.Models;

namespace GrimtolLibrary
{
    public class GrimtolApi
    {
        public int GameState { get; set; }
        private Game CurrentGame { get; set; }
        private Player Player { get; set; }
        private RoomFactory RoomFactory { get; set; }
        
        public void StartGame()
        {
            CurrentGame = new Game();
            Player = new Player();
            GameState = 1;
            RoomFactory = new RoomFactory();
            RoomFactory.SetupRooms();
            CurrentGame.CurrentRoom = RoomFactory.Entryway;
            Console.WriteLine(CurrentGame.LogCurrentRoom());
        }

        public string ProcessCommand(string command)
        {
            var choices = command.Split(" ");
            string com;
            var opt = "";
            var res = "Invalid input";
            switch (choices.Length)
            {
                case 1:
                    com = choices[0];
                    break;
                case 2:
                    com = choices[0];
                    opt = choices[1];
                    break;
                default:
                    return res;
                    
            }
            switch (com)
            {
                case "move":
                    return CurrentGame.Move(opt);
                case "look":
                case "l":
                    return CurrentGame.Look();
                case "help":
                    return CurrentGame.Help(opt);
                case "take":
                    return CurrentGame.Take(opt);
                case "use":
                    return "use";
                case "inventory":
                    return "use";
                case "quit":
                case "q":
                    
                    return "bye";
               case "restart":
                    return "restart";
               default:
                   return res;
            }
        }

        public void GetGameState()
        {
            
        }
    }
}