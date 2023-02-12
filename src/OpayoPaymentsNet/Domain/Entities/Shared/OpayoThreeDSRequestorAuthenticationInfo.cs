using OpayoPaymentsNet.Domain.Entities.Enums;

namespace OpayoPaymentsNet.Domain.Entities.Shared
{
    public class OpayoThreeDSRequestorAuthenticationInfo
    {
        /// <summary>
        /// Data that documents and supports a specific authentication process. In the current version of the EMVCo specification, this data element is not yet defined.
        /// </summary>
        public string? ThreeDSReqAuthData { get; set; }

        /// <summary>
        /// Mechanism used by the Cardholder to authenticate when they logged into their online account, on your website.
        /// </summary>
        public ThreeDSReqAuthMethod? ThreeDSReqAuthMethod { get; set; }

        /// <summary>
        /// Date and time in UTC of the cardholder authentication when they logged into their online account, on your website.
        /// </summary>
        public string? ThreeDSReqAuthTimestamp { get; set; }
    }
}
