using System.Net;

namespace BusReservation.Models.Helpers;

public class CoreResultModel<T>
{
    public T ReturnObject { get; private set; }

    public HttpStatusCode Status { get; set; }

    public string ErrorMessage { get; private set; }

    public CoreResultModel(T returnObject, HttpStatusCode status)
    {
        this.ReturnObject = returnObject;
        this.Status = status;
    }

    public CoreResultModel(T returnObject, HttpStatusCode status, string exceptionText)
        : this(returnObject, status)
    {
        this.ErrorMessage = exceptionText;
    }
}