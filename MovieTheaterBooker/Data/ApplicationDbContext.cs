using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MovieTheaterBooker.Data
{
    public class ApplicationDbContext : IdentityDbContext<MovieTheaterBookerUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<ScreenRelease> ScreenReleases { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<SeatBooking> SeatsBooking { get; set; }
    }
}
