using System;
using System.Collections.Generic;
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

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hotel = await _context.Hotel.FirstOrDefaultAsync(h => h.Id == id);

            if (Hotel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
    }
