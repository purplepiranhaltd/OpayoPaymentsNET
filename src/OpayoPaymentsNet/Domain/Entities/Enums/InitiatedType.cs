using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    /// <summary>
    /// Indicates whether the cardholder is in-session (CIT), where they are on your website and they select the submit button to make a payment.
    /// Or the cardholder is off-session (MIT), where they are not involved in the payment flow and the merchant initiates the transaction
    /// for goods or services provided.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InitiatedType
    {
        /// <summary>
        /// Consumer Initiated Transaction also known as Cardholder Initiated Transaction.
        /// 3D Secure authentication is required unless it is a MOTO transaction.
        /// </summary>
        CIT,

        /// <summary>
        /// Merchant Initiated Transaction.
        /// The cofUsage:Subsequent must be submitted.
        /// 3D Secure authentication is not required.
        /// </summary>
        MIT
    }
}
