namespace BusReservation.Models.Domain;

public class BaseEntity
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }
}