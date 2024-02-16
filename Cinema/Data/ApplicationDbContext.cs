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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name)
                    .Property<DateTime>("CreatedDateTime")
                    .HasDefaultValueSql("GETDATE()")
                    .ValueGeneratedOnAdd();

                modelBuilder.Entity(entityType.Name)
                    .Property<DateTime>("ModifedDateTime")
                    .HasDefaultValueSql("GETDATE()")
                    .ValueGeneratedOnAddOrUpdate();
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
