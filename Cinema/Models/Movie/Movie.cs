using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Movie : IImageEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the movie name.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        [Required]
        public string MovieCode { get; set; }
        #region Photo

        [Display(Name = "Choose the cover for the movie")]
        [NotMapped]
        public IFormFile? IFormPhoto { get; set; }

        public byte[]? PhotoFile { get; set; }

        #endregion

        public enum GenreType
        {
            Action,
            Drama,
            Comedy,
            Thriller
        }

        public class BuyTicketViewModel
        {
            public CinemaBranch CinemaBranch { get; set; }
            public IEnumerable<MovieShow> MovieShows { get; set; }
        }
    }

}
