using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;

namespace OpayoPaymentsNet.Domain.Entities.Transactions.Responses
{
    public class OpayoPaymentMethodResponse
    {
        /// <summary>
        /// The card object represents the credit or debit card details for this transaction.
        /// </summary>
        public OpayoCard? Card { get; set; }
    }
}
