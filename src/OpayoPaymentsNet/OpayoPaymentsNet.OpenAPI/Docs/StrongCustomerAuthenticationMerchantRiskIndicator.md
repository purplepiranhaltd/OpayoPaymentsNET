# Org.OpenAPITools.Model.StrongCustomerAuthenticationMerchantRiskIndicator
Merchant's assessment of the level of fraud risk for the specific authentication for both the cardholder and the authentication being conducted. E.g. Are you shipping goods to the cardholder's billing address, is this a first-time order or reorder.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DeliveryEmailAddress** | **string** | For Electronic delivery, the email address to which the merchandise was delivered. | [optional] 
**DeliveryTimeframe** | **string** | Indicates the merchandise delivery timeframe.   * &#x60;ElectronicDelivery&#x60; &#x3D; Electronic Delivery   * &#x60;SameDayShipping&#x60; &#x3D; Same day shipping   * &#x60;OvernightShipping&#x60; &#x3D; Overnight shipping   * &#x60;TwoDayOrMoreShipping&#x60; &#x3D; Two-day or more shipping  | [optional] 
**GiftCardAmount** | **string** | For prepaid or gift card purchase, the purchase amount total of prepaid or gift card(s) in major units (for example, GBP 123.45 is 123). | [optional] 
**GiftCardCount** | **string** | For prepaid or gift card purchase, total count of individual prepaid or gift cards/codes purchased. | [optional] 
**PreOrderDate** | **string** | For a pre-ordered purchase, the expected date that the merchandise will be available. | [optional] 
**PreOrderPurchaseInd** | **string** | Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.   * &#x60;MerchandiseAvailable&#x60; &#x3D; Merchandise available   * &#x60;FutureAvailability&#x60; &#x3D; Future availability  | [optional] 
**ReorderItemsInd** | **string** | Indicates whether the cardholder is reordering previously purchased merchandise.   * &#x60;FirstTimeOrdered&#x60; &#x3D; First time ordered   * &#x60;Reordered&#x60; &#x3D; Reordered  | [optional] 
**ShipIndicator** | **string** | Indicates shipping method chosen for the transaction. You must choose the Shipping Indicator code that most accurately describes the cardholder&#39;s specific transaction, not their general business.  If one or more items are included in the sale, use the Shipping Indicator code for the physical goods, or if all digital goods, use the Shipping Indicator code that describes the most expensive item.   * &#x60;CardholderBillingAddress&#x60; &#x3D; Ship to cardholder&#39;s billing address   * &#x60;OtherVerifiedAddress&#x60; &#x3D; Ship to another verified address on file with merchant   * &#x60;DifferentToCardholderBillingAddress&#x60; &#x3D; Ship to address that is different than the cardholder&#39;s billing address   * &#x60;LocalPickUp&#x60; &#x3D; &#39;Ship to Store�? / Pick-up at local store (Store address shall be populated in shipping address fields)   * &#x60;DigitalGoods&#x60; &#x3D; Digital goods (includes online services, electronic gift cards and redemption codes)   * &#x60;NonShippedTickets&#x60; &#x3D; Travel and Event tickets, not shipped   * &#x60;Other&#x60; &#x3D; Other (for example, Gaming, digital services not shipped, e-media subscriptions, etc.)  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

