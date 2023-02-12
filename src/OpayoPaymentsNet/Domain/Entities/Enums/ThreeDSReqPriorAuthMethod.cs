using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    /// <summary>
    /// Mechanism used by the Cardholder during a previous 3DS authentication, as part of a previous transaction request.
    /// 
    /// FrictionlessAuthentication = Frictionless authentication occurred by the ACS
    /// ChallengeAuthentication = Cardholder challenge occurred by ACS
    /// AVSVerified = AVS verified
    /// OtherIssuerMethods = Other issuer methods
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ThreeDSReqPriorAuthMethod
    {
        FrictionlessAuthentication,
        ChallengeAuthentication,
        AVSVerified,
        OtherIssuerMethods
    }
}
