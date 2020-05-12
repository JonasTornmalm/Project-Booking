using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Project_Booking.Controllers
{
    [Route("api/Hotel")]
    [ApiController]
    public class HotelController : Controller
    {
      
        private readonly ConnectionContext _context;

        public HotelController(ConnectionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _context.Hotel.ToListAsync() });
        }       
    }
}