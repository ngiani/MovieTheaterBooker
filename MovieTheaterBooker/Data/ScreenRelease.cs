namespace MovieTheaterBooker.Data
{
    //Which movie is released at a specific screen at a specific time
    public class ScreenRelease
    {
        public int Id { get; set; }
        public Screen Screen { get; set; }
        public Movie Movie { get; set; }
        public DateTime ReleaseTime { get; set; }

    }
}
