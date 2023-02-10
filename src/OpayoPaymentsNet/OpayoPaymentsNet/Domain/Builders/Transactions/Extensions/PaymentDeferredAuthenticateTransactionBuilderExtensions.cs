using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;
using OpayoPaymentsNet.Domain.Entities.Enums;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static class PaymentDeferredAuthenticateTransactionBuilderExtensions
    {
        public static IBuildableTransactionBuilder<T> WithOptionalSettlementReferenceText<T>(this IBuildableTransactionBuilder<T> builder, string settlementReferenceText)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.SettlementReferenceText = settlementReferenceText;
            return builder;
        }

        public static IBuildableTransactionBuilder<T> WithOptionalCustomerEmail<T>(this IBuildableTransactionBuilder<T> builder, string customerEmail)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.CustomerEmail = customerEmail;
            return builder;
        }

        public static IBuildableTransactionBuilder<T> WithOptionalCustomerPhone<T>(this IBuildableTransactionBuilder<T> builder, string customerPhone)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.CustomerPhone = customerPhone;
            return builder;
        }

        public static IBuildableTransactionBuilder<T> WithOptionalCustomerMobilePhone<T>(this IBuildableTransactionBuilder<T> builder, string customerMobilePhone)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.CustomerMobilePhone = customerMobilePhone;
            return builder;
        }

        public static IBuildableTransactionBuilder<T> WithOptionalCustomerWorkPhone<T>(this IBuildableTransactionBuilder<T> builder, string customerWorkPhone)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.CustomerWorkPhone = customerWorkPhone;
            return builder;
        }

        public static IBuildableTransactionBuilder<T> WithOptionalEntryMethod<T>(this IBuildableTransactionBuilder<T> builder, EntryMethod entryMethod)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.EntryMethod = entryMethod;
            return builder;
        }

        public static IBuildableTransactionBuilder<T> WithOptionalApply3DSecureOverride<T>(this IBuildableTransactionBuilder<T> builder, ApplyCheck apply3DSecure)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.Apply3DSecure = apply3DSecure;
            return builder;
        }

        public static IBuildableTransactionBuilder<T> WithOptionalReferrerId<T>(this IBuildableTransactionBuilder<T> builder, string referrerId)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.ReferrerId = referrerId;
            return builder;
        }

        public static IBuildableTransactionBuilder<T> WithOptionalStrongCustomerAuthentication<T>(this IBuildableTransactionBuilder<T> builder, OpayoStrongCustomerAuthentication strongCustomerAuthentication)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.StrongCustomerAuthentication = strongCustomerAuthentication;
            return builder;
        }

        public static IBuildableTransactionBuilder<T> WithOptionalFinancialInstitutionRecipient<T>(this IBuildableTransactionBuilder<T> builder, OpayoFinancialInstitutionRecipient fiRecipient)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.FiRecipient = fiRecipient;
            return builder;
        }
    }
}
