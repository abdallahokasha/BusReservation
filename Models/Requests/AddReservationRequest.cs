namespace BusReservation.Models.Requests;

public class AddReservationRequest
{
    public string UserEmail { get; set; }

    public List<int> SeatsNumbers { get; set; }
    
    public int BusNumber { get; set; } // bus 1 for Cairo-Alex trips bus 2 for CairoAswan 

    public virtual bool IsValid()
    {
        if (string.IsNullOrEmpty(UserEmail) || BusNumber < 0 || SeatsNumbers.Count == 0)
            return false;
        return true;
    }
}