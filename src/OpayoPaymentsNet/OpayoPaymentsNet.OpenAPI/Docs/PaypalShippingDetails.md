# Org.OpenAPITools.Model.PaypalShippingDetails
The `shippingDetails` object is used to specify the shipping address details for a transaction. If not provided the values provided in the `billingAddress` object will be used for shipping information instead.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RecipientFirstName** | **string** | Recipient&#39;s first names. | [optional] 
**RecipientLastName** | **string** | Recipient&#39;s last name. | [optional] 
**ShippingAddress1** | **string** | Shipping address line 1. | [optional] 
**ShippingAddress2** | **string** | Shipping address line 2. | [optional] 
**ShippingAddress3** | **string** | Shipping address line 3. | [optional] 
**ShippingCity** | **string** | Shipping city. | [optional] 
**ShippingPostalCode** | **string** | Shipping postal code. Not required when &#x60;shippingCountry&#x60; is &#x60;IE&#x60;. | [optional] 
**ShippingCountry** | **string** | Shipping country. Two letter country code defined in [ISO 3166-1](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) | [optional] 
**ShippingState** | **string** | Two letter state code defined in [ISO 3166-2](http://en.wikipedia.org/wiki/ISO_3166-2:US). Required when &#x60;shippingCountry&#x60; is &#x60;US&#x60;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

