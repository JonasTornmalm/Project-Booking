using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_Booking.Model;

namespace Project_Booking
{
    public class CurrencyModel : PageModel
    {
        private readonly ConnectionContext _context;

        public CurrencyModel(ConnectionContext context)
        {
            _context = context;
        }
        public async Task OnGet()
        {
            CurrencyJson = await _context.Currencies.FirstOrDefaultAsync();
            if (CurrencyJson == null)
            {
                if (await Import())
                {
                    _context.Currencies.Add(CurrencyJson);
                    _context.SaveChanges();
                } 
            }
            else
            {
                CurrencyJson = await _context.Currencies.FirstOrDefaultAsync();
            }
        }

        public Currency CurrencyJson { get; set; }

        public async Task<bool> Import()
        {
            try
            {
                String URLString = "https://v6.exchangerate-api.com/v6/5d2eee27d81a15dae3135cce/latest/eur";
                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    Currency currency = JsonConvert.DeserializeObject<Currency>(json);
                    CurrencyJson = currency;
                    CurrencyJson.LastUpdate = DateTime.Now.Date;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<IActionResult> OnPostLoadAsync()
        {
            await Import();
            return Page();
        }
    }
}