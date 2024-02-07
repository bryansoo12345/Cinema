using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class CinemaBranch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MallName { get; set; }
        public string MallCode { get; set; }
        public string? City { get; set; }
        public string? Sate { get; set; }
        public string? Address { get; set; }

        public DateTime CreatedDateTime = DateTime.Now;
    }
}
