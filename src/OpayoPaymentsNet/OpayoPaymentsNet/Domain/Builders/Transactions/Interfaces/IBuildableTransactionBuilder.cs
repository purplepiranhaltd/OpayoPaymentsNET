using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    public interface IBuildableTransactionBuilder : IOpayoCreateTransactionRequestBuilder
    {
        Result<OpayoCreateTransactionRequest> Build();
    }

    public interface IBuildableTransactionBuilder<T> : IBuildableTransactionBuilder
    {
    }
}
