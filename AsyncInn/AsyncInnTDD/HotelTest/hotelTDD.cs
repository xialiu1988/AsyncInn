using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AsyncInnTDD.HotelTest
{

   public class hotelTDD
    {  /// <summary>
    /// Getter-->ID
    /// </summary>
        [Fact]
        public void canGetID()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 1;
            Assert.Equal(1, hotel.ID);
        }

        /// <summary>
        /// Setter-->ID
        /// </summary>
        [Fact]
        public void cansetID()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 1;
            hotel.ID = 5;
            Assert.Equal(5, hotel.ID);
        }
        /// <summary>
        /// getter-->Namne
        /// </summary>
        [Fact]
        public void canGetName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Inn";
            Assert.Equal("Inn", hotel.Name);
        }


        /// <summary>
        /// setter--?name
        /// </summary>
        [Fact]
        public void cansetName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Inn";
            hotel.Name = "HotInn";
            Assert.Equal("HotInn", hotel.Name);
        }

        /// <summary>
        /// getter-->address
        /// </summary>
        [Fact]
        public void canGetaddress()
        {
            Hotel hotel = new Hotel();
            hotel.Address = "Inn 123 st";
            Assert.Equal("Inn 123 st", hotel.Address);
        }

        /// <summary>
        /// setter-->address
        /// </summary>
        [Fact]
        public void cansetaddress()
        {
            Hotel hotel = new Hotel();
            hotel.Address = "Inn 123 st";
            hotel.Address = "Inn 234 st";
            Assert.Equal("Inn 234 st", hotel.Address);
        }


        /// <summary>
        /// getter-->phonenumber
        /// </summary>
        [Fact]
        public void canGetPhoneNum()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = "(342)7689807";
            Assert.Equal("(342)7689807", hotel.Phone);
        }


        /// <summary>
        /// setter-->phonenumber
        /// </summary>
        [Fact]
        public void cansetPhoneNum()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = "(342)7689807";
            hotel.Phone = "(452)7689807";
            Assert.Equal("(452)7689807", hotel.Phone);
        }

        /// <summary>
        /// hotelcontroller
        /// </summary>
        [Fact]
        public async void CanCreateHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
                                                                        .UseInMemoryDatabase(databaseName: "CreateHotel").Options;

            using (AsyncInnDbContext _context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Async Inn";
                hotel.Address = "123 main";
                hotel.Phone = "(452)7689807";

                HotelManagementService hotelService = new HotelManagementService(_context);
                await hotelService.CreateHotel(hotel);

                Hotel result = await _context.Hotels.FirstOrDefaultAsync(h => h.ID == hotel.ID);

                Assert.Equal(hotel, result);
            }
        }


        /// <summary>
        /// Get hotel
        /// </summary>
        [Fact]
        public async void CangetAHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetAHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel h1 = new Hotel();
                h1.ID = 1;
                h1.Name = "HotInn";
               h1.Address = "234 main";
             h1.Phone = "2345567788";

                HotelManagementService hotelService = new HotelManagementService(context);
                await hotelService.CreateHotel(h1);

                Hotel result = await hotelService.GetHotel(1);

                Assert.Equal(h1, result);
            }
        }





    }
}
