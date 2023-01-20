using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    /// <summary>
    /// Indicates whether you are storing the credential to file for the first time. 
    /// When storing the credential for the first time you must also submit the strongCustomerAuthentication object and apply3DSecure:Force, 
    /// as the cardholder must undergo a 3-D Secure authentication with a challenge before you can safely store the credential to file. 
    /// 3-D Secure authentication is not currently required for Mail Order Telephone Order (MOTO) transactions.
    ///
    /// First = You are first storing a credential on file.
    /// Subsequent = You are using a stored credential
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CredentialOnFileUsage
    {
        /// <summary>
        /// You are first storing a credential on file.
        /// </summary>
        First,

        /// <summary>
        /// You are using a stored credential.
        /// </summary>
        Subsequent
    }
}
