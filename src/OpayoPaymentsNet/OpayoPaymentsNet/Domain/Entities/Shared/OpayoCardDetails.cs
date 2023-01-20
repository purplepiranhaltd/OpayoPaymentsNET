namespace OpayoPaymentsNet.Domain.Entities.Shared
{
    public class OpayoCardDetails
    {
        /// <summary>
        /// The name of the card holder
        /// </summary>
        public string? CardholderName { get; set; }

        /// <summary>
        /// The number on the card
        /// </summary>
        public string? CardNumber { get; set; }

        /// <summary>
        /// The expiry date of the card in MMYY format
        /// </summary>
        public string? ExpiryDate { get; set; }

        /// <summary>
        /// The card security code, also known as CV2, CVV, or CVC. This is used in CV2 checks.
        /// </summary>
        public string? SecurityCode { get; set; }
    }
}
