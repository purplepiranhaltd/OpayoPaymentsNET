# Org.OpenAPITools.Model.Amount
The `amount` object provides information regarding the total, sale and surcharge amounts for the transaction. The `amount` is only returned in response to GET requests to the transactions resource.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TotalAmount** | **int** | The total amount for the transaction that includes any sale or surcharge values. | [optional] 
**SaleAmount** | **int** | The sale amount associated with the cost of goods or services for the transaction. | [optional] 
**SurchargeAmount** | **int** | The surcharge amount added to the transaction as per the settings of the account. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

