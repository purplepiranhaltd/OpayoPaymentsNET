using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShippingIndicator
    {
        /// <summary>
        /// Ship to cardholder's billing address
        /// </summary>
        CardholderBillingAddress,

        /// <summary>
        /// Ship to another verified address on file with merchant
        /// </summary>
        OtherVerifiedAddress,

        /// <summary>
        /// Ship to address that is different than the cardholder's billing address
        /// </summary>
        DifferentToCardholderBillingAddress,

        /// <summary>
        ///  Ship to Store / Pick-up at local store (Store address shall be populated in shipping address fields)
        /// </summary>
        LocalPickUp,

        /// <summary>
        /// Digital goods (includes online services, electronic gift cards and redemption codes)
        /// </summary>
        DigitalGoods,

        /// <summary>
        /// Travel and Event tickets, not shipped
        /// </summary>
        NonShippedTickets,

        /// <summary>
        /// Other (for example, Gaming, digital services not shipped, e-media subscriptions, etc.)
        /// </summary>
        Other
    }
}
