using System.Net;

namespace EasyRedmineApiClient;

public sealed class EasyRedmineException : Exception
{
    public HttpStatusCode HttpStatusCode { get; }
    
    public EasyRedmineException(HttpStatusCode statusCode)
        => HttpStatusCode = statusCode;

    public EasyRedmineException(HttpStatusCode statusCode, string message) : base(message)
        => HttpStatusCode = statusCode;
    
    public EasyRedmineException(HttpStatusCode statusCode, string message, Exception innerException) 
        : base(message, innerException)
        => HttpStatusCode = statusCode;
}