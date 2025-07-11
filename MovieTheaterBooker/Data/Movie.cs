using System.ComponentModel.DataAnnotations;


namespace MovieTheaterBooker.Data
{
    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public string Plot { get; set; }

        [MaxLength(25)]
        public string Genre { get; set; }

        [Range(60, 180)]
        public int Duration { get; set; }
    }
}
