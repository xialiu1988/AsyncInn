﻿using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelManagementService : IHotelManager
    {
        private AsyncInnDbContext _context { get; }

        public HotelManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

       

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync(); 

            foreach (Hotel h in hotels)
            {
                h.HotelRooms = await _context.HotelRooms.Where(ro => ro.HotelID == h.ID).ToListAsync();
            }
            return hotels;
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.ID == id);

        }

        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = _context.Hotels.FirstOrDefault(h => h.ID == id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
