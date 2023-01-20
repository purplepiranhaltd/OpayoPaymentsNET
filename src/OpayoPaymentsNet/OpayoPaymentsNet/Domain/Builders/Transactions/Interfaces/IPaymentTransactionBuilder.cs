namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    public interface IPaymentTransactionBuilder :
        IPaymentDeferredAuthenticateTransactionBuilder,
        IPaymentDeferredAuthenticateAuthoriseTransactionBuilder,
        IPaymentDeferredAuthenticateRepeatTransactionBuilder,
        IAnyTransactionBuilder,
        IOpayoTransactionRequestBuilder
    {
    }
}
