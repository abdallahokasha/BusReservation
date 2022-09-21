using System.Net;

namespace BusReservation.Models.Helpers;

public class CoreResultModel<T>
{
    public T Result { get; private set; }

    public HttpStatusCode Status { get; set; }

    public string ErrorMessage { get; private set; }

    public CoreResultModel(T result, HttpStatusCode status)
    {
        this.Result = result;
        this.Status = status;
    }

    public CoreResultModel(T result, HttpStatusCode status, string errorMessage)
        : this(result, status)
    {
        this.ErrorMessage = errorMessage;
    }
}