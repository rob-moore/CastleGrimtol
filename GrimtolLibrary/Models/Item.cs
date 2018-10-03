
namespace GrimtolLibrary.Models
{
    internal class Item
    {
        internal string Name { get; set; }
        internal string Description { get; set; }

        internal Item(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
        
        
    }
}