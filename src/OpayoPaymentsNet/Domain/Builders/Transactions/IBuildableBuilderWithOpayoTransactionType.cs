using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;

namespace OpayoPaymentsNet.Domain.Builders.Transactions
{
    public interface IBuildableBuilderWithOpayoTransactionType<T> :
        IBuildableBuilder<OpayoCreateTransactionRequest>
        where T : IOpayoTransactionType
    {
    }
}
