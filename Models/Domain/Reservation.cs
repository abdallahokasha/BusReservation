namespace BusReservation.Models.Domain;

public class Reservation
{
    public long Id { get; set; }
    
    public string Key { get; set; }
    
    public string UserEmail { get; set; }

    public List<int> SeatsNumbers { get; set; } = new List<int>();
    
    public long BusId { get; set; } 
    
    public double Price { get; set; }
}