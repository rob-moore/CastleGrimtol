using GrimtolLibrary.Interfaces;

namespace GrimtolLibrary.Models
{
    internal class Monster : IMonster
    {
        public string Name { get; }
        public string Description { get; }
        internal int Health { get; }

        internal Monster(string name, string desc, int health)
        {
            Name = name;
            Description = desc;
            Health = health;
        }
    }
}