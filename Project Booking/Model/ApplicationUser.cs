using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Project_Booking.Model;

namespace Project_Booking.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Phone]
        [Display(Name = "Phone number")]
        public override string PhoneNumber { get; set; }

        public string ProfilePicture { get; set; }

    }
}
