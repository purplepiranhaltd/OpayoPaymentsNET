using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CardHolderAccountAgeIndicator
    {
        /// <summary>
        /// No account (guest check-out).
        /// </summary>
        GuestCheckout,

        /// <summary>
        /// Created during this transaction.
        /// </summary>
        CreatedDuringTransaction,

        /// <summary>
        /// Less than 30 days.
        /// </summary>
        LessThanThirtyDays,

        /// <summary>
        /// 30-60 days
        /// </summary>
        ThirtyToSixtyDays,

        /// <summary>
        /// More than 60 days
        /// </summary>
        MoreThanSixtyDays
    }
}
