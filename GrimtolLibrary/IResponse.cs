using GrimtolLibrary.Models;

namespace GrimtolLibrary
{
    public interface IResponse
    {
        Room GetRoom(string roomName);
        
    }
}