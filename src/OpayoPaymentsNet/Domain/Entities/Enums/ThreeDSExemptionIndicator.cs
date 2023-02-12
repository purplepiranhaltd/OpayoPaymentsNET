using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    /// <summary>
    /// Mechanism used by the Cardholder during a previous 3DS authentication, as part of a previous transaction request.
    /// 
    /// FrictionlessAuthentication = Frictionless authentication occurred by the ACS
    /// ChallengeAuthentication = Cardholder challenge occurred by ACS
    /// AVSVerified = AVS verified
    /// OtherIssuerMethods = Other issuer methods
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ThreeDSExemptionIndicator
    {
        /// <summary>
        /// Low Value Transaction (LVT); the transaction value must be 30 EUR or less and is permitted for a maximum of five consecutive 
        /// LVTs or a maximum cumulative LVT amount can be 100 EUR. On the sixth LVT or when the cumulative LVT amount is over 100 EUR, 
        /// then 3D Secure authentication must be performed. Since the cardholder could have used their LVT exemptions elsewhere on other 
        /// merchants' sites, you would not be able to accurately use this exemption. 
        /// Only the card issuer will know if the LVT exemption counters have been reached.
        /// </summary>
        LowValue,

        /// <summary>
        /// Transaction Risk Analysis (TRA); if you or your acquirer have a low number of chargebacks over a given number of transactions, 
        /// the card schemes will have more trust in you and the acquirer and permit eligible merchants to bypass authentication using the
        /// TRA exemption.
        /// </summary>
        TransactionRiskAnalysis,

        /// <summary>
        /// Trusted beneficiaries / merchant; you can use this exemption if the cardholder adds you to a trusted beneficiaries list.
        /// They can do this if prompted to do so by their card issuer either when they log into their bank account or during a challenge
        /// authentication flow.
        /// </summary>
        TrustedMerchant,

        /// <summary>
        /// Secure Corporate Payments; if your client uses a secure corporate card such as a lodge corporate card or virtual card numbers,
        /// then these are exempt from 3D Secure authentication. These payments will be typically Business to Business payments (B2B),
        /// which will already have dedicated corporate processes and protocols in place. This exemption does not apply for personal
        /// corporate cards.
        /// </summary>
        SecureCorporatePayment,

        /// <summary>
        /// Delegated Authentication; You can request for this exemption to not perform 3D Secure authentication again if you have already
        /// performed it. To be able to do this, you must already have undergone accreditation with the card schemes for 3D Secure authentication.
        /// This means the card schemes now trust you to perform 3D Secure authentication independently of them (the card schemes have
        /// delegated authentication to you).
        /// </summary>
        DelegatedAuthentication
    }
}
