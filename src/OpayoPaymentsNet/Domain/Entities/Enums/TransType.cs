using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Enums
{
    /// <summary>
    /// Identifies the type of transaction being authenticated.
    /// 
    /// GoodsAndServicePurchase = Goods/ Service Purchase
    /// CheckAcceptance = Check Acceptance
    /// AccountFunding = Account Funding
    /// QuasiCashTransaction = Quasi-Cash Transaction
    /// PrepaidActivationAndLoad = Prepaid Activation and Load
    /// 
    /// Values derived from the 8583 ISO Standard.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransType
    {
        GoodsAndServicePurchase,
        CheckAcceptance,
        AccountFunding,
        QuasiCashTransaction,
        PrepaidActivationAndLoad
    }
}
