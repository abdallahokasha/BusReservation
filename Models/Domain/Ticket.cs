namespace BusReservation.Models.Domain;

public class Ticket
{
    public long Id { get; set; }
    
    public string Key { get; set; }
    
    public int  ReservationId { get; set; }
    
    public long SeatId { get; set; }
    
    public long BusId { get; set; }
    
    public double Price { get; set; } = 10;
}