using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    /// <summary>
    /// Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PreOrderPurchaseIndicator
    {
        /// <summary>
        /// Merchandise available
        /// </summary>
        MerchandiseAvailable,

        /// <summary>
        /// Future availability
        /// </summary>
        FutureAvailability
    }
}
