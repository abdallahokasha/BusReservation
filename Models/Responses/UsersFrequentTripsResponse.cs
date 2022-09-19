using BusReservation.Models.Domain;

namespace BusReservation.Models.Responses;

public class UsersFrequentTripsResponse
{
    public List<FrequentTripsData> FrequentUsersTrips = new List<FrequentTripsData>();
}

public class FrequentTripsData
{
    public string UserEmail { get; set; }
    
    public TripRoutes TripRoute { get; set; }
}