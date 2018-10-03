using System.Collections.Generic;

namespace GrimtolLibrary.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public List<string> Inventory { get; set; }
        
    }
}