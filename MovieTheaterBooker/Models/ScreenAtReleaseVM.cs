using MovieTheaterBooker.Data;

namespace MovieTheaterBooker.Models
{
    public class ScreenAtReleaseVM : Screen
    {
        public ScreenRelease ScreenRelease { get; set; }

        public List<Seat> Seats { get; set; } 
        
        public List<SeatBooking> SeatBookings { get; set; }  
    }
}
