using OpayoPaymentsNet.Domain.Entities.Enums;
using OpayoPaymentsNet.Domain.Entities.Shared;

namespace OpayoPaymentsNet.Domain.Entities.Transactions.Requests
{
    public class OpayoCreateTransactionRequest
    {
        /// <summary>
        /// The type of the transaction
        /// </summary>
        public TransactionType? TransactionType { get; set; }

        /// <summary>
        /// Your unique reference for this transaction.
        /// </summary>
        public string? VendorTxCode { get; set; }

        /// <summary>
        /// The amount charged to the customer in the smallest currency unit. e.g 100 pence to charge £1.00, or 1 to charge ¥1 (0-decimal currency).
        /// </summary>
        public int? Amount { get; set; }

        /// <summary>
        /// A brief description of the goods or services purchased.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The paymentMethod object specifies the payment method for the transaction.
        /// </summary>
        public OpayoPaymentMethod? PaymentMethod { get; set; }

        /// <summary>
        /// The currency of the amount in 3 letter ISO 4217 format.
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// A unique reference that you may wish to be displayed on your acquirer's settlement report
        /// (Not enabled for all acquirers. Please contact Opayo support for supported acquirers).
        /// </summary>
        public string? SettlementReferenceText { get; set; }

        /// <summary>
        /// Customer’s first names.
        /// </summary>
        public string? CustomerFirstName { get; set; }

        /// <summary>
        /// Customer’s last name.
        /// </summary>
        public string? CustomerLastName { get; set; }

        /// <summary>
        /// The billingAddress object is used to define the customer’s billing address details. 
        /// The billing address details will also be used as shipping address details if the
        /// shippingDetails object is not provided for a transaction.
        /// </summary>
        public OpayoBillingAddress? BillingAddress { get; set; }

        /// <summary>
        /// The method used to capture card data.
        /// </summary>
        public EntryMethod? EntryMethod { get; set; }

        /// <summary>
        /// Identifies the customer has ticked a box to indicate that they wish to receive tax back on their donation.
        /// </summary>
        public bool? GiftAid { get; set; }

        /// <summary>
        /// Use this field to override your default account level 3-D Secure settings
        /// </summary>
        public ApplyCheck? Apply3DSecure { get; set; }

        /// <summary>
        /// Use this field to override your default account level AVS CVC settings.
        /// </summary>
        public ApplyCheck? ApplyAvsCvcCheck { get; set; }

        /// <summary>
        /// Customer’s email address.
        /// </summary>
        public string? CustomerEmail { get; set; }

        /// <summary>
        /// Customer’s home phone number (this could also be the same as their mobile phone number if they do not have a home phone). 
        /// The customerPhone must be in the format of + and country code and phone number. 
        /// Example: For a UK phone number of 03069 990210, you will submit the following: +443069990210. 
        /// When using the strongCustomerAuthentication object, it is advisable to provide this data if the cardholder has it. 
        /// This will assist the card issuer when determining the 3-D Secure authentication result.
        /// </summary>
        public string? CustomerPhone { get; set; }

        /// <summary>
        /// The shippingDetails object is used to specify the shipping address details for a transaction.
        /// If not provided the values provided in the billingAddress object will be used for shipping information instead.
        /// </summary>
        public OpayoShippingDetails? ShippingDetails { get; set; }

        /// <summary>
        /// This can be used to send the unique reference for the partner that referred the merchant to Sage Pay.
        /// </summary>
        public string? ReferrerId { get; set; }

        /// <summary>
        /// The strongCustomerAuthentication object is used for 3D Secure Version 2.
        /// </summary>
        public OpayoStrongCustomerAuthentication? StrongCustomerAuthentication { get; set; }

        /// <summary>
        /// The mobile number of the customer.
        /// 
        /// The customerMobilePhone must be in the format of + and country code and phone number.
        /// Example: For a UK phone number of 07234 567891, you will submit the following: +447234567891
        /// 
        /// When using the strongCustomerAuthentication object, it is advisable to provide this data if the cardholder has it.
        /// This will assist the card issuer when determining the 3-D Secure authentication result.
        /// </summary>
        public string? CustomerMobilePhone { get; set; }


        /// <summary>
        /// The work phone number of the customer.
        /// 
        /// The customerWorkPhone must be in the format of + and country code and phone number.
        /// Example: For a UK phone number of 01234 567891, you will submit the following: +441234567891
        /// 
        /// When using the strongCustomerAuthentication object, it is advisable to provide this data if the cardholder has it.
        /// This will assist the card issuer when determining the 3-D Secure authentication result.
        /// </summary>
        public string? CustomerWorkPhone { get; set; }

        /// <summary>
        /// The credentialType object is required when creating a token Save:true or using a token reusable:true or
        /// for Repeat transactions where transactionType:Repeat. 
        /// It advises the card issuer the reason why your storing a credential on file, and when using a stored credential.
        /// </summary>
        public OpayoCredentialType? CredentialType { get; set; }

        /// <summary>
        /// The fiRecipient object is required if your Merchant Category Code (MCC) has a value of 6012 (Financial Institution). 
        /// This is a card scheme mandated requirement. If provided in the transaction request, the fiRecipient object
        /// and it's data will be returned in the transaction response.
        /// </summary>
        public OpayoFinancialInstitutionRecipient? FiRecipient { get; set; }

        /// <summary>
        /// The transactionId of the referenced transaction.
        /// </summary>
        public string? ReferenceTransactionId { get; set; }

        /// <summary>
        /// The card security code, also known as CV2, CVV, or CVC. This is used in CV2 checks.
        /// </summary>
        public string? Cv2 { get; set; }
    }
}
