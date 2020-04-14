using Microsoft.EntityFrameworkCore;

namespace Project_Booking
{
    public class ConnectionContextDb : DbContext
    {
        public ConnectionContextDb(DbContextOptions<ConnectionContextDb> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}