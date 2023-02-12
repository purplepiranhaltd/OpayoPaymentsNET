using OpayoPaymentsNet.Domain.Entities.Shared;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static partial class OpayoTransactionRequestBuilderExtensions
    {
        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalGiftAid<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, bool giftAid = true)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Request.GiftAid = giftAid;
            return builder;
        }

        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalShippingDetails<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, OpayoShippingDetails shippingDetails)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Request.ShippingDetails = shippingDetails;
            return builder;
        }
        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalCredentialType<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, OpayoCredentialType credentialType)
            where T : IPaymentDeferredAuthenticateRepeatTransaction
        {
            builder.Request.CredentialType = credentialType;
            return builder;
        }

    }
}
