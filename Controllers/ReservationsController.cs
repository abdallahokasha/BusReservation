using BusReservation.Core.Interfaces;
using BusReservation.Models.Helpers;
using BusReservation.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BusReservation.Controllers;

[Route("api/1.0/[controller]/[action]")]
[ApiController]
public class ReservationsController : Controller
{
    private readonly string _authToken = "gjSkeBTp0dMTJVsR70ZJmg==";
    private readonly IReservationService _reservationService;
    private readonly ILogger _logger;
    
    public ReservationsController(IReservationService reservationService, ILogger<ReservationsController> logger)
    {
        _reservationService = reservationService;
        _logger = logger;
    }
    [HttpPost]
    public dynamic Add(AddReservationRequest request)
    {
        _logger.LogInformation(LogEventsTraces.AddReservation, "Add New Reservation");
        if (!Request.Headers[RequestHeaders.Token].Equals(_authToken))
            return new StatusCodeResult(401);

        return _reservationService.AddReservation(request);
    }
    
    [HttpGet]
    public dynamic FrequentUsersTrips()
    {
        _logger.LogInformation(LogEventsTraces.GetFrequentUsersTrips, "Get Frequent Users Trips");
        if (!Request.Headers[RequestHeaders.Token].Equals(_authToken))
            return new StatusCodeResult(401);
        return _reservationService.GetFrequentUsersTrips();
    }
}