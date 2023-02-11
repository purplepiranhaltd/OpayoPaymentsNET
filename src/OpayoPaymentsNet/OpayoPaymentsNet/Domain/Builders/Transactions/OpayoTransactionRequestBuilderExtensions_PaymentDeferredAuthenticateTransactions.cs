using OpayoPaymentsNet.Domain.Entities.Enums;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static partial class OpayoTransactionRequestBuilderExtensions
    {
        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalSettlementReferenceText<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, string settlementReferenceText)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.SettlementReferenceText = settlementReferenceText;
            return builder;
        }

        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalCustomerEmail<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, string customerEmail)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerEmail = customerEmail;
            return builder;
        }

        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalCustomerPhone<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, string customerPhone)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerPhone = customerPhone;
            return builder;
        }

        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalCustomerMobilePhone<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, string customerMobilePhone)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerMobilePhone = customerMobilePhone;
            return builder;
        }

        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalCustomerWorkPhone<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, string customerWorkPhone)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerWorkPhone = customerWorkPhone;
            return builder;
        }

        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalEntryMethod<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, EntryMethod entryMethod)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.EntryMethod = entryMethod;
            return builder;
        }

        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalApply3DSecureOverride<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, ApplyCheck apply3DSecure)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.Apply3DSecure = apply3DSecure;
            return builder;
        }

        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalReferrerId<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, string referrerId)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.ReferrerId = referrerId;
            return builder;
        }

        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalStrongCustomerAuthentication<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, OpayoStrongCustomerAuthentication strongCustomerAuthentication)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.StrongCustomerAuthentication = strongCustomerAuthentication;
            return builder;
        }

        public static IBuildableBuilderWithOpayoTransactionType<T> WithOptionalFinancialInstitutionRecipient<T>(this IBuildableBuilderWithOpayoTransactionType<T> builder, OpayoFinancialInstitutionRecipient fiRecipient)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.FiRecipient = fiRecipient;
            return builder;
        }
    }
}
