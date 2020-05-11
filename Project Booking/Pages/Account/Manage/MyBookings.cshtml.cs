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
        public List<Hotel> Hotels { get; set; }
        public List<Booking> Bookings { get; set; }
        public async Task OnGetAsync(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                StatusMessage = message;
            }
            var user = await _userManager.GetUserAsync(User);
            CurrentUser = user;

            Bookings = await _context.Booking.ToListAsync();
            Hotels = await PopulateHotelList();

        }

        private async Task<List<Hotel>> PopulateHotelList()
        {
            List<Hotel> hotelList = new List<Hotel>();
            foreach (var booking in CurrentUser.MyBookings)
            {
                var hotel = await _context.Hotel.Where(h => h.Id == booking.HotelID).FirstOrDefaultAsync();
                hotelList.Add(hotel);
            }
            return hotelList;
        }
    }
}