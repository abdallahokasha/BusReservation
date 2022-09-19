namespace BusReservation.Models.Domain;

public class Bus 
{
    public Guid Id { get; set; }
    
    public string Key { get; set; }

    public int NumberOfSeats { get; set; } = 20;

    public TripTypes TripType { get; set; } = TripTypes.Short;
    
    public TripRoutes TripRoute { get; set; } = TripRoutes.CairoAlex;
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