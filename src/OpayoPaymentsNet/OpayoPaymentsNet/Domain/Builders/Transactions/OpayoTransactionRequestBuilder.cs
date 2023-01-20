using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;
using OpayoPaymentsNet.Domain.Entities.Transactions;

namespace OpayoPaymentsNet.Domain.Builders.Transactions
{
    public class OpayoTransactionRequestBuilder :
        ITransactionTypeBuilder,
        IOpayoTransactionRequestBuilder
    {
        private OpayoTransactionRequest _transaction;

        private OpayoTransactionRequestBuilder()
        {
            _transaction = new OpayoTransactionRequest();
        }

        public static ITransactionTypeBuilder Create()
        {
            return new OpayoTransactionRequestBuilder();
        }

        OpayoTransactionRequest IOpayoTransactionRequestBuilder.Transaction => _transaction;

        public OpayoTransactionRequest Build()
        {

            return _transaction;
        }
    }
}
