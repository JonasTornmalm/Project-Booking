using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Booking.Model;

namespace Project_Booking
{
    public class ConnectionContext : IdentityDbContext<ApplicationUser>
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Message> Message { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
