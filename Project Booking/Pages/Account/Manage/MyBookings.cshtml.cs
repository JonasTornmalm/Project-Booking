using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Booking.Model;

namespace Project_Booking
{
    public class MyBookingsModel : PageModel
    {
        private readonly ConnectionContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public MyBookingsModel(
            ConnectionContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [TempData]
        public string StatusMessage { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public List<Booking> BookingList { get; set; }
        public async Task OnGetAsync(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                StatusMessage = message;
            }
            var user = await _userManager.GetUserAsync(User);
            CurrentUser = user;

            BookingList = await _context.Bookings.ToListAsync();
        }
    }
}