using BusReservation.Models.Helpers;
using BusReservation.Models.Requests;
using BusReservation.Models.Responses;

namespace BusReservation.DAL.Interfaces;

public interface IReservationDal
{
    public Task<CoreResultModel<AddReservationResponse>> AddReservation(AddReservationRequest request);

    public CoreResultModel<UsersFrequentTripsResponse> GetFrequentUsersTrips();
}