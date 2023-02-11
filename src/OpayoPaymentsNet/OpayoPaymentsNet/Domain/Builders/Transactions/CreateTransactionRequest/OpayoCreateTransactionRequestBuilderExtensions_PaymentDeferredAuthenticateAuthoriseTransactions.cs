using OpayoPaymentsNet.Domain.Entities.Enums;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static partial class OpayoCreateTransactionRequestBuilderExtensions
    {
        public static IBuildableBuilderWithTransactionType<T> WithOptionalApplyAvsCvcCheckOverride<T>(this IBuildableBuilderWithTransactionType<T> builder, ApplyCheck applyAvsCvcCheck)
            where T : IPaymentDeferredAuthenticateAuthoriseTransaction
        {
            builder.Object.ApplyAvsCvcCheck = applyAvsCvcCheck;
            return builder;
        }
    }
}
