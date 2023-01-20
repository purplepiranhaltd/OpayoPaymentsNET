using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShippingNameIndicator
    {
        /// <summary>
        /// Account Name identical to shipping Name.
        /// </summary>
        FullMatch,

        /// <summary>
        /// Account Name different than shipping Name.
        /// </summary>
        NoMatch
    }
}
