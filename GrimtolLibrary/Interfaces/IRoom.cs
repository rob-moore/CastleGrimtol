using System.Collections.Generic;
using GrimtolLibrary.Models;

namespace GrimtolLibrary.Interfaces
{
    public interface IRoom
    {
        string Name { get; }
        string Description { get; }
        Dictionary<Exits, IRoom> RoomExits { get; }
        List<IItem> Items { get; }
        List<IMonster> Monsters { get; }
    }
}