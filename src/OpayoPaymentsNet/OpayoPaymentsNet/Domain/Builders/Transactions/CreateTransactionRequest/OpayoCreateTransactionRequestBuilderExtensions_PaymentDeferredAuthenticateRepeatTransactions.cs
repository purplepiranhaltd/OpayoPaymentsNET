using OpayoPaymentsNet.Domain.Entities.Shared;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static partial class OpayoCreateTransactionRequestBuilderExtensions
    {
        public static IBuildableBuilderWithTransactionType<T> WithOptionalGiftAid<T>(this IBuildableBuilderWithTransactionType<T> builder, bool giftAid = true)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Request.GiftAid = giftAid;
            return builder;
        }

        public static IBuildableBuilderWithTransactionType<T> WithOptionalShippingDetails<T>(this IBuildableBuilderWithTransactionType<T> builder, OpayoShippingDetails shippingDetails)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Request.ShippingDetails = shippingDetails;
            return builder;
        }
        public static IBuildableBuilderWithTransactionType<T> WithOptionalCredentialType<T>(this IBuildableBuilderWithTransactionType<T> builder, OpayoCredentialType credentialType)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Request.CredentialType = credentialType;
            return builder;
        }

    }
}
