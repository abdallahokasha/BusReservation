using System.Net;
using BusReservation.DAL.Interfaces;
using BusReservation.Data;
using BusReservation.Models.Entities;
using BusReservation.Models.Helpers;
using BusReservation.Models.Requests;
using BusReservation.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace BusReservation.DAL;

public class ReservationDal : IReservationDal
{
    private readonly BusReservationDbContext _dbContext;
    private const double SeatPrice = 10.0;
    private const int CairoAlexBusId = 1;
    private const double Discount80 = 0.8;
    private const double NoDiscount = 1.0;

    public ReservationDal(BusReservationDbContext busReservationDbContext)
    {
        _dbContext = busReservationDbContext;
    }

    public async Task<CoreResultModel<AddReservationResponse>> AddReservation(AddReservationRequest request)
    {
        var reservedBusTickets = _dbContext.Tickets.AsNoTracking().Where(x => x.BusNumber == request.BusNumber)
            .Select(x => x.SeatNumber).ToList();
        var requestReservedSeat = request.SeatsNumbers.Intersect(reservedBusTickets).ToList();
        if (requestReservedSeat.Count > 0)
            return new CoreResultModel<AddReservationResponse>( null, HttpStatusCode.BadRequest,
                $"error: seats {string.Join(", ", requestReservedSeat)} are already reserved!");

        var addedTicketsData = new List<TicketResponse>();
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var reservation = new Reservation
            {
                Key = "RSV" + Guid.NewGuid(),
            };
            var reservationEntry = _dbContext.Reservations.Add(reservation);
            await _dbContext.SaveChangesAsync();

            foreach (var requestSeatNumber in request.SeatsNumbers)
            {
                var ticketKey = "TCK" + Guid.NewGuid();
                addedTicketsData.Add(new TicketResponse { TicketKey = ticketKey, SeatNumber = requestSeatNumber });
                _dbContext.Tickets.Add(new Ticket
                {
                    BusNumber = request.BusNumber, CreatedAt = DateTime.UtcNow, IsDeleted = false, Price = SeatPrice,
                    ReservationId = reservationEntry.Entity.Id, Key = ticketKey, CreatedBy = request.UserEmail,
                    SeatNumber = requestSeatNumber, UpdatedAt = DateTime.UtcNow, UpdatedBy = request.UserEmail,
                    UserEmail = request.UserEmail,
                    TripRoute = request.BusNumber == 1 ? TripRoutes.CairoAlex : TripRoutes.CairoAswan
                });
            }

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            // If a failure occurred, we rollback to the savepoint and can continue the transaction
        }

        var response = new AddReservationResponse
        {
            UserEmail = request.UserEmail,
            Price = CalculatePrice(request.SeatsNumbers.Count),
            Tickets = addedTicketsData,
            BusKey = GetBusKey(request.BusNumber)
        };
        return new CoreResultModel<AddReservationResponse>(response, HttpStatusCode.Created);
    }

    public CoreResultModel<UsersFrequentTripsResponse> GetFrequentUsersTrips()
    {
        var frequentTrips = _dbContext.Tickets.AsNoTracking().GroupBy(t => new ReservationGroupingObject
        {
            BusId = t.BusNumber,
            UserEmail = t.UserEmail
        }).Select(x => new FrequentTripsData
        {
            UserEmail = x.Key.UserEmail,
            TripRoute = x.Key.BusId == CairoAlexBusId ? TripRoutes.CairoAlex : TripRoutes.CairoAswan
        }).ToList();
        return new CoreResultModel<UsersFrequentTripsResponse>(
            new UsersFrequentTripsResponse { FrequentUsersTrips = frequentTrips }, HttpStatusCode.OK, "");
    }

    private double CalculatePrice(int numberOfSeats)
    {
        return SeatPrice * numberOfSeats * (numberOfSeats >= 5 ? Discount80 : NoDiscount);
    }

    private string GetBusKey(int busNumber)
    {
        return busNumber == 1 ? "Bus-01" : "Bus-02";
    }
}