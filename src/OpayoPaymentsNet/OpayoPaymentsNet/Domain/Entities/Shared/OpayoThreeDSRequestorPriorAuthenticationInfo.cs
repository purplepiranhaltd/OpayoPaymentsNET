using OpayoPaymentsNet.Domain.Entities.Enums;

namespace OpayoPaymentsNet.Domain.Entities.Shared
{
    public class OpayoThreeDSRequestorPriorAuthenticationInfo
    {
        /// <summary>
        /// Data that documents and supports a specific authentication process. In the current version of the EMVCo specification, this data element is not yet defined.
        /// </summary>
        public string? ThreeDSReqPriorAuthData { get; set; }

        /// <summary>
        /// Mechanism used by the Cardholder to authenticate when they logged into their online account, on your website.
        /// </summary>
        public ThreeDSReqPriorAuthMethod? ThreeDSReqPriorAuthMethod { get; set; }

        /// <summary>
        /// Date and time in UTC of the cardholder authentication when they logged into their online account, on your website.
        /// </summary>
        public string? ThreeDSReqPriorAuthTimestamp { get; set; }

        /// <summary>
        /// This data element provides additional information to the ACS to determine the best approach for handling a request.
        /// It will contain an ACS Transaction ID for a prior authenticated transaction (for example, the first recurring 
        /// transaction that was authenticated with the cardholder). 
        /// This ID will be available in future via MySagePay and the Reporting and Admin API.
        /// </summary>
        public string? ThreeDSReqPriorRef { get; set; }
    }
}
