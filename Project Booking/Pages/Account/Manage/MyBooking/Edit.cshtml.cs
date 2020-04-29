﻿using System;
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

        [BindProperty]
        public Booking CurrentBooking { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CurrentBooking = await _context.Booking.FirstOrDefaultAsync(m => m.ID == id);

            if (CurrentBooking == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var bookingFromDb = await _context.Booking.FirstOrDefaultAsync(b => b.ID == CurrentBooking.ID);
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

            return RedirectToPage("/Account/Manage/MyBookings");
        }

        private bool BookingExists(Guid id)
        {
            return _context.Booking.Any(e => e.ID == id);
        }

    }
}