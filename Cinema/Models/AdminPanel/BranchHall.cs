using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cinema.Models
{
    public class BranchHall
    {
        [Key]
        public int Id { get; set; }
        public string MallCode { get; set; }
        public string HallCode { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public List<MovieShowTime> MovieShowTimes { get; set; }

    }
}
