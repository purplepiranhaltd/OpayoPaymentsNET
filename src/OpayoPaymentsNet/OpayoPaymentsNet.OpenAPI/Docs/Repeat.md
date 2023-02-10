# Org.OpenAPITools.Model.Repeat

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TransactionType** | **string** | The type of the transaction | [optional] 
**ReferenceTransactionId** | **string** | The &#x60;transactionId&#x60; of the referenced transaction. | [optional] 
**VendorTxCode** | **string** | Your unique reference for this transaction. | [optional] 
**Amount** | **int** | The amount charged to the customer in the smallest currency unit. (e.g 100 pence to charge £1.00, or 1 to charge ¥1 (0-decimal currency). | [optional] 
**Currency** | **string** | The currency of the amount in 3 letter [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) format. | [optional] 
**Description** | **string** | A brief description of the goods or services purchased. | [optional] 
**ShippingDetails** | [**ShippingDetails**](ShippingDetails.md) |  | [optional] 
**GiftAid** | **bool** | Identifies the customer has ticked a box to indicate that they wish to receive tax back on their donation. | [optional] [default to false]
**CredentialType** | [**CredentialTypeRepeat**](CredentialTypeRepeat.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

