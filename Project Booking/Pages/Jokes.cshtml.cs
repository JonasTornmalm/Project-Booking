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
    public class JokesModel : PageModel
    {
        private readonly ConnectionContext _context;
        public JokesModel(ConnectionContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            GetChuckJoke();
        }
        public Jokes JokesJson { get; set; }
        public bool GetChuckJoke()
        {
            try
            {
                String URLString = "https://api.chucknorris.io/jokes/random";
                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    Jokes jokes = JsonConvert.DeserializeObject<Jokes>(json);
                    JokesJson = jokes;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void OnPostNewChuck()
        {
            GetChuckJoke();
        }
    }
    
}
