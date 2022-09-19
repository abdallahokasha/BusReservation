namespace BusReservation.Models.Domain;

public class Ticket : BaseEntity
{
    public long Id { get; set; }
    
    public string Key { get; set; }
    
    public int  ReservationId { get; set; }
    
    public long SeatId { get; set; }
    
    public double Price { get; set; } = 10.0;
}