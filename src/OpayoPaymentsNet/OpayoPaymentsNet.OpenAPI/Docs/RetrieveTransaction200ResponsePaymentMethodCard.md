# Org.OpenAPITools.Model.RetrieveTransaction200ResponsePaymentMethodCard
The `card` object represents the credit or debit card details for this transaction.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CardType** | **string** | The type of the card used for the transaction. | [optional] 
**LastFourDigits** | **string** | The last 4 digits of the card number used for the transaction. | [optional] 
**Expiry** | **string** | The expiry date of the card used for the transaction. | [optional] 
**CardIdentifier** | **Guid** | The unique reference of the card you want to charge. | [optional] 
**Reusable** | **bool** | A flag to indicate the card identifier is reusable, i.e. it has been created previously. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

