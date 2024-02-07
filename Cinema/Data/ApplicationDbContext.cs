using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<CinemaBranch> CinemaBranch { get; set; }

        public DbSet<UserAccounts> UserAccounts { get; set; }

        public DbSet<MovieHall> MovieHall { get; set; }

        public DbSet<MovieHallSeats> MovieHallSeats { get; set; }
    }
}
