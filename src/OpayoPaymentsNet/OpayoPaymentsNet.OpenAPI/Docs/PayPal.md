# Org.OpenAPITools.Model.Paypal
The response returned by Opayo for a PayPal transaction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TransactionId** | **string** | Opayo&#39;s unique reference for this transaction. | [optional] 
**TransactionType** | **string** | The type of the transaction | [optional] 
**PaymentMethod** | [**PaypalPaymentMethod**](PaypalPaymentMethod.md) |  | [optional] 
**Status** | **string** | Result of transaction registration.  * &#x60;Ok&#x60; - Transaction request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Opayo.  | [optional] 
**StatusCode** | **string** | Code related to the &#x60;status&#x60; of the transaction. *Successfully authorised transactions will have the &#x60;statusCode&#x60; of &#x60;0000&#x60;. You can lookup any other status code on our [website](https://www.opayo.co.uk/support/troubleshooting/error-code ).*  | [optional] 
**StatusDetail** | **string** | A detailed reason for the &#x60;status&#x60; of the transaction. | [optional] 
**Amount** | [**Amount**](.md) |  | [optional] 
**Currency** | **string** | The currency of the amount in 3 letter [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) format. | [optional] 
**ShippingDetails** | [**PaypalShippingDetails**](PaypalShippingDetails.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

