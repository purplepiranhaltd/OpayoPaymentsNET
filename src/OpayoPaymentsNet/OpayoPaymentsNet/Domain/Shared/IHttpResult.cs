using System.Net;

namespace OpayoPaymentsNet.Domain.Shared;

public interface IHttpResult
{
    public static readonly Error HttpFailureError = new(
        "HttpFailureError",
        "An unsuccessful status code was returned.");

    public HttpStatusCode HttpStatusCode { get; }

    public string Message { get; }
}

public interface IHttpResult<T> : IHttpResult
{
}
