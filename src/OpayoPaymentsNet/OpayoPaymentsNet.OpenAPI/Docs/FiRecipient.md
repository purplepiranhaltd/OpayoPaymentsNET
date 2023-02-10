# Org.OpenAPITools.Model.FiRecipient
The `fiRecipient` object is required if your Merchant Category Code (MCC) has a value of 6012 (Financial Institution). This is a card scheme mandated requirement. If provided in the transaction request, the `fiRecipient` object and it's data will be returned in the transaction response.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountNumber** | **string** | Primary recipient&#39;s account number. This can either be:   * The first 6 and last 4 characters of the primary recipient&#39;s card PAN (no spaces).   * Where the primary recipient&#39;s account is not a card PAN; this will contain up to 10 characters of the account number (alphanumeric), unless the account number is less than 10 characters long, in which case the account number will be present in its entirety.  | 
**Surname** | **string** | This is the surname of the primary recipient. No special characters such as apostrophes or hyphens are permitted.  | 
**Postcode** | **string** | This is the postcode of the primary recipient.  | 
**DateOfBirth** | **string** | This is the date of birth of the primary recipient in the format YYYYMMDD. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

