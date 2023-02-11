using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;
using OpayoPaymentsNet.Domain.Entities.Shared;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static partial class OpayoCreateTransactionRequestBuilderExtensions
    {
        public static IBuildableBuilderWithTransactionType<T> WithOptionalGiftAid<T>(this IBuildableBuilderWithTransactionType<T> builder, bool giftAid = true)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Object.GiftAid = giftAid;
            return builder;
        }

        public static IBuildableBuilderWithTransactionType<T> WithOptionalShippingDetails<T>(this IBuildableBuilderWithTransactionType<T> builder, OpayoShippingDetails shippingDetails)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Object.ShippingDetails = shippingDetails;
            return builder;
        }
        public static IBuildableBuilderWithTransactionType<T> WithOptionalCredentialType<T>(this IBuildableBuilderWithTransactionType<T> builder, OpayoCredentialType credentialType)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Object.CredentialType = credentialType;
            return builder;
        }

    }
}
