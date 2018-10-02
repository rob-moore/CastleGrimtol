using System;
using System.Collections.Generic;
using GrimtolLibrary.Models;

namespace GrimtolLibrary
{
    public class GrimtolApi
    {
        public void StartGame()
        {
            var roomFactory = new RoomFactory();
            roomFactory.CreateRoom("entryway");
            
            Console.WriteLine(roomFactory.CurrentRoom.Name);
            Console.WriteLine(roomFactory.CurrentRoom.Description);
            Console.WriteLine(roomFactory.CurrentRoom.Exits);
            
            ProcessCommand(Console.ReadLine());
            
        }

        public void ProcessCommand(string command)
        {
            switch (command)
            {
                case "move":
                    
                    
                case "look":
                    
                case "help":
                        
                case "take":
                        
                case "use":
                    
                case "inventory":
                    
                case "quit":
                    
               case "restart":
                    break;
            }
        }

        public void GetGameState()
        {
            
        }
    }
}