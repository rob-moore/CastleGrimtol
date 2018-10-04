using System.Collections.Generic;

namespace GrimtolLibrary.Models
{
    internal class Player
    {
        internal string Name { get; set; }
        internal int Health { get; set; }
        internal List<Item> Inventory { get; set; }
        
    }
}