namespace Cinema.Models
{
    public interface Seat
    {
        int RowNumber { get; set; }
        int SeatNumber { get; set; }
        bool IsOccupied { get; set; }
    }
}
