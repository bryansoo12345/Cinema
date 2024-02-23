namespace Cinema.Models
{
    public interface ISeat
    {
        string MovieShowTimeCode { get; set; }
        string SeatCode { get; set; }
        bool IsBooked { get; set; }

    }
}
