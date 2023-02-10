using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;
using OpayoPaymentsNet.Domain.Entities.Enums;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static class PaymentDeferredAuthenticateAuthoriseTransactionBuilderExtensions
    {
        public static IBuildableTransactionBuilder<T> WithOptionalApplyAvsCvcCheckOverride<T>(this IBuildableTransactionBuilder<T> builder, ApplyCheck applyAvsCvcCheck)
            where T : IPaymentDeferredAuthenticateAuthoriseTransaction
        {
            builder.Transaction.ApplyAvsCvcCheck = applyAvsCvcCheck;
            return builder;
        }
    }
}
