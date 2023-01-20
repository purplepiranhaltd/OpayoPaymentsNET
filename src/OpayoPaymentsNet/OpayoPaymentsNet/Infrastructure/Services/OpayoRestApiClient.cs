using Microsoft.Net.Http.Headers;
using OpayoPaymentsNet.Infrastructure.Models;
using OpayoPaymentsNet.Infrastructure.Settings;
using System.Net;
using System.Text;
using System.Text.Json;

namespace OpayoPaymentsNet.Infrastructure.Services
{
    public class OpayoRestApiClientService
    {
        #region Fields
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        #endregion

        #region Ctor
        public OpayoRestApiClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(20); //TODO: Should we do this another way?
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        #endregion

        #region Methods
        public OpayoResponse Send(IOpayoRequest request)
        {

            try
            {
                var httpRequestMessage = CreateHttpRequestMessage(request); 

                var response = _httpClient.Send(httpRequestMessage);
                var stream = response.Content.ReadAsStream();
                stream.Position = 0;
                string responseContent;

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    responseContent = reader.ReadToEnd();
                }

                return new OpayoResponse(response.IsSuccessStatusCode, response.StatusCode, responseContent);
            }
            catch (AggregateException e)
            {
                //rethrow actual exception
                throw e.InnerException;
            }
        }

        public OpayoResponse<T> Send<T>(IOpayoRequest request) where T : class
        {
            return Send(request);
        }

        public async Task<OpayoResponse> SendAsync(IOpayoRequest request)
        {

            try
            {
                var httpRequestMessage = CreateHttpRequestMessage(request);

                _httpClient.Timeout = TimeSpan.FromSeconds(20);
                _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

                var response = await _httpClient.SendAsync(httpRequestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                return new OpayoResponse(response.IsSuccessStatusCode, response.StatusCode, responseContent);
            }
            catch (AggregateException e)
            {
                //rethrow actual exception
                throw e.InnerException;
            }
        }

        public async Task<OpayoResponse<T>> SendAsync<T>(IOpayoRequest request) where T : class
        {
            return await SendAsync(request);
        }
        #endregion

        #region Helpers
        private HttpRequestMessage CreateHttpRequestMessage(IOpayoRequest request)
        {
            var httpRequestMessage = new HttpRequestMessage(request.HttpMethod, $"{request.Settings.OpayoEnvironmentUrl}/{request.Endpoint}");

            if (request.MerchantSessionKey is null)
            {
                var byteArray = Encoding.ASCII.GetBytes($"{request.Settings.IntegrationKey}:{request.Settings.IntegrationPassword}");
                var encodedCredentials = Convert.ToBase64String(byteArray);
                httpRequestMessage.Headers.Add(HeaderNames.Authorization, $"Basic {encodedCredentials}");
            }
            else
            {
                httpRequestMessage.Headers.Add(HeaderNames.Authorization, $"Bearer {request.MerchantSessionKey}");
            }

            if (request.PayloadInJson is not null)
            {
                var content = new StringContent(request.PayloadInJson, Encoding.UTF8, "application/json");
                httpRequestMessage.Content = content;
            }

            return httpRequestMessage;
        }
        #endregion
    }
}
