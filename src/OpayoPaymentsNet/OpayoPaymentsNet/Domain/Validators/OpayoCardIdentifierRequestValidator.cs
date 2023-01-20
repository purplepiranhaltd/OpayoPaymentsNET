using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Validators
{
    internal class OpayoCardIdentifierRequestValidator : IValidator<OpayoCardIdentifierRequest>
    {
        public IEnumerable<Error> GetErrors(OpayoCardIdentifierRequest entity)
        {
            return (FindErrors(entity));
        }


        private IEnumerable<Error> FindErrors(OpayoCardIdentifierRequest obj)
        {

            return FindErrorsForCardDetails(obj.CardDetails);
        }

        private IEnumerable<Error> FindErrorsForCardDetails(OpayoCardDetails obj)
        {
            if (obj.CardholderName is null || obj.CardholderName.Length == 0)
                yield return Errors.CardDetails.CardholderNameRequired;
            else if (obj.CardholderName.Length > 45)
                yield return Errors.CardDetails.CardholderNameInvalid;

            if (obj.CardNumber is null || obj.CardNumber.Length == 0)
                yield return Errors.CardDetails.CardNumberRequired;
            else if (obj.CardNumber.Length > 16)
                yield return Errors.CardDetails.CardNumberInvalid;

            if (obj.ExpiryDate is null || obj.ExpiryDate.Length == 0)
                yield return Errors.CardDetails.ExpiryDateRequired;
            else if (obj.ExpiryDate.Length is not 4)
                yield return Errors.CardDetails.ExpiryDateInvalid;

            if (obj.SecurityCode is null || obj.SecurityCode.Length == 0)
                yield return Errors.CardDetails.SecurityCodeRequired;
            else if (obj.SecurityCode.Length is not 3 or 4)
                yield return Errors.CardDetails.SecurityCodeInvalid;
        }
    }
}
