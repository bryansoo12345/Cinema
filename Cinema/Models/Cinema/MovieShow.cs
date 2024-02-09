using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class MovieShow
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the movie name.")]
        public string MovieName { get; set; }
        [Required]
        public string MovieCode { get; set; }
        [Required]
        public string MallCode { get; set; }
        [Required]
        public string HallCode { get; set; }

        public class MovieShowModel : MovieShow
        {
            public List<string> SeatCodes { get; set; }
        }

    }
}
