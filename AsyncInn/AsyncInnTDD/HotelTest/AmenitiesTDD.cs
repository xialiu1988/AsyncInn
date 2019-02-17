using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AsyncInnTDD.HotelTest
{
   public class AmenitiesTDD
    {

        [Fact]
        public void canGetID()
        {
           Amenities a = new Amenities();
            a.ID = 1;
            Assert.Equal(1,a.ID);
        }

        /// <summary>
        /// setter
        /// </summary>
        [Fact]
        public void canSetID()
        {
            Amenities a = new Amenities();
            a.ID = 1;
            a.ID = 11;
            Assert.Equal(11, a.ID);
        }


        [Fact]
        public void canGetName()
        {
            Amenities a = new Amenities();
            a.Name = "minibar";
            Assert.Equal("minibar", a.Name);
        }
        /// <summary>
        /// setter
        /// </summary>
        [Fact]
        public void canSetName()
        {
            Amenities a = new Amenities();
            a.Name = "minibar";
            a.Name = "ac";
            Assert.Equal("ac", a.Name);
        }

        /// <summary>
        /// create an amenity
        /// </summary>
        [Fact]
        public async void CanCreateanAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "minibar";

                AmenitiesManagementService service = new AmenitiesManagementService(context);
                await service.CreateAmenities(amenity);

                Amenities result = await context.Amenities.FirstOrDefaultAsync(h => h.ID == amenity.ID);

                Assert.Equal(amenity, result);
            }
        }



        /// <summary>
        /// get one item
        /// </summary>
        [Fact]
        public async void CangetlAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("getAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "minibar";

                AmenitiesManagementService service = new AmenitiesManagementService(context);
                await service.CreateAmenities(amenity);

                Amenities result = await service.GetAmenities(1);

                Assert.Equal(amenity, result);
            }
        }

        /// <summary>
        ///   update
        /// </summary>

        [Fact]
        public async void UpdateAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "minibar";

                AmenitiesManagementService AmenitiesService = new AmenitiesManagementService(context);
                await AmenitiesService.CreateAmenities(amenity);

                Amenities edit = await AmenitiesService.GetAmenities(amenity.ID);
                edit.Name = "ac";
                await AmenitiesService.UpdateAmenities(edit);

                var result = await context.Amenities.FirstOrDefaultAsync(i => i.ID ==amenity.ID);
                Assert.Equal("ac", result.Name);
            }
        }


        /// <summary>
        /// delete
        /// </summary>
        [Fact]
        public async void CanDeleteAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "minibar";

                Amenities a2 = new Amenities();
                a2.ID = 2;
                a2.Name = "ac";

                AmenitiesManagementService service = new AmenitiesManagementService(context);
                await service.CreateAmenities(amenity);
                await service.CreateAmenities(a2);

                await service.DeleteAmenities(a2.ID);

                Amenities result = await context.Amenities.FirstOrDefaultAsync(i => i.ID == a2.ID);
                Assert.Null(result);
            }
        }
    }
}
