using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="please proveide a name.")]
        [Display(Name="Name of the Amenity:")]
        public string Name { get; set; }

     //Navi Property

        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
