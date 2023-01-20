using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    /// <summary>
    /// Indicates what you'll be storing and using the credential on file for. You must check first with your acquirer to see that
    /// they support the type of MIT you intend to use. Unscheduled Credential on File and Recurring payments are typically supported
    /// by all acquirers. Required if initiatedType:MIT, highly recommended if initiatedType:CIT.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MerchantInitiatedTransactionType
    {
        /// <summary>
        /// A single purchase of goods/services paid for over multiple payments.
        /// </summary>
        Instalment,

        /// <summary>
        /// A purchase of goods/services provided at fixed regular intervals not exceeding one year between transactions.
        /// </summary>
        Recurring,

        /// <summary>
        /// A purchase of goods/services provided at irregular intervals with a fixed or variable amount.
        /// </summary>
        Unscheduled,

        /// <summary>
        /// An additional purchase made after an initial or estimated authorisation.
        /// Example; room service is added to the cardholders stay. Only available for certain MCCs, such as Hotels, Car Rental companies.
        /// </summary>
        Incremental,

        /// <summary>
        /// An additional charge made after original services are rendered.
        /// Example; a parking fine. Only available for certain MCCs such as Car Rental companies.
        /// </summary>
        DelayedCharge,

        /// <summary>
        /// A charge for services where the cardholder entered into an agreement to purchase, but did not meet the terms of the agreement.
        /// Example; A no show after booking a hotel room. Only available for certain MCCs, such as Hotels, Car Rental companies.
        /// </summary>
        NoShow,

        /// <summary>
        /// A further purchase is made after the original purchase. 
        /// xample; extended stays/rentals. Can also be used in split shipment scenarios.
        /// </summary>
        Reauthorisation,

        /// <summary>
        /// An authorisation request has been declined due to insufficient funds bankResponseCode:51, at the time the goods or services
        /// have already provided. You can resubmit your transaction to attempt to get a successful authorisation.
        /// </summary>
        Resubmission
    }
}
