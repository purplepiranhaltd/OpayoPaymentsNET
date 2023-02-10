# Org.OpenAPITools.Model.Model3DSv2

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**StatusCode** | **string** | Code related to the &#x60;status&#x60; of the transaction. *You can lookup any status code on our [website](https://www.opayo.co.uk/support/troubleshooting/error-code).*  | [optional] 
**StatusDetail** | **string** | A detailed reason for the &#x60;status&#x60; of the transaction. | [optional] 
**TransactionId** | **string** | Opayo&#39;s unique reference for this transaction. | [optional] 
**AcsTransId** | **string** | Access Control Server (ACS) transaction ID. This is a unique ID provided by the card issuer for 3DSv2 authentications. | [optional] 
**DsTransId** | **string** | Directory Server (DS) transaction ID. This is a unique ID provided by the card scheme for 3DSv2 authentications. | [optional] 
**AcsUrl** | **string** | A fully qualified URL that points to the 3D Secure authentication system at the card holder&#39;s issuing bank | [optional] 
**CReq** | **string** | A Base64 encoded message to be passed to the Issuing Bank as part of the 3D Secure Authentication. This replaces the PAReq. When forwarding the &#x60;cReq&#x60; to the &#x60;acsUrl&#x60;, pass it in a field called &#x60;creq&#x60; (note the lower case &#x60;cr&#x60;).  This avoids issues at the ACS which expects the fieldname to be all lowercase.  | [optional] 
**Status** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

