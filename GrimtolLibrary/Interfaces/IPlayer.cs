using System.Collections.Generic;
using GrimtolLibrary.Models;

namespace GrimtolLibrary.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        List<IItem> Inventory { get; }
    }
}