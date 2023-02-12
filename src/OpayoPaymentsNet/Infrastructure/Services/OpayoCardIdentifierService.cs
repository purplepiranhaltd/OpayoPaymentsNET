using Microsoft.Extensions.Options;
using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.MerchantSessionKey;
using OpayoPaymentsNet.Infrastructure.Models;
using OpayoPaymentsNet.Infrastructure.Settings;
using OpayoPaymentsNet.Interfaces;

namespace OpayoPaymentsNet.Infrastructure.Services
{
    public class OpayoCardIdentifierService : IOpayoCardIdentifierService
    {
        private readonly IOpayoRestApiClientService _opayoRestApiClientService;
        private readonly IOptions<OpayoSettings> _settings;
        private const string CARD_IDENTIFIERS_ENDPOINT = "/card-identifiers";

        public OpayoCardIdentifierService(IOpayoRestApiClientService opayoRestApiClientService, IOptions<OpayoSettings> settings)
        {
            _opayoRestApiClientService = opayoRestApiClientService;
            _settings = settings;
        }

        public async Task<OpayoResponse<OpayoMerchantSessionKeyResponse>> LinkCardIdentifierAsync(string cardIdentifier, OpayoLinkCardIdentifierRequest request)
        {
            var opayoRequest = new OpayoRequest(_settings.Value, $"{CARD_IDENTIFIERS_ENDPOINT}/{cardIdentifier}/security-code", HttpMethod.Post);
            return await _opayoRestApiClientService.SendAsync(opayoRequest);
        }

        public async Task<OpayoResponse<OpayoCreateIdentifierResponse>> CreateCardIdentifierAsync(string merchantSessionKey, OpayoCreateCardIdentifierRequest request)
        {
            var opayoRequest = new OpayoRequest<OpayoCreateCardIdentifierRequest>(_settings.Value, $"{CARD_IDENTIFIERS_ENDPOINT}", HttpMethod.Post, request, merchantSessionKey);
            return await _opayoRestApiClientService.SendAsync(opayoRequest);
        }
    }
}
