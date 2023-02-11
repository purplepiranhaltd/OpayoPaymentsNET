
/* Unmerged change from project 'OpayoPaymentsNet (net6.0)'
Before:
using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
After:
using OpayoPaymentsNet;
using OpayoPaymentsNet.Domain;
using OpayoPaymentsNet.Domain.Builders;
using OpayoPaymentsNet.Domain.Builders.CardIdentifiers;
using OpayoPaymentsNet.Domain.Builders.CardIdentifiers;
using OpayoPaymentsNet.Domain.Builders.CardIdentifiers.Interfaces;
using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
*/
using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Builders.CardIdentifiers
{
    public interface IOpayoCreateCardIdentifierRequestBuilderWithCardNumber : IBuilder<OpayoCreateCardIdentifierRequest>
    {
    }

    public interface IOpayoCreateCardIdentifierRequestBuilderWithCardholderName : IBuilder<OpayoCreateCardIdentifierRequest>
    {
    }

    public interface IOpayoCreateCardIdentifierRequestBuilderWithExpiryDate : IBuilder<OpayoCreateCardIdentifierRequest>
    {
    }

    public interface IOpayoCreateCardIdentifierRequestBuilderWithSecurityCode : IBuilder<OpayoCreateCardIdentifierRequest>, IBuildableBuilder<OpayoCreateCardIdentifierRequest>
    {
    }

}
