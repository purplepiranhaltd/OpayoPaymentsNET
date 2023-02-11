namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static partial class OpayoTransactionRequestBuilderExtensions
    {
        public static IBuildableBuilderWithOpayoTransactionType<IAuthoriseTransaction> WithOptionalCv2(this IBuildableBuilderWithOpayoTransactionType<IAuthoriseTransaction> builder, string cv2)
        {
            builder.Request.Cv2 = cv2;
            return builder;
        }
    }
}
