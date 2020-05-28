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
    public class DeleteModel : PageModel
    {
        private readonly ConnectionContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DeleteModel(
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

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CurrentBooking = await _context.Bookings.FirstOrDefaultAsync(m => m.ID == id);

            if (CurrentBooking == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {

            CurrentBooking = await _context.Bookings.FindAsync(id);

            if(CurrentBooking != null)
            {
                _context.Bookings.Remove(CurrentBooking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Account/Manage/MyBookings", StatusMessage = "Booking has been deleted");
        }
    }
}