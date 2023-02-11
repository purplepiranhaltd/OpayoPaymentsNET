/* Unmerged change from project 'OpayoPaymentsNet (net6.0)'
Before:
namespace OpayoPaymentsNet.Domain.Builders.Transactions.CreateTransactionRequest
After:
using OpayoPaymentsNet;
using OpayoPaymentsNet.Domain;
using OpayoPaymentsNet.Domain.Builders;
using OpayoPaymentsNet.Domain.Builders.Transactions;
using OpayoPaymentsNet.Domain.Builders.Transactions;
using OpayoPaymentsNet.Domain.Builders.Transactions.CreateTransactionRequest
*/

namespace OpayoPaymentsNet.Domain.Builders.Transactions
{
    public interface ITransactionType { }
    public interface IPaymentTransaction : IPaymentDeferredAuthenticateAuthoriseTransaction, IPaymentDeferredAuthenticateTransaction, IPaymentDeferredAuthenticateRepeatTransaction, ITransactionType { }
    public interface IDeferredTransaction : IPaymentDeferredAuthenticateAuthoriseTransaction, IPaymentDeferredAuthenticateTransaction, IPaymentDeferredAuthenticateRepeatTransaction, ITransactionType { }
    public interface IAuthenticateTransaction : IPaymentDeferredAuthenticateAuthoriseTransaction, IPaymentDeferredAuthenticateTransaction, IPaymentDeferredAuthenticateRepeatTransaction, ITransactionType { }
    public interface IRepeatTransaction : IRepeatAuthoriseRefundTransaction, IPaymentDeferredAuthenticateRepeatTransaction, ITransactionType { }
    public interface IAuthoriseTransaction : IPaymentDeferredAuthenticateAuthoriseTransaction, IAuthoriseRefundTransaction, IRepeatAuthoriseRefundTransaction, ITransactionType { }
    public interface IRefundTransaction : IAuthoriseRefundTransaction, IRepeatAuthoriseRefundTransaction, ITransactionType { }
    public interface IAuthoriseRefundTransaction : IRepeatAuthoriseRefundTransaction, ITransactionType { }
    public interface IRepeatAuthoriseRefundTransaction : ITransactionType { }
    public interface IPaymentDeferredAuthenticateTransaction : ITransactionType { }
    public interface IPaymentDeferredAuthenticateRepeatTransaction : ITransactionType { }
    public interface IPaymentDeferredAuthenticateAuthoriseTransaction : ITransactionType { }
}
