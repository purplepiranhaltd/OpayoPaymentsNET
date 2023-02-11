////using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
////using OpayoPaymentsNet.Domain.Shared;

using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;

namespace OpayoPaymentsNet.Domain.Builders.Transactions
{
    public interface IBuildableBuilderWithTransactionType<T> :
        IBuildableBuilder<OpayoCreateTransactionRequest>
        where T : ITransactionType
    {
    }
}
