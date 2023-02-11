using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Builders.CardIdentifiers
{
    public static class OpayoCardIdentifierRequestBuilderExtensions
    {
        public static IOpayoCardIdentifierRequestBuilderWithCardholderName WithCardholderName(this IOpayoCardIdentifierRequestBuilder builder, string cardholderName)
        {
            builder.CardIdentifierRequest.CardDetails.CardholderName = cardholderName;
            return (IOpayoCardIdentifierRequestBuilderWithCardholderName)builder;
        }

        public static IOpayoCardIdentifierRequestBuilderWithCardNumber WithCardNumber(this IOpayoCardIdentifierRequestBuilderWithCardholderName builder, string cardnumber)
        {
            builder.CardIdentifierRequest.CardDetails.CardNumber = cardnumber;
            return (IOpayoCardIdentifierRequestBuilderWithCardNumber)builder;
        }

        public static IOpayoCardIdentifierRequestBuilderWithExpiryDate WithExpiryDate(this IOpayoCardIdentifierRequestBuilderWithCardNumber builder, string expiryDate)
        {
            builder.CardIdentifierRequest.CardDetails.ExpiryDate = expiryDate;
            return (IOpayoCardIdentifierRequestBuilderWithExpiryDate)builder;
        }

        public static IOpayoCardIdentifierRequestBuilderWithSecurityCode WithSecurityCode(this IOpayoCardIdentifierRequestBuilderWithExpiryDate builder, string securityCode)
        {
            builder.CardIdentifierRequest.CardDetails.SecurityCode = securityCode;
            return (IOpayoCardIdentifierRequestBuilderWithSecurityCode)builder;
        }
    }
}
