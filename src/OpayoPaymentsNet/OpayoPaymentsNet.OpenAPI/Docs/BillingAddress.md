# Org.OpenAPITools.Model.BillingAddress
The `billingAddress` object is used to define the customer's billing address details. The billing address details will also be used as shipping address details if the `shippingDetails` object is not provided for a transaction.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Address1** | **string** | Billing address line 1, used in AVS check. | 
**Address2** | **string** | Billing address line 2. | [optional] 
**Address3** | **string** | Billing address line 3. | [optional] 
**City** | **string** | Billing city. | 
**PostalCode** | **string** | Billing postal code, used in AVS check. Not required when &#x60;country&#x60; is &#x60;IE&#x60;. | [optional] 
**Country** | **string** | Two letter country code defined in [ISO 3166-1](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) | 
**State** | **string** | Two letter state code defined in [ISO 3166-2](http://en.wikipedia.org/wiki/ISO_3166-2:US). Required when &#x60;country&#x60; is &#x60;US&#x60;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

