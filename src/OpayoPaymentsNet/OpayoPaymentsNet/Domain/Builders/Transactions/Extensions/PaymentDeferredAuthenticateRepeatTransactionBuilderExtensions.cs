using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;
using OpayoPaymentsNet.Domain.Entities.Shared;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static class PaymentDeferredAuthenticateRepeatTransactionBuilderExtensions
    {
        public static T WithCurrency<T>(this T builder, string currency)
            where T : IPaymentDeferredAuthenticateRepeatTransactionBuilder
        {
            builder.Transaction.Currency = currency;
            return builder;
        }

        public static T WithGiftAid<T>(this T builder, bool giftAid = true)
            where T : IPaymentDeferredAuthenticateRepeatTransactionBuilder
        {
            builder.Transaction.GiftAid = giftAid;
            return builder;
        }

        public static T WithShippingDetails<T>(this T builder, OpayoShippingDetails shippingDetails)
            where T : IPaymentDeferredAuthenticateRepeatTransactionBuilder
        {
            builder.Transaction.ShippingDetails = shippingDetails;
            return builder;
        }
        public static T WithCredentialType<T>(this T builder, OpayoCredentialType credentialType)
            where T : IPaymentDeferredAuthenticateRepeatTransactionBuilder
        {
            builder.Transaction.CredentialType = credentialType;
            return builder;
        }

    }
}
