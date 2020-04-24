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
        [BindProperty]
        public Booking CurrentBooking { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        public List<Hotel> UserBookedHotels { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            CurrentUser = user;
            foreach (var item in CurrentUser.MyBookings)
            {
                var hotelID = item.HotelID;
                UserBookedHotels = await _context.Hotel.Where(h => h.Id == hotelID).ToListAsync();
            }
        }
    }
}