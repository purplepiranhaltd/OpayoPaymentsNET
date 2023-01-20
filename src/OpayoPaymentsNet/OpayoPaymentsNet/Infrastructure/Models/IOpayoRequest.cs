using OpayoPaymentsNet.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Infrastructure.Models
{
    public interface IOpayoRequest
    {
        OpayoSettings Settings { get; }
        string Endpoint { get; }
        HttpMethod HttpMethod { get; }
        string? PayloadInJson { get; }
        string? MerchantSessionKey { get; }
    }

    public interface IOpayoRequest<T> : IOpayoRequest where T : class
    {
        T? Payload { get; }
    }
}
