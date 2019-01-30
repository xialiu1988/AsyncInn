using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenitiesManagementService : IAmenitiesManager
    {
        public Task CreateAmenities(Amenities Amenities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAmenities(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Amenities> GetAmenities(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Amenities>> GetAmenities()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAmenities(Amenities Amenities)
        {
            throw new NotImplementedException();
        }
    }
}
