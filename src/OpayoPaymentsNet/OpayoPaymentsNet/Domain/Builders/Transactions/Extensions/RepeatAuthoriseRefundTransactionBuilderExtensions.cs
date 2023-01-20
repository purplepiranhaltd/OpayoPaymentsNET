using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static class RepeatAuthoriseRefundTransactionBuilderExtensions
    {
        public static T WithReferenceTransactionId<T>(this T builder, string referenceTransactionId)
            where T : IRepeatAuthoriseRefundTransactionBuilder
        {
            builder.Transaction.ReferenceTransactionId = referenceTransactionId;
            return builder;
        }
    }
}
