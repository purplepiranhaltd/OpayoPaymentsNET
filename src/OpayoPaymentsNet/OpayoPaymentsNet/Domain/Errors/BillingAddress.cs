using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Errors
{
    public static class BillingAddress
    {
        public static readonly Error Address1Required = new Error(
            $"{nameof(BillingAddress)}.{nameof(Address1Required)}",
            "The first line of address is required."
            );

        public static readonly Error CityRequired = new Error(
            $"{nameof(BillingAddress)}.{nameof(CityRequired)}",
            "The city is required."
            );

        public static readonly Error CountryRequired = new Error(
            $"{nameof(BillingAddress)}.{nameof(CountryRequired)}",
            "The amount is required."
            );

        public static readonly Error StateRequired = new Error(
            $"{nameof(BillingAddress)}.{nameof(StateRequired)}",
            "The state is required when the country is 'US'."
            );

        public static readonly Error Address1Invalid = new Error(
            $"{nameof(BillingAddress)}.{nameof(Address1Invalid)}",
            "The first line of address is invalid. Must be <= 50 characters."
            );

        public static readonly Error Address2Invalid = new Error(
            $"{nameof(BillingAddress)}.{nameof(Address2Invalid)}",
            "The second line of address is invalid. Must be <= 50 characters."
            );

        public static readonly Error Address3Invalid = new Error(
           $"{nameof(BillingAddress)}.{nameof(Address3Invalid)}",
           "The third line of address is invalid. Must be <= 50 characters."
           );

        public static readonly Error CityInvalid = new Error(
           $"{nameof(BillingAddress)}.{nameof(CityInvalid)}",
           "The city is invalid. Must be <= 40 characters."
           );

        public static readonly Error PostalCodeInvalid = new Error(
           $"{nameof(BillingAddress)}.{nameof(PostalCodeInvalid)}",
           "The postal code is invalid. Must be <= 10 characters."
           );

        public static readonly Error CountryInvalid = new Error(
           $"{nameof(BillingAddress)}.{nameof(CountryInvalid)}",
           "The country is invalid. Must be exactly 2 characters (ISO 3166-1 format)."
           );

        public static readonly Error StateInvalid = new Error(
           $"{nameof(BillingAddress)}.{nameof(StateInvalid)}",
           "The state is invalid. Must be exactly 2 characters (ISO 3166-2 format)."
           );


    }
}
