using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;
using OpayoPaymentsNet.Domain.Validators;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.CreateTransactionRequest
{
    public class OpayoCreateTransactionRequestBuilder :
        IOpayoCreateTransactionRequestWithVendorTxCodeBuilder,
        IOpayoCreateTransactionRequestWithDescriptionBuilder,
        IOpayoCreateTransactionRequestWithAmountBuilder,
        IOpayoCreateTransactionRequestWithTransactionTypeBuilder,
        IOpayoCreateTransactionRequestRepeatTransactionWithReferenceTransactionIdBuilder,
        IOpayoCreateTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder,
        IOpayoCreateTransactionRequestRepeatTransactionWithCurrencyBuilder,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder,
        IBuilder<OpayoCreateTransactionRequest>,
        IBuildableBuilder<OpayoCreateTransactionRequest>,
        INewBuilder<OpayoCreateTransactionRequest>
    {
        private OpayoCreateTransactionRequest _request;

        private OpayoCreateTransactionRequestBuilder()
        {
            _request = new OpayoCreateTransactionRequest();
        }

        public static INewBuilder<OpayoCreateTransactionRequest> Create()
        {
            return new OpayoCreateTransactionRequestBuilder();
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
