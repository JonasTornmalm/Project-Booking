using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Booking.Model
{
    public class Message
    {
        public Guid ID { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string MessageFromUser { get; set; }
        public string AnswerFromAdmin { get; set; }
        public virtual ApplicationUser Customer { get; set; }

    }

}
