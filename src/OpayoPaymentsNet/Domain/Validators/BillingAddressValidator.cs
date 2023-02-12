using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Validators
{
    public class BillingAddressValidator : IValidator<OpayoBillingAddress>
    {
        public IEnumerable<Error> GetErrors(OpayoBillingAddress entity)
        {
            return (FindErrors(entity));
        }


        private IEnumerable<Error> FindErrors(OpayoBillingAddress obj)
        {
            if (obj.Address1 is null || obj.Address1.Length == 0)
                yield return Errors.BillingAddress.Address1Required;
            else if (obj.Address1.Length > 50)
                yield return Errors.BillingAddress.Address1Invalid;

            if (obj.Address2 is not null && obj.Address2.Length > 50)
                yield return Errors.BillingAddress.Address2Invalid;

            if (obj.Address3 is not null && obj.Address3.Length > 50)
                yield return Errors.BillingAddress.Address3Invalid;

            if (obj.City is null || obj.City.Length == 0)
                yield return Errors.BillingAddress.CityRequired;
            else if (obj.City.Length > 40)
                yield return Errors.BillingAddress.CityInvalid;

            // TODO: Clarify postcode rules with Opayo
            // API reference states 'Not required when country is IE'
            // Does this mean that it's required for all other countries?
            // Do all other countries have some form of postal code?
            if (obj.PostalCode is not null && obj.PostalCode.Length > 10)
                yield return Errors.BillingAddress.PostalCodeInvalid;

            // TODO: IS there somekind of ISO 3166-1 lookup that can be used to validate this
            if (obj.Country is null || obj.Country.Length == 0)
                yield return Errors.BillingAddress.CountryRequired;
            else if (obj.Country.Length > 2)
                yield return Errors.BillingAddress.CountryInvalid;
            else if (obj.Country is "US")
            {
                // TODO: IS there somekind of ISO 3166-2 lookup that can be used to validate this
                if (obj.State is null || obj.State.Length == 0)
                    yield return Errors.BillingAddress.StateRequired;
                else if (obj.State.Length > 2)
                    yield return Errors.BillingAddress.StateInvalid;
            }
        }
    }
}
