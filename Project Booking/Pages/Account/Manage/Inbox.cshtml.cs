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
    public class InboxModel : PageModel
    {
        private readonly ConnectionContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public InboxModel(
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
        public List<Message> Messages { get; set; }
        public async Task OnGetAsync(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                StatusMessage = message;
            }
            var user = await _userManager.GetUserAsync(User);
            CurrentUser = user;

            Messages = await _context.Message.ToListAsync();
        }
    }
}