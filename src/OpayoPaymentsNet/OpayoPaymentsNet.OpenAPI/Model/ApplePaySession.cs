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
    /// ApplePaySession
    /// </summary>
    [DataContract(Name = "ApplePaySession")]
    public partial class ApplePaySession : IEquatable<ApplePaySession>, IValidatableObject
    {
        /// <summary>
        /// Result of transaction registration.  * &#x60;Ok&#x60; - Transaction request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Opayo. 
        /// </summary>
        /// <value>Result of transaction registration.  * &#x60;Ok&#x60; - Transaction request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Opayo. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Ok for value: Ok
            /// </summary>
            [EnumMember(Value = "Ok")]
            Ok = 1,

            /// <summary>
            /// Enum NotAuthed for value: NotAuthed
            /// </summary>
            [EnumMember(Value = "NotAuthed")]
            NotAuthed = 2,

            /// <summary>
            /// Enum Rejected for value: Rejected
            /// </summary>
            [EnumMember(Value = "Rejected")]
            Rejected = 3,

            /// <summary>
            /// Enum Malformed for value: Malformed
            /// </summary>
            [EnumMember(Value = "Malformed")]
            Malformed = 4,

            /// <summary>
            /// Enum Invalid for value: Invalid
            /// </summary>
            [EnumMember(Value = "Invalid")]
            Invalid = 5,

            /// <summary>
            /// Enum Error for value: Error
            /// </summary>
            [EnumMember(Value = "Error")]
            Error = 6

        }


        /// <summary>
        /// Result of transaction registration.  * &#x60;Ok&#x60; - Transaction request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Opayo. 
        /// </summary>
        /// <value>Result of transaction registration.  * &#x60;Ok&#x60; - Transaction request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Opayo. </value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplePaySession" /> class.
        /// </summary>
        /// <param name="transactionId">Opayo&#39;s unique reference for this transaction..</param>
        /// <param name="status">Result of transaction registration.  * &#x60;Ok&#x60; - Transaction request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Opayo. .</param>
        /// <param name="statusDetail">A detailed reason for the &#x60;status&#x60; of the transaction..</param>
        /// <param name="epochTimeStamp">The date and time of the signature&#39;s creation in milliseconds, formatted in Unix epoch time..</param>
        /// <param name="expiresAt">The date and time of the signature&#39;s creation in milliseconds, formatted in Unix epoch time..</param>
        /// <param name="merchantSessionIdentifier">The value of the merchant session to be passed back to the browser session..</param>
        /// <param name="nonce">A one-time nonce value generated by Apple&#39;s servers..</param>
        /// <param name="merchantIdentifier">Your merchant identifier..</param>
        /// <param name="domainName">The domain that is registered with Apple Pay..</param>
        /// <param name="displayName">The display name associated with your vendor account..</param>
        /// <param name="sessionValidationToken">A token used to validate the session when you transact via Apple Pay.</param>
        /// <param name="signature">A hash of the public key used to sign the interactions..</param>
        public ApplePaySession(string transactionId = default, StatusEnum? status = default, string statusDetail = default, string epochTimeStamp = default, string expiresAt = default, string merchantSessionIdentifier = default, string nonce = default, string merchantIdentifier = default, string domainName = default, string displayName = default, string sessionValidationToken = default, string signature = default)
        {
            TransactionId = transactionId;
            Status = status;
            StatusDetail = statusDetail;
            EpochTimeStamp = epochTimeStamp;
            ExpiresAt = expiresAt;
            MerchantSessionIdentifier = merchantSessionIdentifier;
            Nonce = nonce;
            MerchantIdentifier = merchantIdentifier;
            DomainName = domainName;
            DisplayName = displayName;
            SessionValidationToken = sessionValidationToken;
            Signature = signature;
        }

        /// <summary>
        /// Opayo&#39;s unique reference for this transaction.
        /// </summary>
        /// <value>Opayo&#39;s unique reference for this transaction.</value>
        [DataMember(Name = "transactionId", EmitDefaultValue = false)]
        public string TransactionId { get; set; }

        /// <summary>
        /// A detailed reason for the &#x60;status&#x60; of the transaction.
        /// </summary>
        /// <value>A detailed reason for the &#x60;status&#x60; of the transaction.</value>
        [DataMember(Name = "statusDetail", EmitDefaultValue = false)]
        public string StatusDetail { get; set; }

        /// <summary>
        /// The date and time of the signature&#39;s creation in milliseconds, formatted in Unix epoch time.
        /// </summary>
        /// <value>The date and time of the signature&#39;s creation in milliseconds, formatted in Unix epoch time.</value>
        [DataMember(Name = "epochTimeStamp", EmitDefaultValue = false)]
        public string EpochTimeStamp { get; set; }

        /// <summary>
        /// The date and time of the signature&#39;s creation in milliseconds, formatted in Unix epoch time.
        /// </summary>
        /// <value>The date and time of the signature&#39;s creation in milliseconds, formatted in Unix epoch time.</value>
        [DataMember(Name = "expiresAt", EmitDefaultValue = false)]
        public string ExpiresAt { get; set; }

        /// <summary>
        /// The value of the merchant session to be passed back to the browser session.
        /// </summary>
        /// <value>The value of the merchant session to be passed back to the browser session.</value>
        [DataMember(Name = "merchantSessionIdentifier", EmitDefaultValue = false)]
        public string MerchantSessionIdentifier { get; set; }

        /// <summary>
        /// A one-time nonce value generated by Apple&#39;s servers.
        /// </summary>
        /// <value>A one-time nonce value generated by Apple&#39;s servers.</value>
        [DataMember(Name = "nonce", EmitDefaultValue = false)]
        public string Nonce { get; set; }

        /// <summary>
        /// Your merchant identifier.
        /// </summary>
        /// <value>Your merchant identifier.</value>
        [DataMember(Name = "merchantIdentifier", EmitDefaultValue = false)]
        public string MerchantIdentifier { get; set; }

        /// <summary>
        /// The domain that is registered with Apple Pay.
        /// </summary>
        /// <value>The domain that is registered with Apple Pay.</value>
        [DataMember(Name = "domainName", EmitDefaultValue = false)]
        public string DomainName { get; set; }

        /// <summary>
        /// The display name associated with your vendor account.
        /// </summary>
        /// <value>The display name associated with your vendor account.</value>
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// A token used to validate the session when you transact via Apple Pay
        /// </summary>
        /// <value>A token used to validate the session when you transact via Apple Pay</value>
        [DataMember(Name = "sessionValidationToken", EmitDefaultValue = false)]
        public string SessionValidationToken { get; set; }

        /// <summary>
        /// A hash of the public key used to sign the interactions.
        /// </summary>
        /// <value>A hash of the public key used to sign the interactions.</value>
        [DataMember(Name = "signature", EmitDefaultValue = false)]
        public string Signature { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ApplePaySession {\n");
            sb.Append("  TransactionId: ").Append(TransactionId).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  StatusDetail: ").Append(StatusDetail).Append("\n");
            sb.Append("  EpochTimeStamp: ").Append(EpochTimeStamp).Append("\n");
            sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
            sb.Append("  MerchantSessionIdentifier: ").Append(MerchantSessionIdentifier).Append("\n");
            sb.Append("  Nonce: ").Append(Nonce).Append("\n");
            sb.Append("  MerchantIdentifier: ").Append(MerchantIdentifier).Append("\n");
            sb.Append("  DomainName: ").Append(DomainName).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  SessionValidationToken: ").Append(SessionValidationToken).Append("\n");
            sb.Append("  Signature: ").Append(Signature).Append("\n");
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
            return Equals(input as ApplePaySession);
        }

        /// <summary>
        /// Returns true if ApplePaySession instances are equal
        /// </summary>
        /// <param name="input">Instance of ApplePaySession to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApplePaySession input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    TransactionId == input.TransactionId ||
                    TransactionId != null &&
                    TransactionId.Equals(input.TransactionId)
                ) &&
                (
                    Status == input.Status ||
                    Status.Equals(input.Status)
                ) &&
                (
                    StatusDetail == input.StatusDetail ||
                    StatusDetail != null &&
                    StatusDetail.Equals(input.StatusDetail)
                ) &&
                (
                    EpochTimeStamp == input.EpochTimeStamp ||
                    EpochTimeStamp != null &&
                    EpochTimeStamp.Equals(input.EpochTimeStamp)
                ) &&
                (
                    ExpiresAt == input.ExpiresAt ||
                    ExpiresAt != null &&
                    ExpiresAt.Equals(input.ExpiresAt)
                ) &&
                (
                    MerchantSessionIdentifier == input.MerchantSessionIdentifier ||
                    MerchantSessionIdentifier != null &&
                    MerchantSessionIdentifier.Equals(input.MerchantSessionIdentifier)
                ) &&
                (
                    Nonce == input.Nonce ||
                    Nonce != null &&
                    Nonce.Equals(input.Nonce)
                ) &&
                (
                    MerchantIdentifier == input.MerchantIdentifier ||
                    MerchantIdentifier != null &&
                    MerchantIdentifier.Equals(input.MerchantIdentifier)
                ) &&
                (
                    DomainName == input.DomainName ||
                    DomainName != null &&
                    DomainName.Equals(input.DomainName)
                ) &&
                (
                    DisplayName == input.DisplayName ||
                    DisplayName != null &&
                    DisplayName.Equals(input.DisplayName)
                ) &&
                (
                    SessionValidationToken == input.SessionValidationToken ||
                    SessionValidationToken != null &&
                    SessionValidationToken.Equals(input.SessionValidationToken)
                ) &&
                (
                    Signature == input.Signature ||
                    Signature != null &&
                    Signature.Equals(input.Signature)
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
                if (TransactionId != null)
                {
                    hashCode = hashCode * 59 + TransactionId.GetHashCode();
                }
                hashCode = hashCode * 59 + Status.GetHashCode();
                if (StatusDetail != null)
                {
                    hashCode = hashCode * 59 + StatusDetail.GetHashCode();
                }
                if (EpochTimeStamp != null)
                {
                    hashCode = hashCode * 59 + EpochTimeStamp.GetHashCode();
                }
                if (ExpiresAt != null)
                {
                    hashCode = hashCode * 59 + ExpiresAt.GetHashCode();
                }
                if (MerchantSessionIdentifier != null)
                {
                    hashCode = hashCode * 59 + MerchantSessionIdentifier.GetHashCode();
                }
                if (Nonce != null)
                {
                    hashCode = hashCode * 59 + Nonce.GetHashCode();
                }
                if (MerchantIdentifier != null)
                {
                    hashCode = hashCode * 59 + MerchantIdentifier.GetHashCode();
                }
                if (DomainName != null)
                {
                    hashCode = hashCode * 59 + DomainName.GetHashCode();
                }
                if (DisplayName != null)
                {
                    hashCode = hashCode * 59 + DisplayName.GetHashCode();
                }
                if (SessionValidationToken != null)
                {
                    hashCode = hashCode * 59 + SessionValidationToken.GetHashCode();
                }
                if (Signature != null)
                {
                    hashCode = hashCode * 59 + Signature.GetHashCode();
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
            // TransactionId (string) maxLength
            if (TransactionId != null && TransactionId.Length > 36)
            {
                yield return new ValidationResult("Invalid value for TransactionId, length must be less than 36.", new[] { "TransactionId" });
            }

            // StatusDetail (string) maxLength
            if (StatusDetail != null && StatusDetail.Length > 255)
            {
                yield return new ValidationResult("Invalid value for StatusDetail, length must be less than 255.", new[] { "StatusDetail" });
            }

            // EpochTimeStamp (string) maxLength
            if (EpochTimeStamp != null && EpochTimeStamp.Length > 20)
            {
                yield return new ValidationResult("Invalid value for EpochTimeStamp, length must be less than 20.", new[] { "EpochTimeStamp" });
            }

            // ExpiresAt (string) maxLength
            if (ExpiresAt != null && ExpiresAt.Length > 20)
            {
                yield return new ValidationResult("Invalid value for ExpiresAt, length must be less than 20.", new[] { "ExpiresAt" });
            }

            // MerchantSessionIdentifier (string) maxLength
            if (MerchantSessionIdentifier != null && MerchantSessionIdentifier.Length > 255)
            {
                yield return new ValidationResult("Invalid value for MerchantSessionIdentifier, length must be less than 255.", new[] { "MerchantSessionIdentifier" });
            }

            // Nonce (string) maxLength
            if (Nonce != null && Nonce.Length > 255)
            {
                yield return new ValidationResult("Invalid value for Nonce, length must be less than 255.", new[] { "Nonce" });
            }

            // MerchantIdentifier (string) maxLength
            if (MerchantIdentifier != null && MerchantIdentifier.Length > 255)
            {
                yield return new ValidationResult("Invalid value for MerchantIdentifier, length must be less than 255.", new[] { "MerchantIdentifier" });
            }

            // DomainName (string) maxLength
            if (DomainName != null && DomainName.Length > 100)
            {
                yield return new ValidationResult("Invalid value for DomainName, length must be less than 100.", new[] { "DomainName" });
            }

            // DisplayName (string) maxLength
            if (DisplayName != null && DisplayName.Length > 50)
            {
                yield return new ValidationResult("Invalid value for DisplayName, length must be less than 50.", new[] { "DisplayName" });
            }

            // SessionValidationToken (string) maxLength
            if (SessionValidationToken != null && SessionValidationToken.Length > 255)
            {
                yield return new ValidationResult("Invalid value for SessionValidationToken, length must be less than 255.", new[] { "SessionValidationToken" });
            }

            // Signature (string) maxLength
            if (Signature != null && Signature.Length > 255)
            {
                yield return new ValidationResult("Invalid value for Signature, length must be less than 255.", new[] { "Signature" });
            }

            yield break;
        }
    }

}
