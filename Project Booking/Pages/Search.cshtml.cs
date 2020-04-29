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
    public class SearchModel : PageModel
    {
        private readonly ConnectionContext _context;

        public SearchModel(ConnectionContext context)
        {
            _context = context;
        }

        public IList<Hotel> Hotels { get; set; }
        public async Task OnGetAsync()
        {
            Hotels = await _context.Hotel.ToListAsync();
        }
    }
}
