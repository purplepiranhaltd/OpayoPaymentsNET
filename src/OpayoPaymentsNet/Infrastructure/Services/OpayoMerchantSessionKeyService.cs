using Microsoft.Extensions.Options;
using OpayoPaymentsNet.Domain.Entities.MerchantSessionKey;
using OpayoPaymentsNet.Infrastructure.Models;
using OpayoPaymentsNet.Infrastructure.Settings;
using OpayoPaymentsNet.Interfaces;

namespace OpayoPaymentsNet.Infrastructure.Services
{
    public class OpayoMerchantSessionKeyService : IOpayoMerchantSessionKeyService
    {
        private readonly IOpayoRestApiClientService _opayoRestApiClientService;
        private readonly IOptions<OpayoSettings> _settings;
        private const string MERCHANT_SESSION_KEYS_ENDPOINT = "/merchant-session-keys";

        public OpayoMerchantSessionKeyService(IOpayoRestApiClientService opayoRestApiClientService, IOptions<OpayoSettings> settings) 
        {
            _opayoRestApiClientService = opayoRestApiClientService;
            _settings = settings;
        }

        public async Task<OpayoResponse<OpayoMerchantSessionKeyResponse>> CheckMerchantSessionKeyAsync(string merchantSessionKey)
        {
            var opayoRequest = new OpayoRequest(_settings.Value, $"{MERCHANT_SESSION_KEYS_ENDPOINT}/{merchantSessionKey}", HttpMethod.Get);
            return await _opayoRestApiClientService.SendAsync(opayoRequest);
        }

        public async Task<OpayoResponse<OpayoMerchantSessionKeyResponse>> CreateMerchantSessionKeyAsync()
        {
            var request = new OpayoCreateMerchantSessionKeyRequest(_settings.Value.VendorName);
            var opayoRequest = new OpayoRequest<OpayoCreateMerchantSessionKeyRequest>(_settings.Value, $"{MERCHANT_SESSION_KEYS_ENDPOINT}", HttpMethod.Post, request);
            return await _opayoRestApiClientService.SendAsync(opayoRequest);
        }
    }
}
