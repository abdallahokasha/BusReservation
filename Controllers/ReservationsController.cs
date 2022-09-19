using BusReservation.Core.Interfaces;
using BusReservation.Models.Helpers;
using BusReservation.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BusReservation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ReservationsController : Controller
{
    private readonly IReservationService _reservationService;
    private readonly string _authToken = "gjSkeBTp0dMTJVsR70ZJmg==";
    
    public ReservationsController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    
    }
    [HttpPost]
    public dynamic Add(AddReservationRequest request)
    {
        if (!Request.Headers[RequestHeaders.Token].Equals(_authToken))
            return new StatusCodeResult(401);

        return _reservationService.AddReservation(request);
    }
    
    [HttpGet]
    public dynamic FrequentTripsForUsers()
    {
        if (!Request.Headers[RequestHeaders.Token].Equals(_authToken))
            return new StatusCodeResult(401);
        return _reservationService.GetFrequentUsersTrips();
    }
}