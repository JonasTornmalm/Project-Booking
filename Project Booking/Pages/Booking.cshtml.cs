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
        public Booking CurrentBooking { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public Hotel CurrentHotel { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public int numberOfAvailableRooms { get; set; }

        public int maxRoomsToBook { get; set; }


        [TempData]
        public string StatusMessage { get; set; }

        public async Task OnGetAsync(string id, Dictionary<string, string> bookingDates)
        {
            foreach (var item in bookingDates)
            {
                if(item.Key == "data1")
                {
                    CheckIn = DateTime.Parse(item.Value);
                }
                else if(item.Key == "data2")
                {
                    CheckOut = DateTime.Parse(item.Value);
                }
            }

            CurrentHotel = await _context.Hotels.Where(h => h.Id == id).FirstOrDefaultAsync();

            //LINQ query to count number of rooms booked during the dates picked
            var roomsBookedList = from b in _context.Bookings
                              where ((CheckIn >= b.CheckIn) && (CheckIn <= b.CheckOut)) ||
                                  ((CheckOut >= b.CheckIn) && (CheckOut <= b.CheckOut)) ||
                                  ((CheckIn <= b.CheckIn) && (CheckOut >= b.CheckIn) && (CheckOut <= b.CheckOut)) ||
                                  ((CheckIn >= b.CheckIn) && (CheckIn <= b.CheckOut) && (CheckOut >= b.CheckOut)) ||
                                  ((CheckIn <= b.CheckIn) && (CheckOut >= b.CheckOut))
                              select b;

            int numberOfBookedRooms = 0;

            foreach (var booking in roomsBookedList.Where(b => b.HotelID == CurrentHotel.Id))
            {
                numberOfBookedRooms += booking.numOfBookedRooms;
            }

            numberOfAvailableRooms = CurrentHotel.NumberOfRooms - numberOfBookedRooms;

            if (numberOfAvailableRooms > 10)
            {
                maxRoomsToBook = 10;
            }
            else
            {
                maxRoomsToBook = numberOfAvailableRooms;
            }

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
            var user = await _userManager.GetUserAsync(User);
            CurrentUser = user;
            CurrentHotel = await _context.Hotels.Where(h => h.Id == id).FirstOrDefaultAsync();
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var book = new Booking()
            {
                ID = new Guid(),
                numOfBookedRooms = CurrentBooking.numOfBookedRooms,
                Customer = user,
                HotelID = CurrentHotel.Id,
                Hotel = CurrentHotel,
                Name = CurrentBooking.Name,
                LastName = CurrentBooking.LastName,
                CheckIn = CurrentBooking.CheckIn,
                CheckOut = CurrentBooking.CheckOut
            };
            user.MyBookings.Add(book);
            await _context.Bookings.AddAsync(book);
            await _context.SaveChangesAsync();

            return RedirectToPage("Account/Manage/MyBookings", StatusMessage = "Booking has been added");
        }
    }
}