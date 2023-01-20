namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    public interface IRefundTransactionBuilder :
        IRepeatAuthoriseRefundTransactionBuilder,
        IAnyTransactionBuilder,
        IOpayoTransactionRequestBuilder
    {
    }
}
