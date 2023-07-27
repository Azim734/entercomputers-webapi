using System.Net;

namespace EnterComputers.Domain.Exceptions
{
    public class BadRequestException : ClientException
    {
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public override string TitleMessage { get; protected set; } = string.Empty;
    }
}
