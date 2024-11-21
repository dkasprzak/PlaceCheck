using System.Net;

namespace PlaceCheck.Application.Exceptions;

public class ApiException : Exception
{
    public HttpStatusCode StatusCode { get; private set; }
    public string ErrorContent { get; private set; }

    public ApiException(HttpStatusCode statusCode, string errorContent)
    {
        StatusCode = statusCode;
        ErrorContent = errorContent;
    }
}
