using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomManagementService : IRoomManager
    {
        private AsyncInnDbContext _context { get; }
        public RoomManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            Room room = _context.Rooms.FirstOrDefault(r => r.ID == id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(ro => ro.ID == id);
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();

            foreach (Room ro in rooms)
            {
                ro.RoomAmenities = await _context.RoomAmenities.Where(am => am.RoomID == ro.ID).ToListAsync();
            }

            return rooms;
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
