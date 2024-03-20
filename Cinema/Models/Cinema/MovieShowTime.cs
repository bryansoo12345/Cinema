using Cinema.Data;
using Cinema.Models.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string MovieCode { get; set; }
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

        [NotMapped] //MovieCode will be used to get Movie
        public Movie Movie { get; set; }

        [NotMapped]
        public IEnumerable<string> MovieSelections { get; set; }

        [NotMapped]
        public int DurationHours { get; set; }

        [NotMapped]
        public int DurationMinutes { get; set; }

        public string BuildMovieShowTimeCode(ApplicationDbContext _db)
        {

            MovieShowCounters MovieShowCounters = _db.MovieShowCounters.Where(x => x.BranchCode == LoginInfo.BranchCode && x.ShowDate == DateTime.Today).FirstOrDefault();

            string result = string.Empty;

            if (MovieShowCounters != null)
            {
                //counter id is not null
                result = $"{LoginInfo.BranchCode}{DateTime.Today.ToShortDateString().Replace("/", "")}{MovieShowCounters.CounterId:D3}";
                MovieShowCounters.CounterId = MovieShowCounters.CounterId + 1;
                _db.SaveChanges();
            }
            else
            {
                //counter Id is null
                result = $"{LoginInfo.BranchCode}{DateTime.Today.ToShortDateString().Replace("/", "")}{1:D3}";
                MovieShowCounters movieShowCounters = 
                    new MovieShowCounters 
                    { 
                        BranchCode = LoginInfo.BranchCode, 
                        CounterId = 1, 
                        ShowDate = DateTime.Today
                    };
                _db.MovieShowCounters.Add(movieShowCounters);
                _db.SaveChanges();
            }

            return result;
        }

    }
}
