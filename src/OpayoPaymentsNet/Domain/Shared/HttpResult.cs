using System.Net;

namespace OpayoPaymentsNet.Domain.Shared;

public sealed class HttpResult : Result, IHttpResult
{
    private HttpResult(HttpStatusCode httpStatusCode, bool isSuccess, string message = "")
        : base(isSuccess, isSuccess ? Error.None : IHttpResult.HttpFailureError)
    {
        HttpStatusCode = httpStatusCode;
        Message = Message;
    }

    public HttpStatusCode HttpStatusCode { get; }

    public string Message { get; }

    public static HttpResult WithFailure(HttpStatusCode httpStatusCode, string message) => new(httpStatusCode, false, message);
    public static HttpResult WithSuccess(HttpStatusCode httpStatusCode) => new(httpStatusCode, true);
}

public sealed class HttpResult<TValue> : Result<TValue>, IHttpResult, IHttpResult<TValue>
{
    private HttpResult(HttpStatusCode httpStatusCode, bool isSuccess, string message = "")
        : base(default, false, isSuccess ? Error.None : IHttpResult.HttpFailureError)
    {
        HttpStatusCode = httpStatusCode;
        Message = message;
    }

    public HttpStatusCode HttpStatusCode { get; }

    public string Message { get; }

    public static HttpResult<TValue> WithFailure(HttpStatusCode httpStatusCode, string resultContent) => new(httpStatusCode, false, resultContent);
    public static HttpResult<TValue> WithSuccess(HttpStatusCode httpStatusCode) => new(httpStatusCode, true);
}
