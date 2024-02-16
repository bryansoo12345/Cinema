using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class CinemaBranch : IImageEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cinema Location")]
        public string MallName { get; set; }

        public string MallCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Address { get; set; }

        #region Photo
        [Display(Name = "Choose the cover for the movie")]
        [NotMapped]
        public IFormFile? IFormPhoto { get; set; }

        [Display(Name = "Cinema Photo")]
        public byte[]? PhotoFile { get; set; }    

        #endregion
    }
}
