using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
   public interface IAmenitiesManager
    {

        // Create Amenities
        Task CreateAmenities(Amenities Amenities);

       
        Task<Amenities> GetAmenities(int id);

        Task<IEnumerable<Amenities>> GetAmenities();

        // Update Amenities
        Task UpdateAmenities(Amenities Amenities);


        Task DeleteAmenities(int id);
    }
}
