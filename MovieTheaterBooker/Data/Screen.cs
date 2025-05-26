using System.ComponentModel.DataAnnotations;

namespace MovieTheaterBooker.Data
{
    public class Screen
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        
    }
}
