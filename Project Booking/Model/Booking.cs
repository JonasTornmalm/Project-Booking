using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Booking.Model
{
    public class Booking
    {
        [Key]
        public Guid ID { get; set; }
        [Display(Name = "Hotel")]
        public string HotelID { get; set; }
        public virtual ApplicationUser Customer { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        [Display(Name = "Booked Rooms")]
        public int numOfBookedRooms { get; set; }
        [Required]
        [Display(Name = "Check In")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }
        [Required]
        [Display(Name = "Check Out")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

    }
}
