using OpayoPaymentsNet.Domain.Entities.Transactions;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    public interface IOpayoTransactionRequestBuilder
    {
        internal OpayoTransactionRequest Transaction { get; }
        OpayoTransactionRequest Build();
    }
}
