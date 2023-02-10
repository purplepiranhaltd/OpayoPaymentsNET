﻿using OpayoPaymentsNet.Domain.Entities.Enums;
using OpayoPaymentsNet.Domain.Entities.Shared;
using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Transactions.Responses
{
    public class OpayoCreateTransactionResponse
    {
        /// <summary>
        /// Opayo's unique reference for this transaction.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Access Control Server (ACS) transaction ID. This is a unique ID provided by the card issuer for 3DSv2 authentications.
        /// </summary>
        public string AcsTransId { get; set; }

        /// <summary>
        /// Directory Server (DS) transaction ID. This is a unique ID provided by the card scheme for 3DSv2 authentications.
        /// </summary>
        public string DsTransId { get; set; }

        /// <summary>
        /// The type of the transaction
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// The transaction status
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OpayoTransactionStatus? Status { get; set; }

        /// <summary>
        /// Code related to the status of the transaction. 
        /// Successfully authorised transactions will have the statusCode of 0000. 
        /// You can lookup any other status code on the Opayo website.
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// A detailed reason for the status of the transaction.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// The extended decline code detail which is returned by the card schemes. 
        /// Use this detail to ascertain if you can retry a transaction, 
        /// need to contact your customer or if you should abandon all further attempts.
        /// </summary>
        public OpayoAdditionalDeclineDetail AdditionalDeclineDetail { get; set; }

        /// <summary>
        /// Opayo's unique Authorisation Code for a successfully authorised transaction. 
        /// Only present if status is Ok.
        /// </summary>
        public long? RetrievalReference { get; set; } // TODO: Check this - Opayo docs define this as a string value but a number is returned.

        /// <summary>
        /// A unique reference that you may wish to be displayed on your acquirer's settlement report
        /// (Not enabled for all acquirers. Please contact Opayo support for supported acquirers).
        /// </summary>
        public string? SettlementReferenceText { get; set; }

        /// <summary>
        /// Also known as the decline code, these are codes that are specific to your merchant bank. Please contact them for a description of each code. If a bank response code of 65 or 1A is returned, this is known as a 'soft decline' and means the card issuer requests that your customer performs 3D Secure authentication, where they have to enter Two Factor Authentication (2FA) also known as Strong Customer Authentication (SCA). To achieve this, submit a payment request and provide the field and value apply3DSecure:Force. This is only returned for transaction type Payment
        /// </summary>
        public string BankResponseCode { get; set; }

        /// <summary>
        /// The authorisation code returned from your merchant bank.
        /// </summary>
        public string BankAuthorisationCode { get; set; }

        /// <summary>
        /// The avsCvcCheck object provides information regarding the AVS/CV2 check results.
        /// </summary>
        //public OpayoAvsCvcCheck AvsCvcCheck { get; set; }

        /// <summary>
        /// The paymentMethod object specifies the payment method for the transaction.
        /// </summary>
        public OpayoPaymentMethodResponse? PaymentMethod { get; set; }

        /// <summary>
        /// The amount charged to the customer in the smallest currency unit. (e.g 100 pence to charge £1.00, or 1 to charge ¥1 (0-decimal currency).
        /// </summary>
        public OpayoAmountResponse Amount { get; set; }

        /// <summary>
        /// The currency of the amount in 3 letter ISO 4217 format.
        /// </summary>
        public string? Currency { get; set; }

        [JsonPropertyName("3DSecure")]
        public Opayo3DSecureResponse ThreeDSecure { get; set; }

        /// <summary>
        /// The fiRecipient object is required if your Merchant Category Code (MCC) has a value of 6012 (Financial Institution). 
        /// This is a card scheme mandated requirement. If provided in the transaction request, the fiRecipient object
        /// and it's data will be returned in the transaction response.
        /// </summary>
        public OpayoFinancialInstitutionRecipient? FiRecipient { get; set; }
    }
}
