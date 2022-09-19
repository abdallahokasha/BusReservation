namespace BusReservation.Models.Responses;

public class AddReservationResponse
{
    public string UserEmail { get; set; }

    public List<TicketResponse> Tickets { get; set; } = new List<TicketResponse>();
    
    public string BusKey { get; set; }

    public double Price { get; set; } = 10;
}