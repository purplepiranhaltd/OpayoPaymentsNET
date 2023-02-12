using OpayoPaymentsNet.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Infrastructure.Models
{
    public class OpayoResponse : IOpayoResponse
    {
        public OpayoResponse(bool isSuccess, HttpStatusCode httpStatusCode, string? response) 
        { 
            IsSuccess= isSuccess;
            HttpStatusCode= httpStatusCode;
            RawResponse = response;
        }

        public bool IsSuccess { get; private set; }

        public HttpStatusCode HttpStatusCode { get; private set; }

        public string? RawResponse { get; private set; }
    }

    public class OpayoResponse<T> : IOpayoResponse where T : class
    {
        public OpayoResponse(OpayoResponse response)
        {
            IsSuccess= response.IsSuccess;
            HttpStatusCode= response.HttpStatusCode;
            RawResponse = response.RawResponse;

            if (RawResponse is not null)
            {
                Response = JsonSerializer.Deserialize<T>(RawResponse, OpayoSettings.JsonSerializerOptions);
            }
        }

        public static implicit operator OpayoResponse<T>(OpayoResponse r) => new OpayoResponse<T>(r);

        public bool IsSuccess { get; private set; }

        public HttpStatusCode HttpStatusCode { get; private set; }

        public string? RawResponse { get; private set; }

        public T? Response { get; private set; }
    }
}