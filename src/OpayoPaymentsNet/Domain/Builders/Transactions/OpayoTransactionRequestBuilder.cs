﻿using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;
using OpayoPaymentsNet.Domain.Validators;

namespace OpayoPaymentsNet.Domain.Builders.Transactions
{
    public class OpayoTransactionRequestBuilder :
        IOpayoTransactionRequestWithVendorTxCodeBuilder,
        IOpayoTransactionRequestWithDescriptionBuilder,
        IOpayoTransactionRequestWithAmountBuilder,
        IOpayoTransactionRequestWithTransactionTypeBuilder,
        IOpayoTransactionRequestRepeatTransactionWithReferenceTransactionIdBuilder,
        IOpayoTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder,
        IOpayoTransactionRequestRepeatTransactionWithCurrencyBuilder,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder,
        IBuilder<OpayoCreateTransactionRequest>,
        IBuildableBuilder<OpayoCreateTransactionRequest>,
        INewBuilder<OpayoCreateTransactionRequest>
    {
        private OpayoCreateTransactionRequest _request;

        private OpayoTransactionRequestBuilder()
        {
            _request = new OpayoCreateTransactionRequest();
        }

        public static INewBuilder<OpayoCreateTransactionRequest> Create()
        {
            return new OpayoTransactionRequestBuilder();
        }

        OpayoCreateTransactionRequest IBuilder<OpayoCreateTransactionRequest>.Request => _request;

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
