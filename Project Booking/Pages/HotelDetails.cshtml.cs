using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Booking.Model;


namespace Project_Booking
{
    public class HotelDetailsModel : PageModel
    {
      
        private readonly ConnectionContext _context;

        public HotelDetailsModel(ConnectionContext context)
        {
            _context = context;
        }

        public Hotel CurrentHotel { get; set; }


        [BindProperty]
        public InputModel Input { get; set; }

        public string CheckInString { get; set; }
        public string CheckOutString { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime CheckOutDateTime { get; set; }
        public int numberOfAvailableRooms { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Check In")]
            [Date]
            [DataType(DataType.Date)]
            public DateTime CheckIn { get; set; }
            [Required]
            [Display(Name = "Check Out")]
            [Date]
            [DataType(DataType.Date)]
            public DateTime CheckOut { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CurrentHotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);

            if (CurrentHotel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostPickDatesAsync(string id)
        {
            CurrentHotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            CheckInDateTime = Input.CheckIn;
            CheckOutDateTime = Input.CheckOut;
            CheckInString = Input.CheckIn.ToShortDateString();
            CheckOutString = Input.CheckOut.ToShortDateString();

            var checkInDay = int.Parse(CheckInString.Substring(8));
            var checkOutDay = int.Parse(CheckOutString.Substring(8));

            var checkInMonth = int.Parse(CheckInString.Substring(5, 2));
            var checkOutMonth = int.Parse(CheckOutString.Substring(5, 2));

            if (!CheckIfDatesAreValid(checkInDay, checkOutDay, checkInMonth, checkOutMonth))
            {
                return Page();
            }

            //LINQ query to count number of rooms booked during the dates picked
            var roomsBookedList = from b in _context.Bookings
                              where ((CheckInDateTime >= b.CheckIn) && (CheckInDateTime <= b.CheckOut)) ||
                                    ((CheckOutDateTime >= b.CheckIn) && (CheckOutDateTime <= b.CheckOut)) ||
                                    ((CheckInDateTime <= b.CheckIn) && (CheckOutDateTime >= b.CheckIn) && (CheckOutDateTime <= b.CheckOut)) ||
                                    ((CheckInDateTime >= b.CheckIn) && (CheckInDateTime <= b.CheckOut) && (CheckOutDateTime >= b.CheckOut)) ||
                                    ((CheckInDateTime <= b.CheckIn) && (CheckOutDateTime >= b.CheckOut))
                              select b;

            int numberOfBookedRooms = 0;

            foreach (var booking in roomsBookedList.Where(b => b.HotelID == CurrentHotel.Id))
            {
                numberOfBookedRooms += booking.numOfBookedRooms;
            }

            numberOfAvailableRooms = CurrentHotel.NumberOfRooms - numberOfBookedRooms;
            //numberOfAvailableRooms = roomsBookedList.Where(b => b.HotelID == CurrentHotel.Id).Count();

            return Page();
        }

        private bool CheckIfDatesAreValid(int checkInDay, int checkOutDay, int checkInMonth, int checkOutMonth)
        {
            if (checkInDay > checkOutDay)
            {
                if(checkInMonth < checkOutMonth)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if(checkInMonth <= checkOutMonth)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
