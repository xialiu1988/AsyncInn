using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext: DbContext
    {

        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Composite key associations
            modelBuilder.Entity<HotelRoom>().HasKey(ce => new { ce.HotelID, ce.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(ce => new { ce.AmenitiesID, ce.RoomID });


            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "AsyncInn Lakewood",
                    Address="1234 Main st",
                    Phone="234-768-9078"

                },


                 new Hotel
                 {
                     ID = 2,
                     Name = "AsyncInn Seattle",
                     Address = "1235 Main st",
                     Phone = "234-768-9078"

                 },
                  new Hotel
                  {
                      ID = 3,
                      Name = "AsyncInn Bellevue",
                      Address = "1234 Main st",
                      Phone = "234-768-9078"

                  },
                   new Hotel
                   {
                       ID = 4,
                       Name = "AsyncInn Lynwood",
                       Address = "1234 Main st",
                       Phone = "234-768-9078"

                   },
                    new Hotel
                    {
                        ID = 5,
                        Name = "AsyncInn Tacoma",
                        Address = "1234 Main st",
                        Phone = "234-768-9078"

                    }

                );




        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }




    }
}
