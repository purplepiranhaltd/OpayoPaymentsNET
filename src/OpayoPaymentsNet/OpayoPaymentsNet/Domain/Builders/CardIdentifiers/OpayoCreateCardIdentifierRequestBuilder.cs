using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Shared;
using OpayoPaymentsNet.Domain.Validators;

namespace OpayoPaymentsNet.Domain.Builders.CardIdentifiers
{
    public class OpayoCreateCardIdentifierRequestBuilder : 
        IOpayoCreateCardIdentifierRequestBuilderWithCardholderName,
        IOpayoCreateCardIdentifierRequestBuilderWithCardNumber,
        IOpayoCreateCardIdentifierRequestBuilderWithExpiryDate,
        IOpayoCreateCardIdentifierRequestBuilderWithSecurityCode,
        IBuilder<OpayoCreateCardIdentifierRequest>,
        IBuildableBuilder<OpayoCreateCardIdentifierRequest>,
        INewBuilder<OpayoCreateCardIdentifierRequest>
    {
        OpayoCreateCardIdentifierRequest _request;

        private OpayoCreateCardIdentifierRequestBuilder()
        {
            _request = new OpayoCreateCardIdentifierRequest(new OpayoCardDetails());
        }

        OpayoCreateCardIdentifierRequest IBuilder<OpayoCreateCardIdentifierRequest>.Request => _request;

        public static INewBuilder<OpayoCreateCardIdentifierRequest> Create()
        {
            return new OpayoCreateCardIdentifierRequestBuilder();
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
