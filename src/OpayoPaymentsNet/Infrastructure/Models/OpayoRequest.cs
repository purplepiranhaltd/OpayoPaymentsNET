using OpayoPaymentsNet.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Infrastructure.Models
{
    public class OpayoRequest : IOpayoRequest
    {
        /// <summary>
        /// Wrapper for sending a request to Opayo vis the OpayoRestApiClientService
        /// </summary>
        /// <param name="settings">Common settings for Opayo</param>
        /// <param name="endpoint">The endpoint to send the request to</param>
        /// <param name="httpMethod">The method of the HTTP request</param>
        /// <param name="payloadInJson">The payload being sent</param>
        /// <param name="merchantSessionKey">The merchant session key (if required for authorization - CardIdentifiers endpoint only)</param>
        public OpayoRequest(OpayoSettings settings, string endpoint, HttpMethod httpMethod, string? merchantSessionKey = null)
        {
            Settings = settings;
            Endpoint = endpoint;
            HttpMethod = httpMethod;
            MerchantSessionKey = merchantSessionKey;
        }

        public OpayoSettings Settings { get; private set; }

        public string Endpoint { get; private set; }

        public HttpMethod HttpMethod { get; private set; }

        public string? PayloadInJson { get; private set; }

        public string? MerchantSessionKey { get; private set; }
    }

    public class OpayoRequest<T> : IOpayoRequest, IOpayoRequest<T> where T : class
    {
        /// <summary>
        /// Wrapper for sending a request to Opayo vis the OpayoRestApiClientService
        /// </summary>
        /// <param name="settings">Common settings for Opayo</param>
        /// <param name="endpoint">The endpoint to send the request to</param>
        /// <param name="httpMethod">The method of the HTTP request</param>
        /// <param name="payload">The payload being sent</param>
        /// <param name="merchantSessionKey">The merchant session key (if required for authorization - CardIdentifiers endpoint only)</param>
        public OpayoRequest(OpayoSettings settings, string endpoint, HttpMethod httpMethod, T? payload = null, string? merchantSessionKey = null)
        {
            Settings = settings;
            Endpoint = endpoint;
            HttpMethod = httpMethod;
            Payload = payload;

            // convert payload to json
            if (payload is not null)
            {
                PayloadInJson = JsonSerializer.Serialize(payload, OpayoSettings.JsonSerializerOptions);
            }
            
            MerchantSessionKey = merchantSessionKey;
        }

        public OpayoSettings Settings { get; private set; }
        public string Endpoint { get; private set; }
        public HttpMethod HttpMethod { get; private set; }
        public T? Payload { get; private set; }
        public string? PayloadInJson { get; private set; }

        public string? MerchantSessionKey { get; private set; }
    }
}
