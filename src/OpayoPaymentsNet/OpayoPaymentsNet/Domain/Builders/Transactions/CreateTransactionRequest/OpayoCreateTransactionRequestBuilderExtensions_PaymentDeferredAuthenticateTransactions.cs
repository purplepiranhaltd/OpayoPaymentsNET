using OpayoPaymentsNet.Domain.Entities.Enums;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static partial class OpayoCreateTransactionRequestBuilderExtensions
    {
        public static IBuildableBuilderWithTransactionType<T> WithOptionalSettlementReferenceText<T>(this IBuildableBuilderWithTransactionType<T> builder, string settlementReferenceText)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.SettlementReferenceText = settlementReferenceText;
            return builder;
        }

        public static IBuildableBuilderWithTransactionType<T> WithOptionalCustomerEmail<T>(this IBuildableBuilderWithTransactionType<T> builder, string customerEmail)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerEmail = customerEmail;
            return builder;
        }

        public static IBuildableBuilderWithTransactionType<T> WithOptionalCustomerPhone<T>(this IBuildableBuilderWithTransactionType<T> builder, string customerPhone)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerPhone = customerPhone;
            return builder;
        }

        public static IBuildableBuilderWithTransactionType<T> WithOptionalCustomerMobilePhone<T>(this IBuildableBuilderWithTransactionType<T> builder, string customerMobilePhone)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerMobilePhone = customerMobilePhone;
            return builder;
        }

        public static IBuildableBuilderWithTransactionType<T> WithOptionalCustomerWorkPhone<T>(this IBuildableBuilderWithTransactionType<T> builder, string customerWorkPhone)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerWorkPhone = customerWorkPhone;
            return builder;
        }

        public static IBuildableBuilderWithTransactionType<T> WithOptionalEntryMethod<T>(this IBuildableBuilderWithTransactionType<T> builder, EntryMethod entryMethod)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.EntryMethod = entryMethod;
            return builder;
        }

        public static IBuildableBuilderWithTransactionType<T> WithOptionalApply3DSecureOverride<T>(this IBuildableBuilderWithTransactionType<T> builder, ApplyCheck apply3DSecure)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.Apply3DSecure = apply3DSecure;
            return builder;
        }

        public static IBuildableBuilderWithTransactionType<T> WithOptionalReferrerId<T>(this IBuildableBuilderWithTransactionType<T> builder, string referrerId)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.ReferrerId = referrerId;
            return builder;
        }

        public static IBuildableBuilderWithTransactionType<T> WithOptionalStrongCustomerAuthentication<T>(this IBuildableBuilderWithTransactionType<T> builder, OpayoStrongCustomerAuthentication strongCustomerAuthentication)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.StrongCustomerAuthentication = strongCustomerAuthentication;
            return builder;
        }

        public static IBuildableBuilderWithTransactionType<T> WithOptionalFinancialInstitutionRecipient<T>(this IBuildableBuilderWithTransactionType<T> builder, OpayoFinancialInstitutionRecipient fiRecipient)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.FiRecipient = fiRecipient;
            return builder;
        }
    }
}
