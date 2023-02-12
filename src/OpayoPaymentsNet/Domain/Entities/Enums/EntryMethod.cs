using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EntryMethod
    {
        Ecommerce,
        MailOrder,
        TelephoneOrder
    }
}
