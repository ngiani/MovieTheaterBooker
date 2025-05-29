using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieTheaterBooker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<ScreenRelease> ScreenReleases { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<SeatBooking> SeatsBooking { get; set; }
    }
}
