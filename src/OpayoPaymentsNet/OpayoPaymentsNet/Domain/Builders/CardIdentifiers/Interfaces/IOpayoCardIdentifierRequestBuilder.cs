using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Builders.CardIdentifiers.Interfaces
{
    public interface IOpayoCardIdentifierRequestBuilder
    {
        IOpayoCardIdentifierRequestBuilder WithCardNumber(string cardnumber);
        IOpayoCardIdentifierRequestBuilder WithCardholderName(string cardholderName);
        IOpayoCardIdentifierRequestBuilder WithExpiryDate(string expiryDate);
        IOpayoCardIdentifierRequestBuilder WithSecurityCode(string securityCode);
        Result<OpayoCardIdentifierRequest> Build();
    }

}
