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
    public class ReplyMessageModel : PageModel
    {
        private readonly ConnectionContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ReplyMessageModel(
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

        [BindProperty]
        public Message ReplyMessage { get; set; }
        public List<Message> Conversation { get; set; }
        [BindProperty]
        public Message CurrentMessage { get; set; }





        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(User);
            CurrentUser = user;

            CurrentMessage = await _context.Message.FirstOrDefaultAsync(m => m.ID == id);


            Conversation = await _context.Message.Where(m => m.Conversation == CurrentMessage.Conversation).ToListAsync();


            if (CurrentMessage == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var message = new Message()
            {
                ID = new Guid(),
                Subject = ReplyMessage.Subject,
                MessageFromUser = ReplyMessage.MessageFromUser,
                Customer = user,
                Conversation = CurrentMessage.Conversation,
                Created = DateTime.Now,
                Sender = user
            };


            await _context.Message.AddAsync(message);
            await _context.SaveChangesAsync();

            return RedirectToPage("Inbox");

        }
    }
}