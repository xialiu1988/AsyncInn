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
   public class HotelRoomTDD
    {
        /// <summary>
        /// getter-->rate
        /// </summary>
        [Fact]
        public void cangetrate()
        {
            HotelRoom r = new HotelRoom();
            r.Rate = 32.45M;

            Assert.Equal(32.45M, r.Rate);

        }
        /// <summary>
        /// setter
        /// </summary>
        [Fact]
        public void cansetrate()
        {
            HotelRoom r = new HotelRoom();
            r.Rate = 32.45M;
            r.Rate = 2.45M;
            Assert.Equal(2.45M, r.Rate);

        }


        [Fact]
        public void CanGetPetFriendly()
        {
            HotelRoom h = new HotelRoom();
            h.PetFriendly = false;

            Assert.False(h.PetFriendly);
        }
        /// <summary>
        /// setter
        /// </summary>
        [Fact]
        public void CansetPetFriendly()
        {
            HotelRoom h = new HotelRoom();
            h.PetFriendly = false;
            h.PetFriendly = true;
            Assert.True(h.PetFriendly);
        }

        /// <summary>
        /// getter
        /// </summary>

        [Fact]
        public void CanGetHotelID()
        {
            HotelRoom h = new HotelRoom();
            h.HotelID = 1;

            Assert.Equal(1, h.HotelID);
        }
        /// <summary>
        /// setter
        /// </summary>
        [Fact]
        public void CanSetHotelID()
        {
            HotelRoom h = new HotelRoom();
            h.HotelID = 1;
            h.HotelID = 11;

            Assert.Equal(11, h.HotelID);
        }




        [Fact]
        public void getroomnumber()
        {
            HotelRoom h = new HotelRoom();
            h.RoomNumber = 234;
            Assert.Equal(234, h.RoomNumber);
        }

        [Fact]
        public void setroomnumber()
        {
            HotelRoom h = new HotelRoom();
            h.RoomNumber = 345;
            Assert.Equal(345, h.RoomNumber);
        }


        [Fact]
        public void CanGetRoomID()
        {
            HotelRoom h = new HotelRoom();
            h.RoomID = 1;

            Assert.Equal(1, h.RoomID);
        }



        [Fact]
        public void CanSetRoomID()
        {
            HotelRoom h = new HotelRoom();
            h.RoomID = 1;
            h.RoomID = 11;
            Assert.Equal(11, h.RoomID);
        }




    }
}
