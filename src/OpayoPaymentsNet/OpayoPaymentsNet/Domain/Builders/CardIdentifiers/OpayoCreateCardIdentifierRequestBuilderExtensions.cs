using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Builders.CardIdentifiers
{
    public static class OpayoCreateCardIdentifierRequestBuilderExtensions
    {
        public static IOpayoCreateCardIdentifierRequestBuilderWithCardholderName WithCardholderName(this INewBuilder<OpayoCreateCardIdentifierRequest> builder, string cardholderName)
        {
            builder.Object.CardDetails.CardholderName = cardholderName;
            return (IOpayoCreateCardIdentifierRequestBuilderWithCardholderName)builder;
        }

        public static IOpayoCreateCardIdentifierRequestBuilderWithCardNumber WithCardNumber(this IOpayoCreateCardIdentifierRequestBuilderWithCardholderName builder, string cardnumber)
        {
            builder.Object.CardDetails.CardNumber = cardnumber;
            return (IOpayoCreateCardIdentifierRequestBuilderWithCardNumber)builder;
        }

        public static IOpayoCreateCardIdentifierRequestBuilderWithExpiryDate WithExpiryDate(this IOpayoCreateCardIdentifierRequestBuilderWithCardNumber builder, string expiryDate)
        {
            builder.Object.CardDetails.ExpiryDate = expiryDate;
            return (IOpayoCreateCardIdentifierRequestBuilderWithExpiryDate)builder;
        }

        public static IOpayoCreateCardIdentifierRequestBuilderWithSecurityCode WithSecurityCode(this IOpayoCreateCardIdentifierRequestBuilderWithExpiryDate builder, string securityCode)
        {
            builder.Object.CardDetails.SecurityCode = securityCode;
            return (IOpayoCreateCardIdentifierRequestBuilderWithSecurityCode)builder;
        }
    }
}
