using OpayoPaymentsNet.Domain.Builders.CardIdentifiers.Interfaces;
using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Shared;
using OpayoPaymentsNet.Domain.Validators;

namespace OpayoPaymentsNet.Domain.Builders.CardIdentifiers
{
    public class OpayoCardIdentifierRequestBuilder : IOpayoCardIdentifierRequestBuilder
    {
        OpayoCreateCardIdentifierRequest _request;

        private OpayoCardIdentifierRequestBuilder()
        {
            _request = new OpayoCreateCardIdentifierRequest(new OpayoCardDetails());
        }

        public static IOpayoCardIdentifierRequestBuilder Create()
        {
            return new OpayoCardIdentifierRequestBuilder();
        }

        //OpayoCardIdentifierRequest IOpayoCardIdentifierRequestBuilder.CardIdentifierRequest => _request;

        public Result<OpayoCreateCardIdentifierRequest> Build()
        {
            OpayoCardIdentifierRequestValidator validator = new();
            var errors = validator.GetErrors(_request);

            if (errors.Any())
                return ValidationResult<OpayoCreateCardIdentifierRequest>.WithErrors(errors.ToArray());

            return Result.Success(_request);
        }

        public IOpayoCardIdentifierRequestBuilder WithCardholderName(string cardholderName)
        {
            _request.CardDetails.CardholderName = cardholderName;
            return this;
        }

        public IOpayoCardIdentifierRequestBuilder WithCardNumber(string cardnumber)
        {
            _request.CardDetails.CardNumber = cardnumber;
            return this;
        }

        public IOpayoCardIdentifierRequestBuilder WithExpiryDate(string expiryDate)
        {
            _request.CardDetails.ExpiryDate = expiryDate;
            return this;
        }

        public IOpayoCardIdentifierRequestBuilder WithSecurityCode(string securityCode)
        {
            _request.CardDetails.SecurityCode = securityCode;
            return this;
        }
    }
}
