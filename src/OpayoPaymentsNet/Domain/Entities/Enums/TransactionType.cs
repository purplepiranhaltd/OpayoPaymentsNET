using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionType
    {
        Payment,
        Deferred,
        Repeat,
        Refund,
        Authenticate,
        Authorise
    }
}
