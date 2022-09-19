namespace BusReservation.Models.Domain;

public class Seat
{
    public long Id { get; set; }
    
    public string Key { get; set; }
    
    public long BusId { get; set; }

    public bool Reserved { get; set; } = false;
}