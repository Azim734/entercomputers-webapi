using System.Net;

namespace EnterComputers.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;

        public string TitleMessage { get; protected set; } = string.Empty;
    }
}
