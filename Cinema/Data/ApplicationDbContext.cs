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

        public DbSet<Account> Account { get; set; }

        public DbSet<MovieHall> MovieHall { get; set; }

        public DbSet<MovieHallSeats> MovieHallSeats { get; set; }

        public DbSet<MovieShow> MovieShow { get; set; }

        public DbSet<MovieShowSeats> MovieShowSeats { get; set; }

    }
}
