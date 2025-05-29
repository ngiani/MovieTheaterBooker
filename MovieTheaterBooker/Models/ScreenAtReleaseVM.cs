using MovieTheaterBooker.Data;

namespace MovieTheaterBooker.Models
{
    public class ScreenAtReleaseVM
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public ScreenRelease ScreenRelease { get; set; }

        public List<Seat> Seats { get; set; } 
        
        public List<SeatBooking> SeatBookings { get; set; }  
    }
}
