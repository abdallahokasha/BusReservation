namespace BusReservation.Models.Entities;

public class Reservation 
{
    public long Id { get; set; }
    public string Key { get; set; }

    public List<Ticket> Tickets { get; set; }
}