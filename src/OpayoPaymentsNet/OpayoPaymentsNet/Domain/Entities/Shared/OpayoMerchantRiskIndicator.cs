using OpayoPaymentsNet.Domain.Entities.Enums;

namespace OpayoPaymentsNet.Domain.Entities.Shared
{
    /// <summary>
    /// Merchant's assessment of the level of fraud risk for the specific authentication for both the cardholder 
    /// and the authentication being conducted. E.g. Are you shipping goods to the cardholder's billing address, 
    /// is this a first-time order or reorder.
    /// </summary>
    public class OpayoMerchantRiskIndicator
    {
        /// <summary>
        /// For Electronic delivery, the email address to which the merchandise was delivered.
        /// </summary>
        public string? DeliveryEmailAddress { get; set; }

        /// <summary>
        /// Indicates the merchandise delivery timeframe.
        /// </summary>
        public string? DeliveryTimeframe { get; set; }

        /// <summary>
        /// For prepaid or gift card purchase, the purchase amount total of prepaid or gift card(s) in major units
        /// (for example, GBP 123.45 is 123).
        /// </summary>
        public string? GiftCardAmount { get; set; }

        /// <summary>
        /// For prepaid or gift card purchase, total count of individual prepaid or gift cards/codes purchased.
        /// </summary>
        public string? GiftCardCount { get; set; }

        /// <summary>
        /// For a pre-ordered purchase, the expected date that the merchandise will be available.
        /// </summary>
        public string? PreOrderDate { get; set; }

        /// <summary>
        /// Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.
        /// </summary>
        public PreOrderPurchaseIndicator? PreOrderPurchaseInd { get; set; }

        /// <summary>
        /// Indicates whether the cardholder is reordering previously purchased merchandise.
        /// </summary>
        public ReorderItemsIndicator? ReorderItemsInd { get; set; }

        /// <summary>
        /// Indicates shipping method chosen for the transaction. 
        /// You must choose the Shipping Indicator code that most accurately describes the cardholder's specific transaction, 
        /// not their general business. If one or more items are included in the sale, use the Shipping Indicator code for the physical goods, 
        /// or if all digital goods, use the Shipping Indicator code that describes the most expensive item.
        /// </summary>
        public ShippingIndicator? ShipIndicator { get; set; }
    }
}
