using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieTheaterBooker.Data
{
    //Which movie is released at a specific screen at a specific time
    public class ScreenRelease
    {
        public int Id { get; set; }
        public int ScreenId { get; set; }

        [ValidateNever]
        public Screen Screen { get; set; }
        public int MovieId { get; set; }

        [ValidateNever]
        public Movie Movie { get; set; }
        public DateTime ReleaseTime { get; set; } = DateTime.Now;

    }
}
