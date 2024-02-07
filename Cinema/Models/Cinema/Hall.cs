using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public abstract class Hall
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the mall's name.")]
        public string MallName { get; set; }

        [Required]
        public string HallCode { get; set; }

        public DateTime CreatedDateTime { get; set; }

        protected Hall()
        {
            CreatedDateTime = DateTime.Now;
        }
    }
}
