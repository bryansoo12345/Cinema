using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public abstract class Hall
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the mall's name.")]

        public string MallCode { get; set; }

        public string? MallName { get; set; }

        [NotMapped]
        public string? MovieName { get; set; } //maybe need to remove soon


        [Required]
        public string HallCode { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }
}
