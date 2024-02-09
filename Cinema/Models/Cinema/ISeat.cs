namespace Cinema.Models
{
    public interface ISeat
    {
        string ShowCode { get; set; }
        string SeatCode { get; set; }
        bool IsBooked { get; set; }

    }
}
