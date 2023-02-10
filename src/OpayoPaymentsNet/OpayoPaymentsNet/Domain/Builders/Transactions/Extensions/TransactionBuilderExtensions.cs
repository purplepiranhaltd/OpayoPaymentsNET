using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;
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
    public static class TransactionBuilderExtensions
    {
        public static ITransactionWithVendorTxCodeBuilder WithRequiredVendorTxCode(this ITransactionBuilder builder, string vendorTxCode)
        {
            builder.Transaction.VendorTxCode = vendorTxCode;
            return (ITransactionWithVendorTxCodeBuilder)builder;
        }

        public static ITransactionWithDescriptionBuilder WithRequiredDescription(this ITransactionWithVendorTxCodeBuilder builder, string description)
        {
            builder.Transaction.Description = description;
            return (ITransactionWithDescriptionBuilder)builder;
        }

        public static ITransactionWithAmountBuilder WithRequiredAmount(this ITransactionWithDescriptionBuilder builder, int amount)
        {
            builder.Transaction.Amount = amount;
            return (ITransactionWithAmountBuilder)builder;
        }

        public static ITransactionWithTransactionTypeBuilder<IPaymentTransaction> AsPaymentTransaction(this ITransactionWithAmountBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Payment;
            return (ITransactionWithTransactionTypeBuilder<IPaymentTransaction>)transactionTypeBuilder;
        }

        public static ITransactionWithTransactionTypeBuilder<IDeferredTransaction> AsDeferredTransaction(this ITransactionWithAmountBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Deferred;
            return (ITransactionWithTransactionTypeBuilder<IDeferredTransaction>)transactionTypeBuilder;
        }

        public static ITransactionWithTransactionTypeBuilder<IAuthenticateTransaction> AsAuthenticateTransaction(this ITransactionWithAmountBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Authenticate;
            return (ITransactionWithTransactionTypeBuilder<IAuthenticateTransaction>)transactionTypeBuilder;
        }

        public static ITransactionWithTransactionTypeBuilder<IRepeatTransaction> AsRepeatTransaction(this ITransactionWithAmountBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Repeat;
            return (ITransactionWithTransactionTypeBuilder<IRepeatTransaction>)transactionTypeBuilder;
        }

        public static ITransactionWithTransactionTypeBuilder<IRefundTransaction> AsRefundTransaction(this ITransactionWithAmountBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Refund;
            return (ITransactionWithTransactionTypeBuilder<IRefundTransaction>)transactionTypeBuilder;
        }

        public static ITransactionWithTransactionTypeBuilder<IAuthoriseTransaction> AsAuthoriseTransaction(this ITransactionWithAmountBuilder transactionTypeBuilder)
        {
            transactionTypeBuilder.Transaction.TransactionType = TransactionType.Authorise;
            return (ITransactionWithTransactionTypeBuilder<IAuthoriseTransaction>)transactionTypeBuilder;
        }

        public static IAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<T> WithRequiredReferenceTransactionId<T>(this ITransactionWithTransactionTypeBuilder<T> builder, string referenceTransactionId)
            where T : IAuthoriseRefundTransaction
        {
            builder.Transaction.ReferenceTransactionId = referenceTransactionId;
            return (IAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<T>)builder;
        }

        public static IRepeatTransactionTransactionWithReferenceTransactionIdBuilder WithRequiredReferenceTransactionId(this ITransactionWithTransactionTypeBuilder<IRepeatTransaction> builder, string referenceTransactionId)
        {
            builder.Transaction.ReferenceTransactionId = referenceTransactionId;
            return (IRepeatTransactionTransactionWithReferenceTransactionIdBuilder)builder;
        }

        public static IRepeatTransactionWithCurrencyBuilder WithRequiredCurrency(this IRepeatTransactionTransactionWithReferenceTransactionIdBuilder builder, string currency)
        {
            builder.Transaction.Currency = currency;
            return (IRepeatTransactionWithCurrencyBuilder)builder;
        }

        public static IPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T> WithRequiredCurrency<T>(this ITransactionWithTransactionTypeBuilder<T> builder, string currency)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.Currency = currency;
            return (IPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T>)builder;
        }

        public static IPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T> WithRequiredPaymentMethod<T>(this IPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T> builder, OpayoPaymentMethod paymentMethod)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.PaymentMethod = paymentMethod;
            return (IPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T>)builder;
        }

        public static IPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T> WithRequiredCustomerFirstName<T>(this IPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T> builder, string customerFirstName)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.CustomerFirstName = customerFirstName;
            return (IPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T>)builder;
        }

        public static IPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T> WithRequiredCustomerLastName<T>(this IPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T> builder, string customerLastName)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.CustomerLastName = customerLastName;
            return (IPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T>)builder;
        }

        public static IPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<T> WithRequiredBillingAddress<T>(this IPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T> builder, OpayoBillingAddress billingAddress)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Transaction.BillingAddress = billingAddress;
            return (IPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<T>)builder;
        }
    }
}