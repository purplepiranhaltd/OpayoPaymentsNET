using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    /// <summary>
    /// Indicates whether the cardholder is reordering previously purchased merchandise.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReorderItemsIndicator
    {
        /// <summary>
        /// First time ordered
        /// </summary>
        FirstTimeOrdered,

        /// <summary>
        /// Reordered
        /// </summary>
        Reordered
    }
}
