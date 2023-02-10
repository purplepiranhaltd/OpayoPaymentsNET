# Org.OpenAPITools.Model.CreateTransaction201Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TransactionId** | **string** | Opayo&#39;s unique reference for this transaction. | [optional] 
**AcsTransId** | **string** | Access Control Server (ACS) transaction ID. This is a unique ID provided by the card issuer for 3DSv2 authentications. | [optional] 
**DsTransId** | **string** | Directory Server (DS) transaction ID. This is a unique ID provided by the card scheme for 3DSv2 authentications. | [optional] 
**TransactionType** | **string** | The type of the transaction | [optional] 
**Status** | **string** | Result of transaction registration.  * &#x60;Ok&#x60; - Transaction request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Opayo.  | [optional] 
**StatusCode** | **string** | Code related to the &#x60;status&#x60; of the transaction. *Successfully authorised transactions will have the &#x60;statusCode&#x60; of &#x60;0000&#x60;. You can lookup any other status code on our [website](https://www.opayo.co.uk/support/troubleshooting/error-code ).*  | [optional] 
**StatusDetail** | **string** | A detailed reason for the &#x60;status&#x60; of the transaction. | [optional] 
**AdditionalDeclineDetail** | [**CardAdditionalDeclineDetail**](CardAdditionalDeclineDetail.md) |  | [optional] 
**RetrievalReference** | **string** | Opayo&#39;s unique Authorisation Code for a successfully authorised transaction. Only present if &#x60;status&#x60; is &#x60;Ok&#x60;. | [optional] 
**SettlementReferenceText** | **string** | A unique reference that you may wish to be displayed on your acquirer&#39;s settlement report (Not enabled for all acquirers. Please contact support for supported acquirers). | [optional] 
**BankResponseCode** | **string** | Also known as the decline code, these are codes that are specific to your merchant bank. Please contact them for a description of each code. If a bank response code of &#x60;65&#x60; or &#x60;1A&#x60; is returned, this is known as a &#39;soft decline&#39; and means the card issuer requests that your customer performs 3D Secure authentication, where they have to enter Two Factor Authentication (2FA) also known as Strong Customer Authentication (SCA). To achieve this, submit a payment request and provide the field and value &#x60;apply3DSecure:Force&#x60;. *This is only returned for transaction type &#x60;Payment&#x60;*  | [optional] 
**BankAuthorisationCode** | **string** | The authorisation code returned from your merchant bank. | [optional] 
**AvsCvcCheck** | [**AvsCvcCheck**](AvsCvcCheck.md) |  | [optional] 
**PaymentMethod** | [**RetrieveTransaction200ResponsePaymentMethod**](RetrieveTransaction200ResponsePaymentMethod.md) |  | [optional] 
**Amount** | [**Amount**](.md) |  | [optional] 
**Currency** | **string** | The currency of the amount in 3 letter [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) format. | [optional] 
**_3DSecure** | [**Model3DSecure**](Model3DSecure.md) |  | [optional] 
**FiRecipient** | [**FiRecipient**](FiRecipient.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

