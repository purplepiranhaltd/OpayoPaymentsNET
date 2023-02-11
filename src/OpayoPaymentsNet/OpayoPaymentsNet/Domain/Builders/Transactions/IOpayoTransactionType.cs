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
    public interface IOpayoTransactionType { }
    public interface IPaymentTransaction : IPaymentDeferredAuthenticateAuthoriseTransaction, IPaymentDeferredAuthenticateTransaction, IPaymentDeferredAuthenticateRepeatTransaction, IOpayoTransactionType { }
    public interface IDeferredTransaction : IPaymentDeferredAuthenticateAuthoriseTransaction, IPaymentDeferredAuthenticateTransaction, IPaymentDeferredAuthenticateRepeatTransaction, IOpayoTransactionType { }
    public interface IAuthenticateTransaction : IPaymentDeferredAuthenticateAuthoriseTransaction, IPaymentDeferredAuthenticateTransaction, IPaymentDeferredAuthenticateRepeatTransaction, IOpayoTransactionType { }
    public interface IRepeatTransaction : IRepeatAuthoriseRefundTransaction, IPaymentDeferredAuthenticateRepeatTransaction, IOpayoTransactionType { }
    public interface IAuthoriseTransaction : IPaymentDeferredAuthenticateAuthoriseTransaction, IAuthoriseRefundTransaction, IRepeatAuthoriseRefundTransaction, IOpayoTransactionType { }
    public interface IRefundTransaction : IAuthoriseRefundTransaction, IRepeatAuthoriseRefundTransaction, IOpayoTransactionType { }
    public interface IAuthoriseRefundTransaction : IRepeatAuthoriseRefundTransaction, IOpayoTransactionType { }
    public interface IRepeatAuthoriseRefundTransaction : IOpayoTransactionType { }
    public interface IPaymentDeferredAuthenticateTransaction : IOpayoTransactionType { }
    public interface IPaymentDeferredAuthenticateRepeatTransaction : IOpayoTransactionType { }
    public interface IPaymentDeferredAuthenticateAuthoriseTransaction : IOpayoTransactionType { }
}
