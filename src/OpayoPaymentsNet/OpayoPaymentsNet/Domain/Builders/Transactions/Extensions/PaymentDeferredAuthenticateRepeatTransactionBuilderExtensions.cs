using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;
using OpayoPaymentsNet.Domain.Entities.Shared;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static class PaymentDeferredAuthenticateRepeatTransactionBuilderExtensions
    {
        public static IBuildableTransactionBuilder<T> WithOptionalGiftAid<T>(this IBuildableTransactionBuilder<T> builder, bool giftAid = true)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Transaction.GiftAid = giftAid;
            return builder;
        }

        public static IBuildableTransactionBuilder<T> WithOptionalShippingDetails<T>(this IBuildableTransactionBuilder<T> builder, OpayoShippingDetails shippingDetails)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Transaction.ShippingDetails = shippingDetails;
            return builder;
        }
        public static IBuildableTransactionBuilder<T> WithOptionalCredentialType<T>(this IBuildableTransactionBuilder<T> builder, OpayoCredentialType credentialType)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Transaction.CredentialType = credentialType;
            return builder;
        }

    }
}
