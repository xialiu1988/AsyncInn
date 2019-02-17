using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AsyncInn.Controllers;

namespace AsyncInnTDD.HotelTest
{
   public class RoomAmenityTDD
    {

        /// <summary>
        ///         getter/setter
        /// </summary>

        [Fact]
        public void getID()
        {
            RoomAmenities r = new RoomAmenities();
            r.AmenitiesID = 1;
            Assert.True(r.AmenitiesID == 1);
        }

        /// <summary>
        /// setter
        /// </summary>
        [Fact]
        public void setID()
        {
            RoomAmenities r = new RoomAmenities();
            r.AmenitiesID = 1;
            r.AmenitiesID = 14;
            Assert.True(r.AmenitiesID == 14);
        }

        [Fact]
        public void getroomID()
        {
            RoomAmenities r = new RoomAmenities();
            r.RoomID = 1;
            Assert.True(r.RoomID == 1);
        }

        [Fact]
        public void SetroomID()
        {
            RoomAmenities r = new RoomAmenities();
            r.RoomID = 1;
            r.RoomID = 3;
            Assert.True(r.RoomID == 3);
        }
    }
}
