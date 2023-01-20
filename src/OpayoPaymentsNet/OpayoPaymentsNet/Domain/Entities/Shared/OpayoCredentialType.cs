using OpayoPaymentsNet.Domain.Entities.Enums;

namespace OpayoPaymentsNet.Domain.Entities.Shared
{
    public class OpayoCredentialType
    {
        /// <summary>
        /// Indicates whether you are storing the credential to file for the first time. When storing the credential for the first time
        /// you must also submit the strongCustomerAuthentication object and apply3DSecure:Force, as the cardholder must undergo a
        /// 3D Secure authentication with a challenge before you can safely store the credential to file.
        /// 3D Secure authentication is not currently required for Mail Order Telephone Order (MOTO) transactions.
        /// </summary>
        public CredentialOnFileUsage? CofUsage { get; set; }

        /// <summary>
        /// Indicates whether the cardholder is in-session (CIT), where they are on your website and they select the submit button
        /// to make a payment. Or the cardholder is off-session (MIT), where they are not involved in the payment flow and the merchant
        /// initiates the transaction for goods or services provided.
        /// </summary>
        public InitiatedType? InitiatedType { get; set; }

        /// <summary>
        /// Indicates what you'll be storing and using the credential on file for.
        /// You must check first with your acquirer to see that they support the type of MIT you intend to use.
        /// Unscheduled Credential on File and Recurring payments are typically supported by all acquirers.
        /// Required if initiatedType:MIT, highly recommended if initiatedType:CIT.
        /// </summary>
        public MerchantInitiatedTransactionType? MitType { get; set; }

        /// <summary>
        /// YYYYMMDD. Required if mitType:Recurring or mitType:Instalment. 
        /// This value relates to the date of when the last Recurring payment or Instalment will occur. 
        /// If you submit a Recurring or Instalment transaction request after this date for the stored credential, 
        /// the card issuer may decline the transaction or provide a 'soft decline'.
        /// </summary>
        public string? RecurringExpiry { get; set; }

        /// <summary>
        /// Value is in days. Required if mitType:Recurring or mitType:Instalment. 
        /// The regular frequency of the Recurring payment or Instalment.
        /// </summary>
        public string? RecurringFrequency { get; set; }

        /// <summary>
        /// Value is in days. 
        /// Required if mitType:Instalment. 
        /// Must be a value greater than 1, example, 2 and upwards. 
        /// The number of instalments required to fully pay off the received goods or services. 
        /// Any extra instalments taken greater than the value entered, may lead to the card issuer declining the transaction request.
        /// </summary>
        public string? PurchaseInstalData { get; set; }
    }
}
