# Org.OpenAPITools.Model.StrongCustomerAuthenticationAcctInfo
Additional information about the Cardholder's account that has been provided by you. E.g. How long has the cardholder had the account on your website.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ChAccAgeInd** | **string** | Length of time that the cardholder has had their online account with you.    * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;CreatedDuringTransaction&#x60; &#x3D; Created during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days  | [optional] 
**ChAccChange** | **string** | Date that the cardholder&#39;s online account last changed, including Billing or Shipping address, new payment account, or new user(s) added. | [optional] 
**ChAccChangeInd** | **string** | Length of time since the cardholder&#39;s online account information last changed, including Billing or Shipping address, new payment account, or new user(s) added.   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days  | [optional] 
**ChAccDate** | **string** | Date that the cardholder opened their online account with you. | [optional] 
**ChAccPwChange** | **string** | Date that cardholder&#39;s online account had a password change or account reset. | [optional] 
**ChAccPwChangeInd** | **string** | Indicates the length of time since the cardholder&#39;s online account had a password change or account reset.   * &#x60;NoChange&#x60; &#x3D; No change   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days  | [optional] 
**NbPurchaseAccount** | **string** | Number of purchases with this cardholder account during the previous six months. | [optional] 
**ProvisionAttemptsDay** | **string** | Number of Add Card attempts in the last 24 hours. | [optional] 
**TxnActivityDay** | **string** | Number of transactions (successful and abandoned) for this cardholder account with you, across all payment accounts in the previous 24 hours. | [optional] 
**TxnActivityYear** | **string** | Number of transactions (successful and abandoned) for this cardholder account with you, across all payment accounts in the previous year. | [optional] 
**PaymentAccAge** | **string** | Date that the payment account was enrolled in the cardholder&#39;s account with you. | [optional] 
**PaymentAccInd** | **string** | Indicates the length of time that the payment account was enrolled in the cardholder&#39;s account with you.   * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;DuringTransaction&#x60; &#x3D; During this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 day  | [optional] 
**ShipAddressUsage** | **string** | Date when the shipping address used for this transaction was first used with you. | [optional] 
**ShipAddressUsageInd** | **string** | Indicates when the shipping address used for this transaction was first used with you.   * &#x60;ThisTransaction&#x60; &#x3D; This transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days  | [optional] 
**ShipNameIndicator** | **string** | Indicates if the Cardholder Name on the account is identical to the shipping Name used for this transaction.  * &#x60;FullMatch&#x60; &#x3D; Account Name identical to shipping Name  * &#x60;NoMatch&#x60; &#x3D; Account Name different than shipping Name  | [optional] 
**SuspiciousAccActivity** | **string** | Indicates whether you have experienced suspicious activity (including previous fraud) on the cardholder account.  * &#x60;NotSuspicious&#x60; &#x3D; No suspicious activity has been observed  * &#x60;Suspicious&#x60; &#x3D; Suspicious activity has been observed  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

