using OpayoPaymentsNet.Domain.Entities.Enums;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Extensions
{
    public static partial class OpayoCreateTransactionRequestBuilderExtensions
    {
        public static IOpayoTransactionRequestWithVendorTxCodeBuilder WithRequiredVendorTxCode(this INewBuilder<OpayoCreateTransactionRequest> builder, string vendorTxCode)
        {
            builder.Request.VendorTxCode = vendorTxCode;
            return (IOpayoTransactionRequestWithVendorTxCodeBuilder)builder;
        }

        public static IOpayoTransactionRequestWithDescriptionBuilder WithRequiredDescription(this IOpayoTransactionRequestWithVendorTxCodeBuilder builder, string description)
        {
            builder.Request.Description = description;
            return (IOpayoTransactionRequestWithDescriptionBuilder)builder;
        }

        public static IOpayoTransactionRequestWithAmountBuilder WithRequiredAmount(this IOpayoTransactionRequestWithDescriptionBuilder builder, int amount)
        {
            builder.Request.Amount = amount;
            return (IOpayoTransactionRequestWithAmountBuilder)builder;
        }

        public static IOpayoTransactionRequestWithTransactionTypeBuilder<IPaymentTransaction> AsPaymentTransaction(this IOpayoTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Payment;
            return (IOpayoTransactionRequestWithTransactionTypeBuilder<IPaymentTransaction>)builder;
        }

        public static IOpayoTransactionRequestWithTransactionTypeBuilder<IDeferredTransaction> AsDeferredTransaction(this IOpayoTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Deferred;
            return (IOpayoTransactionRequestWithTransactionTypeBuilder<IDeferredTransaction>)builder;
        }

        public static IOpayoTransactionRequestWithTransactionTypeBuilder<IAuthenticateTransaction> AsAuthenticateTransaction(this IOpayoTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Authenticate;
            return (IOpayoTransactionRequestWithTransactionTypeBuilder<IAuthenticateTransaction>)builder;
        }

        public static IOpayoTransactionRequestWithTransactionTypeBuilder<IRepeatTransaction> AsRepeatTransaction(this IOpayoTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Repeat;
            return (IOpayoTransactionRequestWithTransactionTypeBuilder<IRepeatTransaction>)builder;
        }

        public static IOpayoTransactionRequestWithTransactionTypeBuilder<IRefundTransaction> AsRefundTransaction(this IOpayoTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Refund;
            return (IOpayoTransactionRequestWithTransactionTypeBuilder<IRefundTransaction>)builder;
        }

        public static IOpayoTransactionRequestWithTransactionTypeBuilder<IAuthoriseTransaction> AsAuthoriseTransaction(this IOpayoTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Authorise;
            return (IOpayoTransactionRequestWithTransactionTypeBuilder<IAuthoriseTransaction>)builder;
        }

        public static IOpayoTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<T> WithRequiredReferenceTransactionId<T>(this IOpayoTransactionRequestWithTransactionTypeBuilder<T> builder, string referenceTransactionId)
            where T : IAuthoriseRefundTransaction
        {
            builder.Request.ReferenceTransactionId = referenceTransactionId;
            return (IOpayoTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<T>)builder;
        }

        public static IOpayoTransactionRequestRepeatTransactionWithReferenceTransactionIdBuilder WithRequiredReferenceTransactionId(this IOpayoTransactionRequestWithTransactionTypeBuilder<IRepeatTransaction> builder, string referenceTransactionId)
        {
            builder.Request.ReferenceTransactionId = referenceTransactionId;
            return (IOpayoTransactionRequestRepeatTransactionWithReferenceTransactionIdBuilder)builder;
        }

        public static IOpayoTransactionRequestRepeatTransactionWithCurrencyBuilder WithRequiredCurrency(this IOpayoTransactionRequestRepeatTransactionWithReferenceTransactionIdBuilder builder, string currency)
        {
            builder.Request.Currency = currency;
            return (IOpayoTransactionRequestRepeatTransactionWithCurrencyBuilder)builder;
        }

        public static IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T> WithRequiredCurrency<T>(this IOpayoTransactionRequestWithTransactionTypeBuilder<T> builder, string currency)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.Currency = currency;
            return (IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T>)builder;
        }

        public static IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T> WithRequiredPaymentMethod<T>(this IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T> builder, OpayoPaymentMethod paymentMethod)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.PaymentMethod = paymentMethod;
            return (IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T>)builder;
        }

        public static IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T> WithRequiredCustomerFirstName<T>(this IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T> builder, string customerFirstName)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerFirstName = customerFirstName;
            return (IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T>)builder;
        }

        public static IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T> WithRequiredCustomerLastName<T>(this IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T> builder, string customerLastName)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerLastName = customerLastName;
            return (IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T>)builder;
        }

        public static IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<T> WithRequiredBillingAddress<T>(this IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T> builder, OpayoBillingAddress billingAddress)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.BillingAddress = billingAddress;
            return (IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<T>)builder;
        }
    }
}