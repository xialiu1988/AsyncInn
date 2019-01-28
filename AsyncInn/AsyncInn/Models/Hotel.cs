using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {

        public int ID { get; set; }

        [Required(ErrorMessage ="Please provide a name.")]
        public string Name { get; set; }

        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }



        //Navi Properties
        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
