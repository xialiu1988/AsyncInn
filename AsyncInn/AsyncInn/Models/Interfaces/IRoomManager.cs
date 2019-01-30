using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
   public interface IRoomManager
    {
        // Create Room
        Task CreateRoom(Room room);


        Task<Room> GetRoom(int id);

        Task<IEnumerable<Room>> GetRooms();

        // Update Room
       Task UpdateRoom(Room room);

        // Delete Room
        Task DeleteRoom(int id);


    }
}
