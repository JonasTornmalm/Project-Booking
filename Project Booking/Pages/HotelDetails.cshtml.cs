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

        public Hotel Hotel { get; set; }


        [BindProperty]
        public InputModel Input { get; set; }

        public string CheckIn { get; set; }
        public string CheckOut { get; set; }

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

            Hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);

            if (Hotel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostPickDatesAsync(string id)
        {
            Hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CheckIn = Input.CheckIn.ToShortDateString();
            CheckOut = Input.CheckOut.ToShortDateString();

            return Page();
        }
    }
    }
