using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;
using OpayoPaymentsNet.Domain.Entities.Enums;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static class PaymentDeferredAuthenticateAuthoriseTransactionBuilderExtensions
    {
        public static T ApplyAvsCvcCheck<T>(this T builder, ApplyCheck applyAvsCvcCheck)
            where T : IPaymentDeferredAuthenticateAuthoriseTransactionBuilder
        {
            builder.Transaction.ApplyAvsCvcCheck = applyAvsCvcCheck;
            return builder;
        }
    }
}
