using OpayoPaymentsNet.Domain.Entities.Enums;
using OpayoPaymentsNet.Domain.Entities.Shared;
using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Transactions.Responses
{
    public class OpayoCreateTransactionResponse : OpayoRetrieveTransactionResponse
    {
        /// <summary>
        /// Access Control Server (ACS) transaction ID. This is a unique ID provided by the card issuer for 3DSv2 authentications.
        /// </summary>
        public string AcsTransId { get; set; }

        /// <summary>
        /// Directory Server (DS) transaction ID. This is a unique ID provided by the card scheme for 3DSv2 authentications.
        /// </summary>
        public string DsTransId { get; set; }

        /// <summary>
        /// The extended decline code detail which is returned by the card schemes. 
        /// Use this detail to ascertain if you can retry a transaction, 
        /// need to contact your customer or if you should abandon all further attempts.
        /// </summary>
        public OpayoAdditionalDeclineDetail AdditionalDeclineDetail { get; set; }

        /// <summary>
        /// A unique reference that you may wish to be displayed on your acquirer's settlement report
        /// (Not enabled for all acquirers. Please contact Opayo support for supported acquirers).
        /// </summary>
        public string? SettlementReferenceText { get; set; }

        /// <summary>
        /// The fiRecipient object is required if your Merchant Category Code (MCC) has a value of 6012 (Financial Institution). 
        /// This is a card scheme mandated requirement. If provided in the transaction request, the fiRecipient object
        /// and it's data will be returned in the transaction response.
        /// </summary>
        public OpayoFinancialInstitutionRecipient? FiRecipient { get; set; }
    }
}
