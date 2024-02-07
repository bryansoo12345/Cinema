using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the movie name.")]
        public string Name { get; set; }
        public string Description { get; set; }

        public string Genre { get; set; }

        public byte[]? CoverPhoto { get; set; }

        [Display(Name = "Choose the cover for the movie")]
        [NotMapped]
        public IFormFile? IFormPhoto { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public enum GenreType
        {
            Action,
            Drama,
            Comedy,
            Thriller
        }

    }
}
