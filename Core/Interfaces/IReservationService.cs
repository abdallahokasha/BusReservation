using BusReservation.Models.Helpers;
using BusReservation.Models.Requests;
using BusReservation.Models.Responses;

namespace BusReservation.Core.Interfaces;

public interface IReservationService
{
    public Task<CoreResultModel<AddReservationResponse>> AddReservation(AddReservationRequest request);

    public CoreResultModel<UsersFrequentTripsResponse> GetFrequentUsersTrips();
}