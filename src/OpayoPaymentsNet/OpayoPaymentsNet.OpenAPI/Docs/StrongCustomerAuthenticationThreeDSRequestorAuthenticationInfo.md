# Org.OpenAPITools.Model.StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo
Information about how you authenticated the cardholder before or during the transaction. E.g. Did your customer log into their online account on your website, using two-factor authentication, or did they log in as a guest.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ThreeDSReqAuthData** | **string** | Data that documents and supports a specific authentication process. In the current version of the EMVCo specification, this data element is not yet defined. | [optional] 
**ThreeDSReqAuthMethod** | **string** | Mechanism used by the Cardholder to authenticate when they logged into their online account, on your website.    * &#x60;NoThreeDSRequestorAuthentication&#x60; &#x3D; No authentication occurred (i.e. cardholder &#39;logged in�? as guest).   * &#x60;LoginWithThreeDSRequestorCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the merchant&#39;s own authentication credentials.   * &#x60;LoginWithFederatedId&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using federated ID.   * &#x60;LoginWithIssuerCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the card issuer&#39;s authentication credentials.   * &#x60;LoginWithThirdPartyAuthentication&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using third-party authentication.   * &#x60;LoginWithFIDOAuthenticator&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using FIDO Authenticator.  | [optional] 
**ThreeDSReqAuthTimestamp** | **string** | Date and time in UTC of the cardholder authentication when they logged into their online account, on your website. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

