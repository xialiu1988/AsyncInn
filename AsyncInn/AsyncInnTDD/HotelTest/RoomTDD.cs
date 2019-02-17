using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static AsyncInn.Models.Room;

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

        /// <summary>
        /// can update a room
        /// </summary>
        [Fact]
        public  async void canUpdateroom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room r = new Room();
                r.ID = 1;
                r.Name = "happyroom";
                r.Layouts = Layout.Studio;

                RoomManagementService rService = new RoomManagementService(context);
                await rService.CreateRoom(r);

                Room res = await rService.GetRoom(r.ID);
                res.Layouts = Layout.OneBedroom;
                await rService.UpdateRoom(res);

                var result = await context.Rooms.FirstOrDefaultAsync(i => i.ID == r.ID);
                Assert.Equal(Layout.OneBedroom, result.Layouts);
            }
        }



        /// <summary>
        /// get a single room
        /// </summary>
        [Fact]
        public async void cangetAroom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetARoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room r = new Room();
                r.ID = 1;
                r.Name = "SpaRoom";
                r.Layouts = Layout.Studio;

                RoomManagementService roomService = new RoomManagementService(context);
                await roomService.CreateRoom(r);

                Room result = await roomService.GetRoom(1);

                Assert.Equal(r, result);
            }
        }

        /// <summary>
        /// delete a room
        /// </summary>
        [Fact]
        public async void CanDeleteRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room r = new Room();
                r.ID = 1;
                r.Name = "SpaRoom";
                r.Layouts = Layout.Studio;


                Room r2 = new Room();
                r2.ID = 2;
                r2.Name = "moonlight";
                r2.Layouts = Layout.OneBedroom;


                RoomManagementService roomService = new RoomManagementService(context);
                await roomService.CreateRoom(r);
                await roomService.CreateRoom(r2);

                await roomService.DeleteRoom(r.ID);

                Room result = await context.Rooms.FirstOrDefaultAsync(i => i.ID == r.ID);
                Assert.Null(result);
            }
        }
    }
}
