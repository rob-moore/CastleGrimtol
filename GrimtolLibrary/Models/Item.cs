
namespace GrimtolLibrary.Models
{
    internal class Item
    {
        internal string Name { get; }
        internal string Description { get; }

        internal Item(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
       
    }
}