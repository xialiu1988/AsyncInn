using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AsyncInn.Models.Room;

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

            modelBuilder.Entity<Room>().HasData(

                new Room
                {  ID = 1,
                   Name = "Seahawk",
                   Layouts = Layout.OneBedroom
                },

                  new Room
                  {
                      ID = 2,
                      Name = "Rainer",
                      Layouts = Layout.Studio
                  },

                   new Room
                   {
                       ID = 3,
                       Name = "Olympic",
                       Layouts = Layout.TwoBedroom
                   },
                    new Room
                    {
                        ID = 4,
                        Name = "DisneyLand",
                        Layouts = Layout.OneBedroom
                    },

                     new Room
                     {
                         ID = 5,
                         Name = "MagicKingdom",
                         Layouts = Layout.TwoBedroom
                     },
                        new Room
                        {
                            ID = 6,
                            Name = "AliceLake",
                            Layouts = Layout.Studio
                        }

                );



            modelBuilder.Entity<Amenities>().HasData(

                new Amenities
                {  ID = 1,
                   Name = "Microwave"
               },

                new Amenities
                {
                    ID = 2,
                    Name = "Air Conditioner"
                },

                new Amenities
                {
                    ID = 3,
                    Name = "Television"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Mini Bar"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "CoffeSet"
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
