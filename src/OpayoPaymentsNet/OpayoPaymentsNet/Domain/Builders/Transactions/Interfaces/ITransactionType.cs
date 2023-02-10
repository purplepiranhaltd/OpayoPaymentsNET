namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
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
