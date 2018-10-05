using System.Collections.Generic;
using GrimtolLibrary.Interfaces;

namespace GrimtolLibrary.Models
{
    internal class Player : IPlayer
    {
        public string Name { get; }
        public List<IItem> Inventory { get; }
        internal int Health { get; set; } = 100;

        //TODO: Implement health system
        internal Player(List<IItem> inv)
        {
            Inventory = inv;
        }
    }
}