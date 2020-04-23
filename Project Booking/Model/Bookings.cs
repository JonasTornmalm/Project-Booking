using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Booking.Model
{
    public class Bookings
    {
        [Key]
        public Guid ID { get; set; }
        public string HotelID { get; set; }
        public virtual ApplicationUser Customer { get; set; }
        public int numOfBookedRooms { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

    }
}
