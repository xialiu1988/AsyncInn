using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }

        public int RoomID { get; set; }

        [DataType(DataType.Currency)]
         public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }


        //Navi properties

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
