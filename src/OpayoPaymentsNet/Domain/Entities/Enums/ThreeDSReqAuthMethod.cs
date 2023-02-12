using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    /// <summary>
    /// Mechanism used by the Cardholder to authenticate when they logged into their online account, on your website.
    /// 
    /// NoThreeDSRequestorAuthentication = No authentication occurred (i.e. cardholder “logged in” as guest).
    /// LoginWithThreeDSRequestorCredentials = Login to the cardholder account at the merchant's website using the merchant's own authentication credentials.
    /// LoginWithFederatedId = Login to the cardholder account at the merchant's website using federated ID.
    /// LoginWithIssuerCredentials = Login to the cardholder account at the merchant's website using the card issuer's authentication credentials.
    /// LoginWithThirdPartyAuthentication = Login to the cardholder account at the merchant's website using third-party authentication.
    /// LoginWithFIDOAuthenticator = Login to the cardholder account at the merchant's website using FIDO Authenticator.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ThreeDSReqAuthMethod
    {
        NoThreeDSRequestorAuthentication,
        LoginWithThreeDSRequestorCredentials,
        LoginWithFederatedId,
        LoginWithIssuerCredentials,
        LoginWithThirdPartyAuthentication,
        LoginWithFIDOAuthenticator
    }
}
