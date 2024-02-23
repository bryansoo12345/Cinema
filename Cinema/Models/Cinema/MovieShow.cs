//using Cinema.Models.Cinema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class MovieShow
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MallCode { get; set; } 
        [Required]
        public string MovieCode { get; set; } // build with MallCode+MV+count . Count is 4 Digit

        [Required(ErrorMessage = "Please enter the movie name.")]
        public string MovieName { get; set; }

        [Required]
        public string HallCode { get; set; }

        [Required]
        public DateTime ShowDate { get; set; }
        [Required]
        public string MovieShowTimeCode { get; set; } //build with format MallCode+MovieCode+Date+Count EXAMPLE: OUOUMV00012024172001. Count is 3 Digit

        public List<MovieShowTime> MovieShowTimes { get; set; }
        [NotMapped]
        public Movie Movie { get; set; }



    }
}
