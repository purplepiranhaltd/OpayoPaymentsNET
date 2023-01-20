using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static class AnyTransactionBuilderExtensions
    {
        public static T WithVendorTxCode<T>(this T builder, string vendorTxCode)
            where T : IAnyTransactionBuilder
        {
            builder.Transaction.VendorTxCode = vendorTxCode;
            return builder;
        }

        public static T WithDescription<T>(this T builder, string description)
            where T : IAnyTransactionBuilder
        {
            builder.Transaction.Description = description;
            return builder;
        }

        public static T WithAmount<T>(this T builder, int amount)
            where T : IAnyTransactionBuilder
        {
            builder.Transaction.Amount = amount;
            return builder;
        }
    }
}
