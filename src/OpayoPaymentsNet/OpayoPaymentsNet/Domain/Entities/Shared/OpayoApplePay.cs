namespace OpayoPaymentsNet.Domain.Entities.Shared
{
    public class OpayoApplePay
    {
        /// <summary>
        /// The encrypted transaction payload from Apple
        /// </summary>
        public string? Payload { get; set; }

        /// <summary>
        /// The browser / device IP address
        /// </summary>
        public string? ClientIpAddress { get; set; }

        /// <summary>
        /// The token from the getApplePaySession response.
        /// This token must be presented exactly as it appears in the response.
        /// </summary>
        public string? SessionValidationToken { get; set; }
    }
}
