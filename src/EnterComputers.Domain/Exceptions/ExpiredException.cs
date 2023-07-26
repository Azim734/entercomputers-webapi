using System.Net;

namespace EnterComputers.Domain.Exceptions;

public class ExpiredException : Exception 
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.Gone;

    public string TitleMessage { get; protected set; } = string.Empty;
}
