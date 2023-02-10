using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Entities.Transactions.Responses
{
    public class Opayo3DSecureResponse
    {
        /// <summary>
        /// The 3D Secure status of the transaction, if applied.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Opayo3DSecureStatus? Status { get; set; }

        public enum Opayo3DSecureStatus
        {
            /// <summary>
            /// Transaction request completed successfully.
            /// </summary>
            Ok,
            /// <summary>
            /// 3D Secure checks carried out and user authenticated correctly.
            /// </summary>
            Authenticated,
            /// <summary>
            /// 3D Secure checks were not performed. This indicates that 3D Secure was either switched off at the account level, or disabled at transaction registration with the apply3DSecure set to Disable.
            /// </summary>
            NotChecked,
            /// <summary>
            /// 3D Secure authentication checked, but the user failed the authentication.
            /// </summary>
            NotAuthenticated,
            /// <summary>
            /// Authentication could not be attempted due to data errors or service unavailability in one of the parties involved in the check.
            /// </summary>
            Error,
            /// <summary>
            /// This means that the card is not in the 3D Secure scheme.
            /// </summary>
            CardNotEnrolled,
            /// <summary>
            /// This means that the issuer is not part of the 3D Secure scheme.
            /// </summary>
            IssuerNotEnrolled,
            /// <summary>
            /// This means that there is a problem with creating or receiving the 3D Secure data. These should not occur on the live environment.
            /// </summary>
            MalformedOrInvalid,
            /// <summary>
            /// This means that the cardholder attempted to authenticate themselves but the process did not complete. A liability shift may occur for non-Maestro cards, depending on your merchant agreement.
            /// </summary>
            AttemptOnly,
            /// <summary>
            /// This means that the 3D Secure authentication was not available (normally at the card issuer site).
            /// </summary>
            Incomplete
        }
    }
}
