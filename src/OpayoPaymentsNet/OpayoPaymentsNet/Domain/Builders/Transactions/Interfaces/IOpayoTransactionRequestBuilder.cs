using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    public interface IOpayoTransactionRequestBuilder
    {
        internal OpayoCreateTransactionRequest Transaction { get; }
        Result<OpayoCreateTransactionRequest> Build();
    }
}
