using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class MovieShowSeats : ISeat
    {
        [Key]
        public int Id { get; set; }
        public string ShowCode { get; set; }
        public string SeatCode { get; set; }
        public bool IsBooked { get; set; } = false;


    }
}
