using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Booking.Model
{
    public class Room
    {
        [Key]
        public Guid ID { get; set; }

        public virtual Hotel Hotel { get; set; }


    }
}
