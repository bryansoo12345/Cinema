using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.Models;
using Cinema.Models.AdminPanel;
using static Cinema.Models.MovieHallSeats;

namespace Cinema.Models
{
    public class MovieHall : Hall
    {
        #region View

        [NotMapped]
        [DisplayName("Hall Code")]
        public string ExternalCode
        {
            get
            {
                if (!string.IsNullOrEmpty(HallCode) && HallCode.Length >= 2)
                {
                    return HallCode.Substring(HallCode.Length - 2);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        [NotMapped]
        [DisplayName("Hall Code")]
        public string SelHallCode { get; set; }


        public class FilterHallModel
        {
            [DataType(DataType.Date)]
            [DisplayName("By Date")]
            public DateTime SelectedDate { get; set; }

            public FilterHallModel()
            {
                SelectedDate = DateTime.Today;
            }
        }

        [NotMapped]
        public IEnumerable<MovieShowTime> MovieShowTimes { get; set; }

        #endregion

        public int NumberOfRows { get; set; }

        public int NumberOfSeats { get; set; }

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
