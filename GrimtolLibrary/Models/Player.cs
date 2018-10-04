using System.Collections.Generic;

namespace GrimtolLibrary.Models
{
    internal class Player
    {
        internal string Name { get; set; }
        internal int Health { get; set; } = 100;
        internal List<Item> Inventory { get; set; }

        public Player(List<Item> inv)
        {
            Inventory = inv;
        }
    }
    
}