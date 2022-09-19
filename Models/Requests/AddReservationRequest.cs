namespace BusReservation.Models.Requests;

public class AddReservationRequest
{
    public string UserEmail { get; set; }

    public List<int> SeatsNumbers { get; set; } = new List<int>();
    
    public string BusKey { get; set; }

    public virtual bool IsValid()
    {
        if (string.IsNullOrEmpty(UserEmail) || string.IsNullOrEmpty(BusKey) || SeatsNumbers.Count == 0)
            return false;
        return true;
    }
}