using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;
using OpayoPaymentsNet.Domain.Entities.Enums;
using OpayoPaymentsNet.Domain.Entities.Shared;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static class PaymentDeferredAuthenticateTransactionBuilderExtensions
    {
        public static T WithPaymentMethod<T>(this T builder, OpayoPaymentMethod paymentMethod)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.PaymentMethod = paymentMethod;
            return builder;
        }

        public static T WithCustomerFirstName<T>(this T builder, string customerFirstName)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.CustomerFirstName = customerFirstName;
            return builder;
        }

        public static T WithCustomerLastName<T>(this T builder, string customerLastName)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.CustomerLastName = customerLastName;
            return builder;
        }

        public static T WithBillingAddress<T>(this T builder, OpayoBillingAddress billingAddress)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.BillingAddress = billingAddress;
            return builder;
        }

        public static T WithSettlementReferenceText<T>(this T builder, string settlementReferenceText)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.SettlementReferenceText = settlementReferenceText;
            return builder;
        }

        public static T WithCustomerEmail<T>(this T builder, string customerEmail)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.CustomerEmail = customerEmail;
            return builder;
        }

        public static T WithCustomerPhone<T>(this T builder, string customerPhone)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.CustomerPhone = customerPhone;
            return builder;
        }

        public static T WithCustomerMobilePhone<T>(this T builder, string customerMobilePhone)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.CustomerMobilePhone = customerMobilePhone;
            return builder;
        }

        public static T WithCustomerWorkPhone<T>(this T builder, string customerWorkPhone)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.CustomerWorkPhone = customerWorkPhone;
            return builder;
        }

        public static T WithEntryMethod<T>(this T builder, EntryMethod entryMethod)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.EntryMethod = entryMethod;
            return builder;
        }

        public static T Apply3DSecure<T>(this T builder, ApplyCheck apply3DSecure)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.Apply3DSecure = apply3DSecure;
            return builder;
        }

        public static T WithReferrerId<T>(this T builder, string referrerId)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.ReferrerId = referrerId;
            return builder;
        }

        public static T WithStrongCustomerAuthentication<T>(this T builder, OpayoStrongCustomerAuthentication strongCustomerAuthentication)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.StrongCustomerAuthentication = strongCustomerAuthentication;
            return builder;
        }

        public static T WithFinancialInstitutionRecipient<T>(this T builder, OpayoFinancialInstitutionRecipient fiRecipient)
            where T : IPaymentDeferredAuthenticateTransactionBuilder
        {
            builder.Transaction.FiRecipient = fiRecipient;
            return builder;
        }
    }
}
