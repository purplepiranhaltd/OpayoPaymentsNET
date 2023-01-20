using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static class AuthoriseTransactionBuilderExtensions
    {
        public static IAuthoriseTransactionBuilder WithCv2(this IAuthoriseTransactionBuilder builder, string cv2)
        {
            builder.Transaction.Cv2 = cv2;
            return builder;
        }
    }
}
