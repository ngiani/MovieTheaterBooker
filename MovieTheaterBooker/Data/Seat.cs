using System.ComponentModel.DataAnnotations;

namespace MovieTheaterBooker.Data
{
    public class Seat
    {
        public int Id { get; set; }

        public Screen Screen { get; set; }

        [MaxLength(3)]
        public string Row { get; set; }

        public int Number { get; set; }
    }
}
