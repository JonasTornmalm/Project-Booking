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
    public class DeleteMessageModel : PageModel
    {
        private readonly ConnectionContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DeleteMessageModel(
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
        public List<Message> CurrentConversation { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CurrentConversation = await _context.Message.Where(m => m.Conversation == id).ToListAsync();

            if (CurrentConversation == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {

            CurrentConversation = await _context.Message.Where(m => m.Conversation == id).ToListAsync();

            if (CurrentConversation != null)
            {
                _context.Message.RemoveRange(CurrentConversation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Account/Manage/Inbox", StatusMessage = "Support ticket has been deleted");
        }
    }
}