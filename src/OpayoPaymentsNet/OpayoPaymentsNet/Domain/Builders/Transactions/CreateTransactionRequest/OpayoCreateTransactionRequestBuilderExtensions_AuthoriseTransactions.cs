namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static partial class OpayoCreateTransactionRequestBuilderExtensions
    {
        public static IBuildableBuilderWithTransactionType<IAuthoriseTransaction> WithOptionalCv2(this IBuildableBuilderWithTransactionType<IAuthoriseTransaction> builder, string cv2)
        {
            builder.Request.Cv2 = cv2;
            return builder;
        }
    }
}
