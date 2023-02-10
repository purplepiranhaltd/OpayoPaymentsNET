using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static class AuthoriseTransactionBuilderExtensions
    {
        public static IBuildableTransactionBuilder<IAuthoriseTransaction> WithOptionalCv2(this IBuildableTransactionBuilder<IAuthoriseTransaction> builder, string cv2)
        {
            builder.Transaction.Cv2 = cv2;
            return builder;
        }
    }
}
