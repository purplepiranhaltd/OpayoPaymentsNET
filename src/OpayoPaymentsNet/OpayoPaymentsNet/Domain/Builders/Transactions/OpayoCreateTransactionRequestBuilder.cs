﻿using OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;
using OpayoPaymentsNet.Domain.Validators;

namespace OpayoPaymentsNet.Domain.Builders.Transactions
{
    public class OpayoCreateTransactionRequestBuilder :
        IOpayoCreateTransactionRequestBuilder,
        ITransactionBuilder,
        ITransactionWithVendorTxCodeBuilder,
        ITransactionWithDescriptionBuilder,
        ITransactionWithAmountBuilder,
        ITransactionWithTransactionTypeBuilder,
        IRepeatTransactionTransactionWithReferenceTransactionIdBuilder,
        IAuthoriseRefundTransactionWithReferenceTransactionIdBuilder,
        IRepeatTransactionWithCurrencyBuilder,
        IPaymentDeferredAuthenticateTransactionWithCurrencyBuilder,
        IPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder,
        IPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder,
        IPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder,
        IPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder,
        IBuildableTransactionBuilder
    {
        private OpayoCreateTransactionRequest _request;

        private OpayoCreateTransactionRequestBuilder()
        {
            _request = new OpayoCreateTransactionRequest();
        }

        public static ITransactionBuilder Create()
        {
            return new OpayoCreateTransactionRequestBuilder();
        }

        OpayoCreateTransactionRequest IOpayoCreateTransactionRequestBuilder.Transaction => _request;

        public Result<OpayoCreateTransactionRequest> Build()
        {
            OpayoCreateTransactionRequestValidator validator = new();
            var errors = validator.GetErrors(_request);

            if (errors.Any())
                return ValidationResult<OpayoCreateTransactionRequest>.WithErrors(errors.ToArray());

            return Result.Success(_request);
        }
    }
}
