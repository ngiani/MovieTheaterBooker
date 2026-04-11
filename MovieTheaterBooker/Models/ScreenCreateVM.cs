using MovieTheaterBooker.Data;
using System.ComponentModel.DataAnnotations;

namespace MovieTheaterBooker.Models
{
    public class ScreenCreateVM : Screen
    {
        [Range(3, 8)]
        public int rowsCount { get; set; }

        [Range(5, 10)]
        public int rowsLength { get; set; }
    }
}
