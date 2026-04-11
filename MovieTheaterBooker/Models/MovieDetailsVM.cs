using MovieTheaterBooker.Data;
using System.ComponentModel.DataAnnotations;

namespace MovieTheaterBooker.Models
{
    public class MovieDetailsVM : Movie
    {
        public List<ScreenRelease> Releases { get; set; }
    }
}
