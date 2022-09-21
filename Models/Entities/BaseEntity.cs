namespace BusReservation.Models.Entities;

public class BaseEntity
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public bool IsDeleted { get; set; } = false;
}