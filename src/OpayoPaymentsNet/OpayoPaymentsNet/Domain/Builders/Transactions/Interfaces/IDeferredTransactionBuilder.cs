namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    public interface IDeferredTransactionBuilder :
        IPaymentDeferredAuthenticateTransactionBuilder,
        IPaymentDeferredAuthenticateAuthoriseTransactionBuilder,
        IPaymentDeferredAuthenticateRepeatTransactionBuilder,
        IAnyTransactionBuilder,
        IOpayoTransactionRequestBuilder
    {
    }
}
