
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Errors
{
    public static class PaymentMethod
    {
        public static readonly Error MustSpecifyEitherCardOrApplePayNotBoth = new Error(
            $"{nameof(PaymentMethod)}.{nameof(MustSpecifyEitherCardOrApplePayNotBoth)}",
            "Either a card or applepay object must be specified, not both."
            );

        public static readonly Error MustSpecifyCardOrApplePay = new Error(
            $"{nameof(PaymentMethod)}.{nameof(MustSpecifyCardOrApplePay)}",
            "A card or applepay object must be specified"
            );

        public static class Card
        {
            public static readonly Error MerchantSessionKeyRequired = new Error(
                $"{nameof(PaymentMethod)}.{nameof(Card)}.{nameof(MerchantSessionKeyRequired)}",
                "The merchant session key is required."
                );

            public static readonly Error CardIdentifierRequired = new Error(
               $"{nameof(PaymentMethod)}.{nameof(Card)}.{nameof(CardIdentifierRequired)}",
               "The card identifier is required."
               );
        }

        public static class ApplePay
        {
            //TODO: Implement Apple Pay Errors
        }
    }
}
