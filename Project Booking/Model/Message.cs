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
        [Display(Name = "Question")]
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string MessageFromUser { get; set; }
        [Display(Name = "Answer")]
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string AnswerFromAdmin { get; set; }
        public virtual ApplicationUser Customer { get; set; }

    }

}
