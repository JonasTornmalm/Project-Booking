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
    public class BookingModel : PageModel
    {
        private readonly ConnectionContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingModel(
            ConnectionContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public Bookings Booking { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public Hotel CurrentHotel { get; set; }

        public async Task OnGetAsync(string id)
        {
            CurrentHotel = await _context.Hotel.Where(h => h.Id == id).FirstOrDefaultAsync();

            var user = await _userManager.GetUserAsync(User);
            var userName = await _userManager.GetUserNameAsync(user);
            var nameOfUser = user.Name;
            var lastNameOfUser = user.LastName;

            CurrentUser = new ApplicationUser
            {
                UserName = userName,
                Name = nameOfUser,
                LastName = lastNameOfUser
            };
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.GetUserAsync(User);
            CurrentHotel = await _context.Hotel.Where(h => h.Id == id).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var book = new Bookings()
            {
                ID = new Guid(),
                numOfBookedRooms = Booking.numOfBookedRooms,
                Customer = user,
                HotelID = CurrentHotel.Id,
                Name = Booking.Name,
                LastName = Booking.LastName
            };
            await _context.Booking.AddAsync(book);
            await _context.SaveChangesAsync();


            return RedirectToPage("Index");
        }
    }
}