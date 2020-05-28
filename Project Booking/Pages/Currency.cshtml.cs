using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public void OnGet()
        {
            CurrencyFromDB = _context.Currencies.FirstOrDefault();

            if (CurrencyFromDB == null)
            {
                Import();
                
                _context.Currencies.Add(CurrencyJson);
                _context.SaveChanges();
            }
        }

        public Currency CurrencyJson { get; set; }

        public Currency CurrencyFromDB { get; set; }

        public bool Import()
        {
            try
            {
                String URLString = "https://v6.exchangerate-api.com/v6/5d2eee27d81a15dae3135cce/latest/EUR";
                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    Currency Test = JsonConvert.DeserializeObject<Currency>(json);
                    CurrencyJson = Test;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}