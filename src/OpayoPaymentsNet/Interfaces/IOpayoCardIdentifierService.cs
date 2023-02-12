using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.MerchantSessionKey;
using OpayoPaymentsNet.Infrastructure.Models;

namespace OpayoPaymentsNet.Interfaces
{
    public interface IOpayoCardIdentifierService
    {
        Task<OpayoResponse<OpayoCreateIdentifierResponse>> CreateCardIdentifierAsync(string merchantSessionKey, OpayoCreateCardIdentifierRequest request);
        Task<OpayoResponse<OpayoMerchantSessionKeyResponse>> LinkCardIdentifierAsync(string cardIdentifier, OpayoLinkCardIdentifierRequest request);
    }
}