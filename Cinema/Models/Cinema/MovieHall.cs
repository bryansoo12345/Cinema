using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.Models;
using static Cinema.Models.MovieHallSeats;

namespace Cinema.Models
{
    public class MovieHall : Hall
    {
        public int NumberOfRows { get; set; }

        public int NumberOfSeats { get; set; }

        [NotMapped]
        public List<Movie> ShowingMovies { get; set; }

        [NotMapped]
        public List<MovieHallSeats> Seats { get; set; }

        public void AddMovie(Movie movie)
        {

        }

        public void RemoveMovie(Movie movie)
        {

        }

        public static List<MovieHallSeats> PopulateSeats(int NumOfRows, int NumOfSeats)
        {
            List<MovieHallSeats> Seats = new List<MovieHallSeats>();
            int rowIndex = 0;

            // Populate Seats based on NumberOfRows and NumberOfSeats
            for (int i = 1; i <= NumOfRows; i++)
            {
                RowCode currentRowCode = (RowCode)rowIndex;

                for (int j = 1; j <= NumOfSeats; j++)
                {
                    Seats.Add(new MovieHallSeats { RowNumber = i, SeatNumber = j, SeatCode= currentRowCode.ToString() + j });
                }
                rowIndex++;
            }
            return Seats;
        }
            
    }
}
