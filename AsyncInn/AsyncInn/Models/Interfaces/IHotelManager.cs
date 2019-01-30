using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
   public interface IHotelManager

    {   //create a hotel
        Task CreateHotel(Hotel hotel);

        Task<Hotel> GetHotel(int id);

        Task<IEnumerable<Hotel>> GetHotels();

        //update a Hotel
        Task UpdateHotel(Hotel hotel);

        Task DeleteHotel(int id);
    }
}
