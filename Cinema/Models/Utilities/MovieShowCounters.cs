using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models.Utilities
{
    public class MovieShowCounters
    {
        [Key]
        public int Id { get; set; }
        public string BranchCode { get; set; }
        public int CounterId { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShowDate { get; set; }
    }
}
