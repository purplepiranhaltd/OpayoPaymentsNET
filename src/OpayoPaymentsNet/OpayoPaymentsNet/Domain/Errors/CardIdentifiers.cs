
/* Unmerged change from project 'OpayoPaymentsNet.Domain (net7.0)'
Before:
using System;
After:
using OpayoPaymentsNet.Domain.Shared;
using System;
*/
using
/* Unmerged change from project 'OpayoPaymentsNet.Domain (net7.0)'
Before:
using System.Threading.Tasks;
using OpayoPaymentsNet.Domain.Shared;
After:
using System.Threading.Tasks;
*/
OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Errors
{
    public static class CardDetails
    {
        public static readonly Error CardholderNameRequired = new Error(
            $"{nameof(CardDetails)}.{nameof(CardholderNameRequired)}",
            "The cardholder's name is required."
            );

        public static readonly Error CardNumberRequired = new Error(
            $"{nameof(CardDetails)}.{nameof(CardNumberRequired)}",
            "The card number is required."
            );

        public static readonly Error ExpiryDateRequired = new Error(
            $"{nameof(CardDetails)}.{nameof(ExpiryDateRequired)}",
            "The expiry date is required."
            );

        public static readonly Error SecurityCodeRequired = new Error(
            $"{nameof(CardDetails)}.{nameof(SecurityCodeRequired)}",
            "The security code is required."
            );

        public static readonly Error CardholderNameInvalid = new Error(
            $"{nameof(CardDetails)}.{nameof(CardholderNameInvalid)}",
            "The cardholder's name is invalid. Must be <= 45 characters."
            );

        public static readonly Error CardNumberInvalid = new Error(
            $"{nameof(CardDetails)}.{nameof(CardNumberInvalid)}",
            "The card number is invalid. Must be <= 16 characters."
            );

        public static readonly Error ExpiryDateInvalid = new Error(
            $"{nameof(CardDetails)}.{nameof(ExpiryDateInvalid)}",
            "The expiry date is invalid. Must be 4 characters. MMYY format."
            );

        public static readonly Error SecurityCodeInvalid = new Error(
            $"{nameof(CardDetails)}.{nameof(SecurityCodeInvalid)}",
            "The security code is invalid. Must be 3 or 4 charcters."
            );
    }
}
