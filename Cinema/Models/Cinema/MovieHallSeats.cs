using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class MovieHallSeats
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HallCode { get; set; }

        [Required]
        public int RowNumber { get; set; }

        [Required]
        public int SeatNumber { get; set; }
                
        [NotMapped]
        public string SeatCode { get; set; }
            
        public enum RowCode
        {
            A,B,C,D,E,F,G, H,I,J,K,L,M,N,O,P,Q,R,S,T,U,
        }

    }
}
