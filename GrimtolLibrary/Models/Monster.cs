namespace GrimtolLibrary.Models
{
    internal class Monster
    {
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal int Health { get; set; }

        internal Monster(string name, string desc, int health)
        {
            Name = name;
            Description = desc;
            Health = health;
        }
    }
}