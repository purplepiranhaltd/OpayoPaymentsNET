namespace OpayoPaymentsNet.Domain.Entities.Shared
{
    public class OpayoBillingAddress
    {
        /// <summary>
        /// Billing address line 1, used in AVS check.
        /// </summary>
        public string? Address1 { get; set; }

        /// <summary>
        /// Billing address line 2.
        /// </summary>
        public string? Address2 { get; set; }

        /// <summary>
        /// Billing address line 3.
        /// </summary>
        public string? Address3 { get; set; }

        /// <summary>
        /// Billing city.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Billing postal code, used in AVS check. Not required when country is IE.
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// Two letter country code defined in ISO 3166-1
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Two letter state code defined in ISO 3166-2. Required when country is US.
        /// </summary>
        public string? State { get; set; }
    }
}
