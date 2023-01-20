using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;
using OpayoPaymentsNet.Domain.Entities.Enums;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static class TransactionTypeBuilderExtensions
    {
        public static IPaymentTransactionBuilder AsPaymentTransaction(this ITransactionTypeBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Payment;
            return (IPaymentTransactionBuilder)transactionTypeBuilder;
        }

        public static IDeferredTransactionBuilder AsDeferredTransaction(this ITransactionTypeBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Deferred;
            return (IDeferredTransactionBuilder)transactionTypeBuilder;
        }

        public static IAuthenticateTransactionBuilder AsAuthenticateTransaction(this ITransactionTypeBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Authenticate;
            return (IAuthenticateTransactionBuilder)transactionTypeBuilder;
        }

        public static IRepeatTransactionBuilder AsRepeatTransaction(this ITransactionTypeBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Repeat;
            return (IRepeatTransactionBuilder)transactionTypeBuilder;
        }

        public static IRefundTransactionBuilder AsRefundTransaction(this ITransactionTypeBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Refund;
            return (IRefundTransactionBuilder)transactionTypeBuilder;
        }

        public static IAuthoriseTransactionBuilder AsAuthoriseTransaction(this ITransactionTypeBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Authorise;
            return (IAuthoriseTransactionBuilder)transactionTypeBuilder;
        }
    }
}
