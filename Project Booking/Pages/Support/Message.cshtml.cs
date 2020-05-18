using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Booking.Model;

namespace Project_Booking.Pages.Support
{
    public class MessageModel : PageModel
    {
        private readonly ConnectionContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessageModel(ConnectionContext context, UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ApplicationUser CurrentUser { get; set; }
        [BindProperty]

        public Message Message { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            CurrentUser = user;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var message = new Message()
            {
                ID = new Guid(),
                Subject = Message.Subject,
                MessageFromUser = Message.MessageFromUser,
                Customer = user,
                Conversation = Guid.NewGuid(),
                Created = DateTime.Now,
                Sender = user
            };

            await _context.Message.AddAsync(message);
            await _context.SaveChangesAsync();

            return RedirectToPage("Message", StatusMessage = "Your message has been sent");
        }
    }
}