# Org.OpenAPITools.Model.StrongCustomerAuthenticationThreeDSRequestorPriorAuthenticationInfo
Information about how you authenticated the cardholder as part of a previous 3DS transaction. E.g. Were they authenticated via frictionless authentication or did a cardholder challenge occur.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ThreeDSReqPriorAuthData** | **string** | Data that documents and supports a specific authentication process. In the current version of the EMVCo specification, this data element is not yet defined. | [optional] 
**ThreeDSReqPriorAuthMethod** | **string** | Mechanism used by the Cardholder during a previous 3DS authentication, as part of a previous transaction request.   * &#x60;FrictionlessAuthentication&#x60; &#x3D; Frictionless authentication occurred by the ACS  * &#x60;ChallengeAuthentication&#x60; &#x3D; Cardholder challenge occurred by ACS  * &#x60;AVSVerified&#x60; &#x3D; AVS verified  * &#x60;OtherIssuerMethods&#x60; &#x3D; Other issuer methods  | [optional] 
**ThreeDSReqPriorAuthTimestamp** | **string** | Date and time in UTC of the prior cardholder 3DS authentication. | [optional] 
**ThreeDSReqPriorRef** | **string** | This data element provides additional information to the ACS to determine the best approach for handling a request. It will contain an ACS Transaction ID for a prior authenticated transaction (for example, the first recurring transaction that was authenticated with the cardholder). This ID will be available in future via MySagePay and the Reporting and Admin API. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

