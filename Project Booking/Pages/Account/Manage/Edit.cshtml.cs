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
    public class EditModel : PageModel
    {
        private readonly ConnectionContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public EditModel(
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
        [BindProperty]
        public Booking CurrentBooking { get; set; }
        public Hotel CurrentHotel { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime CheckOutDateTime { get; set; }
        public int numberOfAvailableRooms { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            CurrentBooking = await _context.Bookings.FirstOrDefaultAsync(m => m.ID == id);
            CurrentHotel = await _context.Hotels.FirstOrDefaultAsync(m => m.Id == CurrentBooking.HotelID);

            numberOfAvailableRooms = await GetNumberOfAvailableRooms(CurrentBooking, CurrentHotel);

            if (CurrentBooking == null)
            {
                return NotFound();
            }
            return Page();
        }

        private async Task<int> GetNumberOfAvailableRooms(Booking currentBooking, Hotel currentHotel)
        {
            CheckInDateTime = CurrentBooking.CheckIn;
            CheckOutDateTime = CurrentBooking.CheckOut;

            //LINQ query to count number of rooms booked during the dates picked
            var roomsBookedList = from b in _context.Bookings
                                  where ((CheckInDateTime >= b.CheckIn) && (CheckInDateTime <= b.CheckOut)) ||
                                        ((CheckOutDateTime >= b.CheckIn) && (CheckOutDateTime <= b.CheckOut)) ||
                                        ((CheckInDateTime <= b.CheckIn) && (CheckOutDateTime >= b.CheckIn) && (CheckOutDateTime <= b.CheckOut)) ||
                                        ((CheckInDateTime >= b.CheckIn) && (CheckInDateTime <= b.CheckOut) && (CheckOutDateTime >= b.CheckOut)) ||
                                        ((CheckInDateTime <= b.CheckIn) && (CheckOutDateTime >= b.CheckOut))
                                  select b;

            int numberOfBookedRooms = 0;

            foreach (var booking in roomsBookedList.Where(b => b.HotelID == CurrentBooking.HotelID))
            {
                numberOfBookedRooms += booking.numOfBookedRooms;
            }

            int numberOfAvailableRooms = CurrentHotel.NumberOfRooms - numberOfBookedRooms;

            return numberOfAvailableRooms;
        }

        public async Task<IActionResult> OnPostPickDatesAsync(Guid id)
        {
            CurrentHotel = await _context.Hotels.FirstOrDefaultAsync(m => m.Id == CurrentBooking.HotelID);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            numberOfAvailableRooms = await GetNumberOfAvailableRooms(CurrentBooking, CurrentHotel);

            return Page();
        }

        public async Task<IActionResult> OnPostSaveAsync()
        {
            var bookingFromDb = await _context.Bookings.FirstOrDefaultAsync(b => b.ID == CurrentBooking.ID);
            CurrentHotel = await _context.Hotels.FirstOrDefaultAsync(m => m.Id == bookingFromDb.HotelID);

            if (!ModelState.IsValid)
            {
                return NotFound("modelstate on post");
            }
            bookingFromDb.Name = CurrentBooking.Name;
            bookingFromDb.LastName = CurrentBooking.LastName;
            bookingFromDb.CheckIn = CurrentBooking.CheckIn;
            bookingFromDb.CheckOut = CurrentBooking.CheckOut;
            bookingFromDb.numOfBookedRooms = CurrentBooking.numOfBookedRooms;

            _context.Attach(bookingFromDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(CurrentBooking.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Account/Manage/MyBookings", StatusMessage = "Booking has been edited");
        }

        private bool BookingExists(Guid id)
        {
            return _context.Bookings.Any(e => e.ID == id);
        }
    }
}