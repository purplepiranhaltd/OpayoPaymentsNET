using OpayoPaymentsNet.Domain.Entities.Enums;

namespace OpayoPaymentsNet.Domain.Entities.Shared
{
    public class OpayoAccountInfo
    {
        /// <summary>
        /// Length of time that the cardholder has had their online account with you.
        /// </summary>
        public CardHolderAccountAgeIndicator? ChAccAgeInd { get; set; }

        /// <summary>
        /// Date that the cardholder's online account last changed, including Billing or Shipping address, 
        /// new payment account, or new user(s) added.
        /// </summary>
        public string? ChAccChange { get; set; }

        /// <summary>
        /// Length of time since the cardholder's online account information last changed, 
        /// including Billing or Shipping address, new payment account, or new user(s) added.
        /// </summary>
        public CardholderAccountChangeIndicator? ChAccChangeInd { get; set; }

        /// <summary>
        /// Date that the cardholder opened their online account with you.
        /// </summary>
        public string? ChAccDate { get; set; }

        /// <summary>
        /// Date that cardholder's online account had a password change or account reset.
        /// </summary>
        public string? ChAccPwChange { get; set; }

        /// <summary>
        /// Indicates the length of time since the cardholder's online account had a password change or account reset.
        /// </summary>
        public CardholderAccountPasswordChangeIndicator? ChAccPwChangeInd { get; set; }

        /// <summary>
        /// Number of purchases with this cardholder account during the previous six months.
        /// </summary>
        public string? NbPurchaseAccount { get; set; }

        /// <summary>
        /// Number of Add Card attempts in the last 24 hours.
        /// </summary>
        public string? ProvisionAttemptsDay { get; set; }

        /// <summary>
        /// Number of transactions (successful and abandoned) for this cardholder account with you, 
        /// across all payment accounts in the previous 24 hours.
        /// </summary>
        public string? TxnActivityDay { get; set; }

        /// <summary>
        /// Number of transactions (successful and abandoned) for this cardholder account with you,
        /// across all payment accounts in the previous year.
        /// </summary>
        public string? TxnActivityYear { get; set; }

        /// <summary>
        /// Date that the payment account was enrolled in the cardholder's account with you.
        /// </summary>
        public PaymentAccountAgeIndicator? PaymentAccAge { get; set; }

        /// <summary>
        /// Date when the shipping address used for this transaction was first used with you.
        /// </summary>
        public string? ShipAddressUsage { get; set; }

        /// <summary>
        /// Indicates when the shipping address used for this transaction was first used with you.
        /// </summary>
        public ShippingAddressUsageIndicator? ShipAddressUsageInd { get; set; }

        /// <summary>
        /// Indicates if the Cardholder Name on the account is identical to the shipping Name used for this transaction.
        /// </summary>
        public ShippingNameIndicator? ShipNameIndicator { get; set; }

        /// <summary>
        /// Indicates whether you have experienced suspicious activity (including previous fraud) on the cardholder account.
        /// </summary>
        public SuspiciousAccountActivityIndicator? SuspiciousAccActivity { get; set; }
    }
}
