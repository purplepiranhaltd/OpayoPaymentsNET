namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    public interface IRepeatTransactionBuilder :
        IPaymentDeferredAuthenticateRepeatTransactionBuilder,
        IRepeatAuthoriseRefundTransactionBuilder,
        IAnyTransactionBuilder,
        IOpayoTransactionRequestBuilder
    {
    }
}
