////using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
////using OpayoPaymentsNet.Domain.Shared;

using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    public interface IBuildableBuilderWithTransactionType<T> : 
        IBuildableBuilder<OpayoCreateTransactionRequest>
        where T : ITransactionType
    {
    }
}
