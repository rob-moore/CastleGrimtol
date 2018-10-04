namespace GrimtolLibrary.Models
{
    public class Monster
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Health { get; set; }

        public Monster(string name, string desc, int health)
        {
            Name = name;
            Description = desc;
            Health = health;
        }
    }
}