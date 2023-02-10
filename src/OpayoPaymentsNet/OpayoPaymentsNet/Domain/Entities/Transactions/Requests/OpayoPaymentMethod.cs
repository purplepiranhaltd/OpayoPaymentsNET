namespace OpayoPaymentsNet.Domain.Entities.Transactions.Requests
{
    public class OpayoPaymentMethod
    {
        /// <summary>
        /// The card object represents the credit or debit card details for this transaction.
        /// </summary>
        public OpayoCard? Card { get; set; }

        /// <summary>
        /// The applepay object represents the ApplePay specific information required for this transaction.
        /// </summary>
        public OpayoApplePay? ApplePay { get; set; }
    }
}
