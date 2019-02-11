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
   public class RoomTDD
    {/// <summary>
    /// getter--ID
    /// </summary>
        [Fact]
        public void cangetId()
        {
            Room r = new Room();
            r.ID = 1;
            Assert.Equal(1, r.ID);
        }
        /// <summary>
        /// setter--ID
        /// </summary>
        [Fact]
        public void cansetId()
        {
            Room r = new Room();
            r.ID = 1;
            r.ID = 11;
            Assert.Equal(11, r.ID);
        }


        /// <summary>
        /// getter-- Name
        /// </summary>
        [Fact]
        public void cangetname()
        {
            Room r = new Room();
            r.Name = "beachview";
            Assert.Equal( "beachview", r.Name);
        }
        /// <summary>
        /// setter-- Name
        /// </summary>
        [Fact]
        public void cansetname()
        {
            Room r = new Room();
            r.Name = "beachview";
            r.Name = "happy101";
            Assert.Equal("happy101", r.Name);
        }

        /// <summary>
        /// getter-- layout
        /// </summary>
        [Fact]
        public void cangetlayout()
        {
            Room r = new Room();
            r.Layouts = Room.Layout.OneBedroom;
            Assert.Equal(Room.Layout.OneBedroom, r.Layouts);
        }

        /// <summary>
        /// setter-- layout
        /// </summary>
        [Fact]
        public void cansetlayout()
        {
            Room r = new Room();
            r.Layouts = Room.Layout.OneBedroom;
            r.Layouts = Room.Layout.Studio;
            Assert.Equal(Room.Layout.Studio, r.Layouts);
        }

        /// <summary>
        /// can create a room
        /// </summary>
        [Fact]
        public async void CanCreateRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoom").Options;

            using (AsyncInnDbContext _context = new AsyncInnDbContext(options))
            {
                Room r= new Room();
                r.ID = 1;
                r.Name = "happy101";
                r.Layouts =Room.Layout.Studio;

                RoomManagementService rservice = new RoomManagementService(_context);
                await rservice.CreateRoom(r);

                Room result = await _context.Rooms.FirstOrDefaultAsync(h => h.ID == r.ID);

                Assert.Equal(r, result);
            }
        }

    }
}
