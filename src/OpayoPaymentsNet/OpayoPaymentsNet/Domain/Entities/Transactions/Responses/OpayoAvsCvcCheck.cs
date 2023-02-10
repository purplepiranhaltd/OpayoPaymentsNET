namespace OpayoPaymentsNet.Domain.Entities.Transactions.Responses
{
    public class OpayoAvsCvcCheck
    {
        /// <summary>
        /// The overall check result status.
        /// </summary>
        //[JsonConverter(typeof(NullableEnumConverter))]
        public OpayoAvsCvcCheckOverallResult Status { get; set; }

        /// <summary>
        /// The result for address check.
        /// </summary>
        //[JsonConverter(typeof(NullableEnumConverter))]
        public OpayoAvsCvcCheckResult Address { get; set; }

        /// <summary>
        /// The result for postal code check.
        /// </summary>

        //[JsonConverter(typeof(NullableEnumConverter))] 
        public OpayoAvsCvcCheckResult PostalCode { get; set; }

        /// <summary>
        /// The result for security code check.
        /// </summary>
        //[JsonConverter(typeof(NullableEnumConverter))]
        public OpayoAvsCvcCheckResult SecurityCode { get; set; }

        public enum OpayoAvsCvcCheckOverallResult
        {
            AllMatched,
            SecurityCodeMatchOnly,
            AddressMatchOnly,
            NoMatches,
            NotChecked
        }

        public enum OpayoAvsCvcCheckResult
        {
            Matched,
            NotProvided,
            NotChecked,
            NotMatched
        }
    }
}
