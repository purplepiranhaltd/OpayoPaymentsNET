using OpayoPaymentsNet.Domain.Entities.Enums;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static partial class OpayoTransactionRequestBuilderExtensions
    {
        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalApplyAvsCvcCheckOverride<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, ApplyCheck applyAvsCvcCheck)
            where T : IPaymentDeferredAuthenticateAuthoriseTransaction
        {
            builder.Request.ApplyAvsCvcCheck = applyAvsCvcCheck;
            return builder;
        }
    }
}
