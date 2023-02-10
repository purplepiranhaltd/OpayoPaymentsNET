# Org.OpenAPITools.Model.Deferred

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TransactionType** | **string** | The type of the transaction | [optional] 
**PaymentMethod** | [**PaymentMethod**](PaymentMethod.md) |  | [optional] 
**VendorTxCode** | **string** | Your unique reference for this transaction. | [optional] 
**Amount** | **int** | The amount charged to the customer in the smallest currency unit. (e.g 100 pence to charge £1.00, or 1 to charge ¥1 (0-decimal currency). | [optional] 
**Currency** | **string** | The currency of the amount in 3 letter [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) format. | [optional] 
**SettlementReferenceText** | **string** | A unique reference that you may wish to be displayed on your acquirer&#39;s settlement report (Not enabled for all acquirers. Please contact support for supported acquirers). | [optional] 
**Description** | **string** | A brief description of the goods or services purchased. | [optional] 
**CustomerFirstName** | **string** | Customer&#39;s first names. | [optional] 
**CustomerLastName** | **string** | Customer&#39;s last name. | [optional] 
**BillingAddress** | [**BillingAddress**](BillingAddress.md) |  | [optional] 
**EntryMethod** | **string** | The method used to capture card data. | [optional] [default to EntryMethodEnum.Ecommerce]
**GiftAid** | **bool** | Identifies the customer has ticked a box to indicate that they wish to receive tax back on their donation. | [optional] [default to false]
**Apply3DSecure** | **string** | Use this field to override your default account level 3D Secure settings  * &#x60;UseMSPSetting&#x60; - Use default MySagePay settings.  * &#x60;Force&#x60; - Apply authentication even if turned off.  * &#x60;Disable&#x60; - Only use this if you intend to use an SCA Exemption. See [here](https://developer-eu.elavon.com/docs/opayo/3d-secure-authentication/sca-exemptions) for more information.  * &#x60;ForceIgnoringRules&#x60; - Apply authentication but ignore rules.  | [optional] 
**ApplyAvsCvcCheck** | **string** | Use this field to override your default account level AVS CVC settings.  * &#x60;UseMSPSetting&#x60; - Use default MySagePay settings.  * &#x60;Force&#x60; - Apply authentication even if turned off.  * &#x60;Disable&#x60; - Disable authentication and rules.  * &#x60;ForceIgnoringRules&#x60; - Apply authentication but ignore rules.  | [optional] 
**CustomerEmail** | **string** | Customer&#39;s email address. | [optional] 
**CustomerPhone** | **string** | Customer&#39;s home phone number (this could also be the same as their mobile phone number if they do not have a home phone). The customerPhone must be in the format of &#x60;+&#x60; and &#x60;country code&#x60; and &#x60;phone number&#x60;. Example: For a UK phone number of &#x60;03069 990210&#x60;, you will submit the following: &#x60;+443069990210&#x60;. When using the &#x60;strongCustomerAuthentication&#x60; object, it is advisable to provide this data if the cardholder has it. This will assist the card issuer when determining the 3D Secure authentication result.  | [optional] 
**ShippingDetails** | [**ShippingDetails**](ShippingDetails.md) |  | [optional] 
**ReferrerId** | **string** | This can be used to send the unique reference for the partner that referred the merchant to Opayo. | [optional] 
**StrongCustomerAuthentication** | [**StrongCustomerAuthentication**](StrongCustomerAuthentication.md) |  | [optional] 
**CustomerMobilePhone** | **string** | The mobile number of the customer.    The customerMobilePhone must be in the format of &#x60;+&#x60; and &#x60;country code&#x60; and &#x60;phone number&#x60;.    Example: For a UK phone number of &#x60;07234 567891&#x60;, you will submit the following: &#x60;+447234567891&#x60;    When using the &#x60;strongCustomerAuthentication&#x60; object, it is advisable to provide this data if the cardholder has it. This will assist the card issuer when determining the 3D Secure authentication result.  | [optional] 
**CustomerWorkPhone** | **string** | The work phone number of the customer.    The customerWorkPhone must be in the format of &#x60;+&#x60; and &#x60;country code&#x60; and &#x60;phone number&#x60;.    Example: For a UK phone number of &#x60;01234 567891&#x60;, you will submit the following: &#x60;+441234567891&#x60;    When using the &#x60;strongCustomerAuthentication&#x60; object, it is advisable to provide this data if the cardholder has it. This will assist the card issuer when determining the 3D Secure authentication result.  | [optional] 
**CredentialType** | [**CredentialType**](CredentialType.md) |  | [optional] 
**FiRecipient** | [**FiRecipient**](FiRecipient.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

