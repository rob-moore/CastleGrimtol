using System;
using System.Collections.Generic;
using GrimtolLibrary.Models;

namespace GrimtolLibrary
{
    public class GrimtolApi
    {
        private Game CurrentGame { get; set; }
        
        public void StartGame()
        {
            CurrentGame = new Game();
            CurrentGame.SetupGame();
            Console.WriteLine(CurrentGame.LogCurrentRoom());
        }

        public string ProcessCommand(string command)
        {
            var choices = command.Split(" ");
            string com;
            string target = "";
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
                case 3:
                    com = choices[0];
                    opt = choices[1];
                    target = choices[2];
                    break;
                default:
                    return res;
                    
            }
            switch (com)
            {
                case "move":
                case "go":
                    return CurrentGame.Move(opt);
                case "look":
                case "l":
                    return CurrentGame.Look();
                case "help":
                    return CurrentGame.Help(opt);
                case "take":
                    return CurrentGame.Take(opt);
                case "use":
                    return CurrentGame.Use(opt, target);
                case "inventory":
                case "i" :
                    return CurrentGame.Inventory();
                case "quit":
                case "q":
                    return CurrentGame.Quit();
               case "restart":
                    return "restart";
               default:
                   return res;
            }
        }

        public int GetGameState()
        {
            return CurrentGame.GameState;
        }
    }
}