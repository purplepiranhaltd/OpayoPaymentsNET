using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApplyCheck
    {
        /// <summary>
        /// Use default MySagePay settings.
        /// </summary>
        UseMSPSetting,

        /// <summary>
        /// Apply authentication even if turned off.
        /// </summary>
        Force,

        /// <summary>
        /// Disable authentication and rules.
        /// </summary>
        Disable,

        /// <summary>
        /// Apply authentication but ignore rules.
        /// </summary>
        ForceIgnoringRules
    }
}
