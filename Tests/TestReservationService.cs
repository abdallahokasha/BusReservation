using BusReservation.Models.Requests;
using NUnit.Framework;

namespace BusReservation.Tests;

public class TestReservationService
{
    [Test]
    [Description("Test add reservation request validation function")]
    public void TestIsValidRequest()
    {
        AddReservationRequest addReservationRequest1 = new AddReservationRequest
        {
            BusNumber = 1,
            UserEmail = "abc@xyz.com",
            SeatsNumbers = new List<int> { 1, 2 }
        };
        Assert.IsTrue(addReservationRequest1.IsValid());
        
        AddReservationRequest addReservationRequest2 = new AddReservationRequest
        {
            BusNumber = 0,
            UserEmail = "abc@xyz.com",
            SeatsNumbers = new List<int> { 1, 2 }
        };
        Assert.IsFalse(addReservationRequest2.IsValid());
        
        AddReservationRequest addReservationRequest3 = new AddReservationRequest
        {
            BusNumber = 1,
            UserEmail = "",
            SeatsNumbers = new List<int> { 1, 2 }
        };
        Assert.IsFalse(addReservationRequest2.IsValid());
    }
}