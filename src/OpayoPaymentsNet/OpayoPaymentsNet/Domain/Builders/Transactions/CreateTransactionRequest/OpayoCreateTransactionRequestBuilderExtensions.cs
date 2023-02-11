﻿using OpayoPaymentsNet.Domain.Builders.Transactions.CreateTransactionRequest;
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
        public static IOpayoCreateTransactionRequestWithVendorTxCodeBuilder WithRequiredVendorTxCode(this INewBuilder<OpayoCreateTransactionRequest> builder, string vendorTxCode)
        {
            builder.Request.VendorTxCode = vendorTxCode;
            return (IOpayoCreateTransactionRequestWithVendorTxCodeBuilder)builder;
        }

        public static IOpayoCreateTransactionRequestWithDescriptionBuilder WithRequiredDescription(this IOpayoCreateTransactionRequestWithVendorTxCodeBuilder builder, string description)
        {
            builder.Request.Description = description;
            return (IOpayoCreateTransactionRequestWithDescriptionBuilder)builder;
        }

        public static IOpayoCreateTransactionRequestWithAmountBuilder WithRequiredAmount(this IOpayoCreateTransactionRequestWithDescriptionBuilder builder, int amount)
        {
            builder.Request.Amount = amount;
            return (IOpayoCreateTransactionRequestWithAmountBuilder)builder;
        }

        public static IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IPaymentTransaction> AsPaymentTransaction(this IOpayoCreateTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Payment;
            return (IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IPaymentTransaction>)builder;
        }

        public static IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IDeferredTransaction> AsDeferredTransaction(this IOpayoCreateTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Deferred;
            return (IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IDeferredTransaction>)builder;
        }

        public static IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IAuthenticateTransaction> AsAuthenticateTransaction(this IOpayoCreateTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Authenticate;
            return (IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IAuthenticateTransaction>)builder;
        }

        public static IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IRepeatTransaction> AsRepeatTransaction(this IOpayoCreateTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Repeat;
            return (IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IRepeatTransaction>)builder;
        }

        public static IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IRefundTransaction> AsRefundTransaction(this IOpayoCreateTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Refund;
            return (IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IRefundTransaction>)builder;
        }

        public static IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IAuthoriseTransaction> AsAuthoriseTransaction(this IOpayoCreateTransactionRequestWithAmountBuilder builder)
        {
            builder.Request.TransactionType = TransactionType.Authorise;
            return (IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IAuthoriseTransaction>)builder;
        }

        public static IOpayoCreateTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<T> WithRequiredReferenceTransactionId<T>(this IOpayoCreateTransactionRequestWithTransactionTypeBuilder<T> builder, string referenceTransactionId)
            where T : IAuthoriseRefundTransaction
        {
            builder.Request.ReferenceTransactionId = referenceTransactionId;
            return (IOpayoCreateTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<T>)builder;
        }

        public static IOpayoCreateTransactionRequestRepeatTransactionWithReferenceTransactionIdBuilder WithRequiredReferenceTransactionId(this IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IRepeatTransaction> builder, string referenceTransactionId)
        {
            builder.Request.ReferenceTransactionId = referenceTransactionId;
            return (IOpayoCreateTransactionRequestRepeatTransactionWithReferenceTransactionIdBuilder)builder;
        }

        public static IOpayoCreateTransactionRequestRepeatTransactionWithCurrencyBuilder WithRequiredCurrency(this IOpayoCreateTransactionRequestRepeatTransactionWithReferenceTransactionIdBuilder builder, string currency)
        {
            builder.Request.Currency = currency;
            return (IOpayoCreateTransactionRequestRepeatTransactionWithCurrencyBuilder)builder;
        }

        public static IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T> WithRequiredCurrency<T>(this IOpayoCreateTransactionRequestWithTransactionTypeBuilder<T> builder, string currency)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.Currency = currency;
            return (IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T>)builder;
        }

        public static IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T> WithRequiredPaymentMethod<T>(this IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T> builder, OpayoPaymentMethod paymentMethod)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.PaymentMethod = paymentMethod;
            return (IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T>)builder;
        }

        public static IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T> WithRequiredCustomerFirstName<T>(this IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T> builder, string customerFirstName)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerFirstName = customerFirstName;
            return (IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T>)builder;
        }

        public static IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T> WithRequiredCustomerLastName<T>(this IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T> builder, string customerLastName)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.CustomerLastName = customerLastName;
            return (IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T>)builder;
        }

        public static IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<T> WithRequiredBillingAddress<T>(this IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T> builder, OpayoBillingAddress billingAddress)
            where T : IPaymentDeferredAuthenticateTransaction
        {
            builder.Request.BillingAddress = billingAddress;
            return (IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<T>)builder;
        }
    }
}