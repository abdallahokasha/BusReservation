using System.Net;
using BusReservation.Core.Interfaces;
using BusReservation.DAL.Interfaces;
using BusReservation.Models.Helpers;
using BusReservation.Models.Requests;
using BusReservation.Models.Responses;

namespace BusReservation.Core;

public class ReservationService : IReservationService
{
    private readonly IReservationDal _reservationDal;

    public ReservationService(IReservationDal reservationDal)
    {
        _reservationDal = reservationDal;
    }
    public async Task<CoreResultModel<AddReservationResponse>> AddReservation(AddReservationRequest request)
    {
        if (!request.IsValid())
            return new CoreResultModel<AddReservationResponse>(new AddReservationResponse(),
                HttpStatusCode.BadRequest, "error: user email, bus or seats empty");
        
        return  await _reservationDal.AddReservation(request);
    }

    public  CoreResultModel<UsersFrequentTripsResponse> GetFrequentUsersTrips()
    {
        return  _reservationDal.GetFrequentUsersTrips();
    }
}