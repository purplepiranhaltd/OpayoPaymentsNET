namespace OpayoPaymentsNet.Domain.Entities.Shared
{
    public class OpayoShippingDetails
    {
        /// <summary>
        /// Recipient’s first names.
        /// </summary>
        public string? RecipientFirstName { get; set; }

        /// <summary>
        /// Recipient’s last name.
        /// </summary>
        public string? RecipientLastName { get; set; }

        /// <summary>
        /// Shipping address line 1.
        /// </summary>
        public string? ShippingAddress1 { get; set; }

        /// <summary>
        /// Shipping address line 2.
        /// </summary>
        public string? ShippingAddress2 { get; set; }

        /// <summary>
        /// Shipping address line 3.
        /// </summary>
        public string? ShippingAddress3 { get; set; }

        /// <summary>
        /// Shipping city.
        /// </summary>
        public string? ShippingCity { get; set; }

        /// <summary>
        /// Shipping postal code. Not required when shippingCountry is IE.
        /// </summary>
        public string? ShippingPostalCode { get; set; }

        /// <summary>
        /// Shipping country. Two letter country code defined in ISO 3166-1
        /// </summary>
        public string? ShippingCountry { get; set; }

        /// <summary>
        /// Two letter state code defined in ISO 3166-2. Required when shippingCountry is US.
        /// </summary>
        public string? ShippingState { get; set; }
    }
}
