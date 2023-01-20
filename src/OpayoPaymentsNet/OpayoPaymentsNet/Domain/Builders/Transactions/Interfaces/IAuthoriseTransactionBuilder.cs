namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    public interface IAuthoriseTransactionBuilder :
        IPaymentDeferredAuthenticateAuthoriseTransactionBuilder,
        IRepeatAuthoriseRefundTransactionBuilder,
        IAnyTransactionBuilder,
        IOpayoTransactionRequestBuilder
    {
    }
}
