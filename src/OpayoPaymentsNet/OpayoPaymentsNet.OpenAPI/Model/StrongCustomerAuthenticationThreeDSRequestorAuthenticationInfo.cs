/*
 * Opayo API Documentation
 *
 * # Introduction  The Opayo REST API is based on [REST](http://en.wikipedia.org/wiki/Representational_state_transfer) principles. Our resource oriented URLs are only accessible via HTTPS and are available in both our test and live environment.  We use [HTTP Authentication](#section/Authentication) and HTTP verbs for each method:  |Verb | Description                    | |- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| |GET  | Used for retrieving resources. | |POST | Used for creating resources.   |  The Opayo API uses [JSON](http://en.wikipedia.org/wiki/JSON) format for both requests and responses.  We return [HTTP Response Codes](#section/Response-Codes) to indicate the success or failure of an API request, along with further information in the body.  ## Environments  The Test Server is an exact copy of the Live System but without the banks attached. This means you get a true user experience but without the fear of any money being taken from your cards during testing.  If you want to test our API without an account you can use one of our [sandbox accounts](#tag/Sandbox-Accounts).  If you would like to test our API with your own credentials you will need a Test Server account to be set up for you by the Opayo Support team. Your test account can only be set up once you have submitted an online [Opayo application](https://applications.sagepay.com/apply).  Please ensure that you update your integration to the Live environment API endpoints and credentials before you go live.  ## Getting your API credentials  Before you can start integrating with our REST API you need to get your Integration Key and Password. You can do that by following the guide below:  1. Go to MySagePay in either the [TEST](https://test.sagepay.com/mysagepay) or [LIVE](https://live.sagepay.com/mysagepay) environment and log in using the Administration log in details that were provided to you during the setup of the account.  2. Once you are logged in as the Administrator, in the Password details section of the Administrator tab you will see an option to 'Create API credentials'.  3. To create your credentials you just have to select the tick-box labelled 'I understand that this will create new credentials and may break any existing Opayo API implementations.' and click on the 'Create API credentials' button.  4. Once you have opted to create your new credentials we will present you with the following information:    - Environment: This specifies the environment for which the credentials apply (test or live)   - Vendor Name: The vendor name for the account   - Integration Key: The value for the Integration key (username)   - Integration Password: The value for the Integration password  **When you choose to create new credentials, any previously generated credentials are immediately rendered invalid. Therefore, if you have already integrated with our REST API, you will not be able to authenticate your calls until you replace your expired credentials with the ones you just generated.**  Please store these credentials safely. If you lose them, you will need to generate a new set of credentials using the same process.  Please note that these credentials are only valid for our REST API.  # Versioning  The current version of the Opayo API is v1, as defined in the base URL.  To ensure we don't break your code, it's essential that you support the following compatible changes:  * Adding new API resources * Adding new optional request parameters. * Adding new response properties. * Adding additional values to parameters or properties in requests and responses. * Changing the length or format of existing fields and resources.  Each time we release a change which isn't backwards compatible (requires you to make a change), we will release a new version of the API.  Of course, we won't suddenly stop supporting older versions but we would advise that to make full use of new benefits, you try to use the latest version.  Read our [API changelog](#tag/API-Changelog) to learn more and keep track of any changes.   # Authentication Requests to the Opayo API require authentication. We use [HTTP Basic authentication](https://en.wikipedia.org/wiki/Basic_access_authentication) for a simple, yet secure method of enforcing access controls.  In order to access our protected resources you must authenticate with our API by providing us with your:  - Integration Key (Username) - Integration Password (Password)  How to authenticate:  1. Using HTTP Basic authentication, you will need to combine into a string 'integrationKey:integrationPassword'. 1. The resulting string will have to be encoded using [Base64](https://en.wikipedia.org/wiki/Base64) encoding. 1. The encoded string will have to be included in the Authorization header.  _The only exception to the above is the [card identifier](#tag/Card-Identifiers). To create a card identifier you will need to use the Merchant Session Keys as an access token in the Authorization request header field._  As the Opayo API is available in our test and live environments, we will provide you with different credentials for both.  Please ensure that you are using the correct credentials for each environment.  **Remember, all requests must be made over HTTPS. This is to ensure that all the sensitive customer information is protected.**  # Response Codes  As much as possible, we attempt to use appropriate HTTP status codes, as well as returning additional details to aid with error handling.  ## HTTP Response Codes  The Opayo API will return appropriate HTTP status codes for every request.  | Code | Text                 | Description |- -- -- -|- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | 200  | OK                   | Success! Everything worked as expected. | 201  | Created              | Success! Everything worked as expected and a new resource has been created. | 202  | Accepted             | The request has been accepted for processing, but the processing has not been completed. | 204  | No Content           | The request has been successfully processed and is not returning any content. | 400  | Bad Request          | The request could not be understood, generally a malformed body. | 401  | Unauthorised         | Authentication credentials are missing or incorrect. | 403  | Forbidden            | The request was formed correctly but is unsuccessful. Usually returned when a transaction request is declined or rejected. | 404  | Not Found            | The resource does not exist. | 405  | Method Not Allowed   | The method requested is not permitted against this resource. | 408  | Request              | Timeout  Request timeout. | 418  | I'm a teapot         | [https://en.wikipedia.org/wiki/418](https://en.wikipedia.org/wiki/Hyper_Text_Coffee_Pot_Control_Protocol) | 422  | Unprocessable Entity | The request was well-formed but contains invalid values or missing properties. | 500  | Server Error         | An issue occurred at Opayo. | 502  | Bad Gateway          | An issue occurred at Opayo.  ## Opayo Error Codes  As well as returning the HTTP response code, the Opayo API will, when possible, return more detail about the error in the body. This will contain the properties `code` and `description` in JSON format.  When the HTTP response code is `422`, `property` and `clientMessage` fields are also returned, identifying which specific property the error relates to and a user-friendly message. When multiple `422` errors are detected these will be returned in an `errors` array.  Below is a complete list of Opayo errors.  | HTTP   | Code | Description |- -- -- -- -|- -- -- -|- -- -- -- -- -- -- | `400 ` | 1000 | Incorrect request format | `401 ` | 1001 | Authentication values are missing | `401 ` | 1002 | Authentication failed | `422 ` | 1003 | Missing mandatory field | `422 ` | 1004 | Invalid length | `422 ` | 1005 | Contains invalid characters | `404 ` | 1006 | Merchant Session Keys not found | `422 ` | 1007 | The card number has failed our validity checks and is invalid | `422 ` | 1008 | The card is not supported | `422 ` | 1009 | Contains invalid value | `422 ` | 1010 | Currency does not exist | `422 ` | 1011 | Merchant Session Keys or card identifier invalid | `404 ` | 1012 | Transaction not found | `403 ` | 1013 | Transaction type not supported | `403 ` | 1014 | Transaction status not applicable | `422 ` | 1015 | The request entity was empty | `422 ` | 1016 | This parameter requires an integer | `403 ` | 1017 | Operation not allowed for this transaction | `403 ` | 1018 | This refund amount will exceed the amount of the original transaction | `404 ` | 1019 | Transaction instructions not found | `422 ` | 1020 | Unable to save a card identifier that is already reusable | `403 ` | 1021 | This release amount will exceed the amount of the original transaction | `408 ` | 9998 | Request timeout | `500 ` | 9999 | An internal error occurred at Opayo  ### Example JSON  ```JSON {    \"errors\":[       {          \"code\": \"1005\",          \"property\": \"cardDetails.cardholderName\",          \"description\": \"Contains invalid characters\",          \"clientMessage\": \"The cardholder name contains invalid characters\"       },       {          \"code\": \"1004\",          \"property\": \"cardDetails.cardholderName\",          \"description\": \"Invalid length\",          \"clientMessage\": \"The cardholder name is too long\"       },       {          \"code\": \"1003\",          \"property\": \"cardDetails.cardNumber\",          \"description\": \"Missing mandatory field\",          \"clientMessage\": \"The card number is required\"       },       {          \"code\": \"1005\",          \"property\": \"cardDetails.expiryDate\",          \"description\": \"Contains invalid characters\",          \"clientMessage\": \"The expiry date has to be in MMYY format\"       }    ] } ```  ### Transaction Error Codes  During transaction registration you may receive HTTP 422 errors with a code and description not mentioned in the table above.  To get help with our terminology and those error codes you can visit [our website](https://www.opayo.co.uk/support/error-codes) and type the relevant error code there. 
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = OpayoPaymentsNet.OpenAPI.Client.OpenAPIDateConverter;

namespace OpayoPaymentsNet.OpenAPI.Model
{
    /// <summary>
    /// Information about how you authenticated the cardholder before or during the transaction. E.g. Did your customer log into their online account on your website, using two-factor authentication, or did they log in as a guest.
    /// </summary>
    [DataContract(Name = "strongCustomerAuthentication_threeDSRequestorAuthenticationInfo")]
    public partial class StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo : IEquatable<StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo>, IValidatableObject
    {
        /// <summary>
        /// Mechanism used by the Cardholder to authenticate when they logged into their online account, on your website.    * &#x60;NoThreeDSRequestorAuthentication&#x60; &#x3D; No authentication occurred (i.e. cardholder &#39;logged in�? as guest).   * &#x60;LoginWithThreeDSRequestorCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the merchant&#39;s own authentication credentials.   * &#x60;LoginWithFederatedId&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using federated ID.   * &#x60;LoginWithIssuerCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the card issuer&#39;s authentication credentials.   * &#x60;LoginWithThirdPartyAuthentication&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using third-party authentication.   * &#x60;LoginWithFIDOAuthenticator&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using FIDO Authenticator. 
        /// </summary>
        /// <value>Mechanism used by the Cardholder to authenticate when they logged into their online account, on your website.    * &#x60;NoThreeDSRequestorAuthentication&#x60; &#x3D; No authentication occurred (i.e. cardholder &#39;logged in�? as guest).   * &#x60;LoginWithThreeDSRequestorCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the merchant&#39;s own authentication credentials.   * &#x60;LoginWithFederatedId&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using federated ID.   * &#x60;LoginWithIssuerCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the card issuer&#39;s authentication credentials.   * &#x60;LoginWithThirdPartyAuthentication&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using third-party authentication.   * &#x60;LoginWithFIDOAuthenticator&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using FIDO Authenticator. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ThreeDSReqAuthMethodEnum
        {
            /// <summary>
            /// Enum NoThreeDSRequestorAuthentication for value: NoThreeDSRequestorAuthentication
            /// </summary>
            [EnumMember(Value = "NoThreeDSRequestorAuthentication")]
            NoThreeDSRequestorAuthentication = 1,

            /// <summary>
            /// Enum LoginWithThreeDSRequestorCredentials for value: LoginWithThreeDSRequestorCredentials
            /// </summary>
            [EnumMember(Value = "LoginWithThreeDSRequestorCredentials")]
            LoginWithThreeDSRequestorCredentials = 2,

            /// <summary>
            /// Enum LoginWithFederatedId for value: LoginWithFederatedId
            /// </summary>
            [EnumMember(Value = "LoginWithFederatedId")]
            LoginWithFederatedId = 3,

            /// <summary>
            /// Enum LoginWithIssuerCredentials for value: LoginWithIssuerCredentials
            /// </summary>
            [EnumMember(Value = "LoginWithIssuerCredentials")]
            LoginWithIssuerCredentials = 4,

            /// <summary>
            /// Enum LoginWithThirdPartyAuthentication for value: LoginWithThirdPartyAuthentication
            /// </summary>
            [EnumMember(Value = "LoginWithThirdPartyAuthentication")]
            LoginWithThirdPartyAuthentication = 5,

            /// <summary>
            /// Enum LoginWithFIDOAuthenticator for value: LoginWithFIDOAuthenticator
            /// </summary>
            [EnumMember(Value = "LoginWithFIDOAuthenticator")]
            LoginWithFIDOAuthenticator = 6

        }


        /// <summary>
        /// Mechanism used by the Cardholder to authenticate when they logged into their online account, on your website.    * &#x60;NoThreeDSRequestorAuthentication&#x60; &#x3D; No authentication occurred (i.e. cardholder &#39;logged in�? as guest).   * &#x60;LoginWithThreeDSRequestorCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the merchant&#39;s own authentication credentials.   * &#x60;LoginWithFederatedId&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using federated ID.   * &#x60;LoginWithIssuerCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the card issuer&#39;s authentication credentials.   * &#x60;LoginWithThirdPartyAuthentication&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using third-party authentication.   * &#x60;LoginWithFIDOAuthenticator&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using FIDO Authenticator. 
        /// </summary>
        /// <value>Mechanism used by the Cardholder to authenticate when they logged into their online account, on your website.    * &#x60;NoThreeDSRequestorAuthentication&#x60; &#x3D; No authentication occurred (i.e. cardholder &#39;logged in�? as guest).   * &#x60;LoginWithThreeDSRequestorCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the merchant&#39;s own authentication credentials.   * &#x60;LoginWithFederatedId&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using federated ID.   * &#x60;LoginWithIssuerCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the card issuer&#39;s authentication credentials.   * &#x60;LoginWithThirdPartyAuthentication&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using third-party authentication.   * &#x60;LoginWithFIDOAuthenticator&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using FIDO Authenticator. </value>
        [DataMember(Name = "threeDSReqAuthMethod", EmitDefaultValue = false)]
        public ThreeDSReqAuthMethodEnum? ThreeDSReqAuthMethod { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo" /> class.
        /// </summary>
        /// <param name="threeDSReqAuthData">Data that documents and supports a specific authentication process. In the current version of the EMVCo specification, this data element is not yet defined..</param>
        /// <param name="threeDSReqAuthMethod">Mechanism used by the Cardholder to authenticate when they logged into their online account, on your website.    * &#x60;NoThreeDSRequestorAuthentication&#x60; &#x3D; No authentication occurred (i.e. cardholder &#39;logged in�? as guest).   * &#x60;LoginWithThreeDSRequestorCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the merchant&#39;s own authentication credentials.   * &#x60;LoginWithFederatedId&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using federated ID.   * &#x60;LoginWithIssuerCredentials&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using the card issuer&#39;s authentication credentials.   * &#x60;LoginWithThirdPartyAuthentication&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using third-party authentication.   * &#x60;LoginWithFIDOAuthenticator&#x60; &#x3D; Login to the cardholder account at the merchant&#39;s website using FIDO Authenticator. .</param>
        /// <param name="threeDSReqAuthTimestamp">Date and time in UTC of the cardholder authentication when they logged into their online account, on your website..</param>
        public StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo(string threeDSReqAuthData = default, ThreeDSReqAuthMethodEnum? threeDSReqAuthMethod = default, string threeDSReqAuthTimestamp = default)
        {
            ThreeDSReqAuthData = threeDSReqAuthData;
            ThreeDSReqAuthMethod = threeDSReqAuthMethod;
            ThreeDSReqAuthTimestamp = threeDSReqAuthTimestamp;
        }

        /// <summary>
        /// Data that documents and supports a specific authentication process. In the current version of the EMVCo specification, this data element is not yet defined.
        /// </summary>
        /// <value>Data that documents and supports a specific authentication process. In the current version of the EMVCo specification, this data element is not yet defined.</value>
        [DataMember(Name = "threeDSReqAuthData", EmitDefaultValue = false)]
        public string ThreeDSReqAuthData { get; set; }

        /// <summary>
        /// Date and time in UTC of the cardholder authentication when they logged into their online account, on your website.
        /// </summary>
        /// <value>Date and time in UTC of the cardholder authentication when they logged into their online account, on your website.</value>
        [DataMember(Name = "threeDSReqAuthTimestamp", EmitDefaultValue = false)]
        public string ThreeDSReqAuthTimestamp { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo {\n");
            sb.Append("  ThreeDSReqAuthData: ").Append(ThreeDSReqAuthData).Append("\n");
            sb.Append("  ThreeDSReqAuthMethod: ").Append(ThreeDSReqAuthMethod).Append("\n");
            sb.Append("  ThreeDSReqAuthTimestamp: ").Append(ThreeDSReqAuthTimestamp).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo);
        }

        /// <summary>
        /// Returns true if StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    ThreeDSReqAuthData == input.ThreeDSReqAuthData ||
                    ThreeDSReqAuthData != null &&
                    ThreeDSReqAuthData.Equals(input.ThreeDSReqAuthData)
                ) &&
                (
                    ThreeDSReqAuthMethod == input.ThreeDSReqAuthMethod ||
                    ThreeDSReqAuthMethod.Equals(input.ThreeDSReqAuthMethod)
                ) &&
                (
                    ThreeDSReqAuthTimestamp == input.ThreeDSReqAuthTimestamp ||
                    ThreeDSReqAuthTimestamp != null &&
                    ThreeDSReqAuthTimestamp.Equals(input.ThreeDSReqAuthTimestamp)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (ThreeDSReqAuthData != null)
                {
                    hashCode = hashCode * 59 + ThreeDSReqAuthData.GetHashCode();
                }
                hashCode = hashCode * 59 + ThreeDSReqAuthMethod.GetHashCode();
                if (ThreeDSReqAuthTimestamp != null)
                {
                    hashCode = hashCode * 59 + ThreeDSReqAuthTimestamp.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // ThreeDSReqAuthData (string) maxLength
            if (ThreeDSReqAuthData != null && ThreeDSReqAuthData.Length > 2048)
            {
                yield return new ValidationResult("Invalid value for ThreeDSReqAuthData, length must be less than 2048.", new[] { "ThreeDSReqAuthData" });
            }

            // ThreeDSReqAuthTimestamp (string) maxLength
            if (ThreeDSReqAuthTimestamp != null && ThreeDSReqAuthTimestamp.Length > 12)
            {
                yield return new ValidationResult("Invalid value for ThreeDSReqAuthTimestamp, length must be less than 12.", new[] { "ThreeDSReqAuthTimestamp" });
            }

            yield break;
        }
    }

}
