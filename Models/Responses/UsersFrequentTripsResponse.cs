using BusReservation.Models.Entities;

namespace BusReservation.Models.Responses;

public class UsersFrequentTripsResponse
{
    public List<FrequentTripsData> FrequentUsersTrips { get; set; }
}

public class FrequentTripsData
{
    public string UserEmail { get; set; }
    
    public string TripRoute { get; set; }
}