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
        /// can creat a hotel
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
        ///can  get a  hotel
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


        /// <summary>
        /// can get all hotels
        /// </summary>
        [Fact]
        public async void CangetAllHotels()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetAllHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel h1 = new Hotel();
                h1.ID = 1;
                h1.Name = "HotInn";
                h1.Address = "234 main";
                h1.Phone = "2345567788";

                Hotel h2 = new Hotel();
                h2.ID = 2;
                h2.Name = "redInn";
                h2.Address = "123 main";
                h2.Phone = "2345567788";



                await context.AddAsync(h1);
                await context.AddAsync(h2);
                HotelManagementService newserveice = new HotelManagementService(context);
                var result = await newserveice.GetHotels();
                int id = 1;
                foreach (var r in result) {
                    Assert.Equal(r.ID,id);
                    id++;

                }
                
            }
        }

        /// <summary>
        /// can update a hotel
        /// </summary>
        [Fact]
        public async void CanUpdateAHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateAHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel h1 = new Hotel();
                h1.ID = 1;
                h1.Name = "HotInn";
                h1.Address = "234 main";
                h1.Phone = "2345567788";

                HotelManagementService nservice = new HotelManagementService(context);
                await nservice.CreateHotel(h1);

                Hotel newhotel = await nservice.GetHotel(h1.ID);
                newhotel.Name = "LionMotel";
                await nservice.UpdateHotel(newhotel);

                var result = await context.Hotels.FirstOrDefaultAsync(i => i.ID == h1.ID);
                Assert.Equal("LionMotel", result.Name);
            }
        }

        /// <summary>
        /// can Delete A Hotel
        /// </summary>
        [Fact]
        public async void CanDeleteAHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteAHotel").Options;

            using (AsyncInnDbContext _context = new AsyncInnDbContext(options))
            {
                Hotel h1 = new Hotel();
                h1.ID = 1;
                h1.Name = "HotInn";
                h1.Address = "234 main";
                h1.Phone = "2345567788";
                Hotel h2 = new Hotel();
                h2.ID = 2;
                h2.Name = "redInn";
                h2.Address = "123 main";
                h2.Phone = "2345567788";

                HotelManagementService hotelService = new HotelManagementService(_context);
                await hotelService.CreateHotel(h1);
                await hotelService.CreateHotel(h2);

                await hotelService.DeleteHotel(h2.ID);

               var result = await _context.Hotels.FirstOrDefaultAsync(i => i.ID == h2.ID);
                Assert.Null(result);
            }
        }

    }
}
