using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class MovieShowTime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MovieShowTimeCode { get; set; }
        [Required]
        public string MallName { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string HallCode { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        public class BookMovieViewModel
        {
            public List<MovieShowSeats> MovieShowSeats { get; set; }
            public MovieShowTime MovieShowTime { get; set; }
        }
        public class SetShowTimeModel : MovieShowTime
        {
            public List<string> SeatCodes { get; set; }
        }
        public class BookTicketModel : MovieShowTime
        {
            public List<string> DesiredSeats { get; set; }
        }
    }
}
