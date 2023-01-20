namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    public interface IAuthenticateTransactionBuilder :
        IPaymentDeferredAuthenticateTransactionBuilder,
        IPaymentDeferredAuthenticateAuthoriseTransactionBuilder,
        IPaymentDeferredAuthenticateRepeatTransactionBuilder,
        IAnyTransactionBuilder,
        IOpayoTransactionRequestBuilder
    {
    }
}
