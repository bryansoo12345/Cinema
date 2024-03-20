using Cinema.Models;
using Cinema.Models.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Cinema.Models.Utilities;

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
        public DbSet<MovieShowTime> MovieShowTimes { get; set; }
        public DbSet<BranchHall> BranchHall { get; set; }
        public DbSet<BranchManager> BranchManager { get; set; }
        public DbSet<MovieShowCounters> MovieShowCounters { get; set; }

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
