using System;
using System.ComponentModel.DataAnnotations;

namespace GrimtolLibrary.Models
{
    public class Room
    {
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal Exits Exits { get; set; }
    }
    
    public class Entryway : Room
    {
        public Entryway()
        {
            Name = "Entryway";
            Description = "it's a spooky entryway";
            Exits = Exits.East;
        }
    }

    public class RoomFactory
    {
        public Room CurrentRoom { get; set; }
        public void CreateRoom(string roomName)
        {
            switch (roomName)
            {
                    case "entryway":
                        CurrentRoom = new Entryway();
                        break;
            }
            
        }
    }
}