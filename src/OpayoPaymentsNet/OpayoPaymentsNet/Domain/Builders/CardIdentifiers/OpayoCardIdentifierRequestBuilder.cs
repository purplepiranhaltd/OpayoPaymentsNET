using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Shared;
using OpayoPaymentsNet.Domain.Validators;

namespace OpayoPaymentsNet.Domain.Builders.CardIdentifiers
{
    public class OpayoCardIdentifierRequestBuilder : 
        IOpayoCardIdentifierRequestBuilder,
        IOpayoCardIdentifierRequestBuilderWithCardholderName,
        IOpayoCardIdentifierRequestBuilderWithCardNumber,
        IOpayoCardIdentifierRequestBuilderWithExpiryDate,
        IOpayoCardIdentifierRequestBuilderWithSecurityCode,
        IBuildableOpayoCardIdentifierRequestBuilder
    {
        OpayoCreateCardIdentifierRequest _request;

        private OpayoCardIdentifierRequestBuilder()
        {
            _request = new OpayoCreateCardIdentifierRequest(new OpayoCardDetails());
        }

        OpayoCreateCardIdentifierRequest IOpayoCardIdentifierRequestBuilder.CardIdentifierRequest => _request;

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
    }
}
