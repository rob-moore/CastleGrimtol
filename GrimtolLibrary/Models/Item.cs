using GrimtolLibrary.Interfaces;

namespace GrimtolLibrary.Models
{
    internal class Item : IItem
    {
        public string Name { get; }
        public string Description { get; }

        internal Item(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
    }
}