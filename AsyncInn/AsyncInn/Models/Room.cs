using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Layout Layouts { get; set; }

        public enum Layout
        {
            Studio =0,
            OneBedroom=1,
            TwoBedroom=2
  
        }



        //Navi Properties
        public ICollection<HotelRoom> HotelRooms { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
