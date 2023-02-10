# Org.OpenAPITools.Model.Authorise

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TransactionType** | **string** | The type of the transaction | [optional] 
**ReferenceTransactionId** | **string** | The &#x60;transactionId&#x60; of the referenced transaction. | [optional] 
**VendorTxCode** | **string** | Your unique reference for this transaction. | [optional] 
**Amount** | **int** | The amount charged to the customer in the smallest currency unit. (e.g 100 pence to charge £1.00, or 1 to charge ¥1 (0-decimal currency). | [optional] 
**Description** | **string** | A brief description of the goods or services purchased. | [optional] 
**ApplyAvsCvcCheck** | **string** | Use this field to override your default account level AVS CVC settings.  * &#x60;UseMSPSetting&#x60; - Use default MySagePay settings.  * &#x60;Force&#x60; - Apply authentication even if turned off.  * &#x60;Disable&#x60; - Disable authentication and rules.  * &#x60;ForceIgnoringRules&#x60; - Apply authentication but ignore rules.  | [optional] 
**Cv2** | **string** | The card security code, also known as CV2, CVV, or CVC. This is used in CV2 checks. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

