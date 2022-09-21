namespace BusReservation.Models.Entities;

public class Ticket : BaseEntity
{
    public long Id { get; set; }
    
    public string Key { get; set; }
    
    public string UserEmail { get; set; }
    
    public int SeatNumber { get; set; }
    
    public int BusNumber {get; set; } 
    
    public long ReservationId { get; set; }

    public TripRoutes TripRoute { get; set; } = TripRoutes.CairoAlex;
    
    public double Price { get; set; } = 10.0;
    
}

public enum TripTypes
{
    Short,
    Long
}

public enum TripRoutes
{
    CairoAlex, 
    CairoAswan
}