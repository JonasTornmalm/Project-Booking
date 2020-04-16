using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Project_Booking.Model;

namespace Project_Booking
{
    public class Index1Model : PageModel
    {
        private readonly ConnectionContext _context;

        public Index1Model(ConnectionContext context)
        {
            _context = context;
        }

        public IList<Hotel> Hotels { get; set; }

        public async Task OnGetAsync()
        {
            Hotels = await _context.Hotel.ToListAsync();
        }
        public IActionResult OnGetSeed()
        {
            AddHotelsDB(_context);
            return RedirectToPage("./Index");
        }

        public static void AddHotelsDB(ConnectionContext context)
        {
            context.Hotel.Add(new Hotel
            {
                Id = "gbghotelone",
                HotelName = "Hotel One",
                HotelInfo = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of " +
                "Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                City = "Göteborg",
                NumberOfRooms = 100,
                HotelPictureBig = "https://andreenoa.github.io/codewindow.jpeg",
                HotelPictureSmallOne = "https://andreenoa.github.io/codewindow.jpeg",
                HotelPictureSmallTwo = "https://andreenoa.github.io/codewindow.jpeg",
                HotelPictureSmallThree = "https://andreenoa.github.io/codewindow.jpeg"
            });
            context.Hotel.Add(new Hotel
            {
                Id = "gbghoteltwo",
                HotelName = "Hotel Two",
                HotelInfo = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of " +
                "Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                City = "Göteborg",
                NumberOfRooms = 90,
                HotelPictureBig = "https://andreenoa.github.io/codewindow.jpeg",
                HotelPictureSmallOne = "https://andreenoa.github.io/codewindow.jpeg",
                HotelPictureSmallTwo = "https://andreenoa.github.io/codewindow.jpeg",
                HotelPictureSmallThree = "https://andreenoa.github.io/codewindow.jpeg"
            });
            context.Hotel.Add(new Hotel
            {
                Id = "gbghotelthree",
                HotelName = "Hotel Three",
                HotelInfo = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of " +
                "Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                City = "Göteborg",
                NumberOfRooms = 50,
                HotelPictureBig = "https://andreenoa.github.io/codewindow.jpeg",
                HotelPictureSmallOne = "https://andreenoa.github.io/codewindow.jpeg",
                HotelPictureSmallTwo = "https://andreenoa.github.io/codewindow.jpeg",
                HotelPictureSmallThree = "https://andreenoa.github.io/codewindow.jpeg"
            });
            context.SaveChanges();
        }
    }
}
