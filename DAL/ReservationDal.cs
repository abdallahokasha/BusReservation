using System.Net;
using BusReservation.DAL.Interfaces;
using BusReservation.Data;
using BusReservation.Models.Domain;
using BusReservation.Models.Helpers;
using BusReservation.Models.Requests;
using BusReservation.Models.Responses;

namespace BusReservation.DAL;

public class ReservationDal : IReservationDal
{
    private readonly BusReservationDbContext _dbContext;
    private const double SeatPrice = 10.0;
    private const int CairoAlexBusId = 1;

    
    public ReservationDal(BusReservationDbContext busReservationDbContext)
    {
        _dbContext = busReservationDbContext;
    }
    public async Task<CoreResultModel<AddReservationResponse>> AddReservation(AddReservationRequest request)
    {
        // TODO: add db validations here
        var reservation = new Reservation {
        UserEmail = request.UserEmail,
        Price = SeatPrice * request.SeatsNumbers.Count,
        BusId = 1,
        Key = "RSV" + Guid.NewGuid(),
        SeatsNumbers = new List<int>{1, 2}
        };
        _dbContext.Reservations.Add(reservation);
        await _dbContext.SaveChangesAsync();

        var response = new AddReservationResponse{UserEmail = request.UserEmail, Price = SeatPrice * request.SeatsNumbers.Count}; // TODO: response fill object
        return new CoreResultModel<AddReservationResponse>(response, HttpStatusCode.Created);
    }

    public CoreResultModel<UsersFrequentTripsResponse> GetFrequentUsersTrips()
    {
        var frequentTrips  = _dbContext.Reservations.GroupBy(r => new ReservationGroupingObject()
        {
            BusId = r.BusId,
            UserEmail = r.UserEmail
        }).Select(x => new FrequentTripsData{UserEmail = x.Key.UserEmail,
            TripRoute = x.Key.BusId == CairoAlexBusId ? TripRoutes.CairoAlex : TripRoutes.CairoAswan}).ToList();
        return new CoreResultModel<UsersFrequentTripsResponse>(new UsersFrequentTripsResponse{FrequentUsersTrips =  frequentTrips}, HttpStatusCode.OK);
    }
}