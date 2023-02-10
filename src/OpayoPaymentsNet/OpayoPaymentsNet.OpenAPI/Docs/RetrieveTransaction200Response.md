# Org.OpenAPITools.Model.RetrieveTransaction200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TransactionId** | **string** | Opayo&#39;s unique reference for this transaction. | [optional] 
**TransactionType** | **string** | The type of the transaction | [optional] 
**Status** | **string** | Result of transaction registration.  * &#x60;Ok Transaction&#x60; - request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Sage Pay.  | [optional] 
**StatusCode** | **string** | Code related to the &#x60;status&#x60; of the transaction. *Successfully authorised transactions will have the &#x60;statusCode&#x60; of &#x60;0000&#x60;. You can lookup any other status code on our [website](https://www.sagepay.co.uk/support/error-codes).*  | [optional] 
**StatusDetail** | **string** | A detailed reason for the &#x60;status&#x60; of the transaction. | [optional] 
**RetrievalReference** | **string** | Opayo&#39;s unique Authorisation Code for a successfully authorised transaction. Only present if &#x60;status&#x60; is &#x60;Ok&#x60;. | [optional] 
**BankResponseCode** | **string** | Also known as the decline code, these are codes that are specific to your merchant bank. Please contact them for a description of each code. *This is only returned for transaction type &#x60;Payment&#x60;*  | [optional] 
**BankAuthorisationCode** | **string** | The authorisation code returned from your merchant bank. | [optional] 
**Amount** | [**Amount**](Amount.md) |  | [optional] 
**AvsCvcCheck** | [**AvsCvcCheck**](AvsCvcCheck.md) |  | [optional] 
**Currency** | **string** | The currency of the &#x60;amount&#x60; in 3 letter [ISO 4217 format](http://en.wikipedia.org/wiki/ISO_4217). *This is only returned in GET requests* | [optional] 
**PaymentMethod** | [**RetrieveTransaction200ResponsePaymentMethod**](RetrieveTransaction200ResponsePaymentMethod.md) |  | [optional] 
**_3DSecure** | [**Model3DSecure**](Model3DSecure.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

