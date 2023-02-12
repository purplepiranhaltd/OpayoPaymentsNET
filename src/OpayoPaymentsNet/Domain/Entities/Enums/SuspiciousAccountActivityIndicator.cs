using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SuspiciousAccountActivityIndicator
    {
        /// <summary>
        /// No suspicious activity has been observed
        /// </summary>
        NotSuspicious,

        /// <summary>
        /// Suspicious activity has been observed
        /// </summary>
        Suspicious
    }
}
