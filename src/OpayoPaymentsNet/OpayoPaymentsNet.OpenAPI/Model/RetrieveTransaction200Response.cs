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
    /// RetrieveTransaction200Response
    /// </summary>
    [DataContract(Name = "retrieveTransaction_200_response")]
    public partial class RetrieveTransaction200Response : IEquatable<RetrieveTransaction200Response>, IValidatableObject
    {
        /// <summary>
        /// The type of the transaction
        /// </summary>
        /// <value>The type of the transaction</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TransactionTypeEnum
        {
            /// <summary>
            /// Enum Payment for value: Payment
            /// </summary>
            [EnumMember(Value = "Payment")]
            Payment = 1,

            /// <summary>
            /// Enum Deferred for value: Deferred
            /// </summary>
            [EnumMember(Value = "Deferred")]
            Deferred = 2,

            /// <summary>
            /// Enum Repeat for value: Repeat
            /// </summary>
            [EnumMember(Value = "Repeat")]
            Repeat = 3,

            /// <summary>
            /// Enum Refund for value: Refund
            /// </summary>
            [EnumMember(Value = "Refund")]
            Refund = 4

        }


        /// <summary>
        /// The type of the transaction
        /// </summary>
        /// <value>The type of the transaction</value>
        [DataMember(Name = "transactionType", EmitDefaultValue = false)]
        public TransactionTypeEnum? TransactionType { get; set; }
        /// <summary>
        /// Result of transaction registration.  * &#x60;Ok Transaction&#x60; - request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Sage Pay. 
        /// </summary>
        /// <value>Result of transaction registration.  * &#x60;Ok Transaction&#x60; - request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Sage Pay. </value>
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
        /// Result of transaction registration.  * &#x60;Ok Transaction&#x60; - request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Sage Pay. 
        /// </summary>
        /// <value>Result of transaction registration.  * &#x60;Ok Transaction&#x60; - request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Sage Pay. </value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveTransaction200Response" /> class.
        /// </summary>
        /// <param name="transactionId">Opayo&#39;s unique reference for this transaction..</param>
        /// <param name="transactionType">The type of the transaction.</param>
        /// <param name="status">Result of transaction registration.  * &#x60;Ok Transaction&#x60; - request completed successfully.  * &#x60;NotAuthed&#x60; - Transaction request was not authorised by the bank.  * &#x60;Rejected&#x60; - Transaction rejected by your fraud rules.  * &#x60;Malformed&#x60; - Missing properties or badly formed body.  * &#x60;Invalid&#x60; - Invalid property values supplied.  * &#x60;Error&#x60; - An error occurred at Sage Pay. .</param>
        /// <param name="statusCode">Code related to the &#x60;status&#x60; of the transaction. *Successfully authorised transactions will have the &#x60;statusCode&#x60; of &#x60;0000&#x60;. You can lookup any other status code on our [website](https://www.sagepay.co.uk/support/error-codes).* .</param>
        /// <param name="statusDetail">A detailed reason for the &#x60;status&#x60; of the transaction..</param>
        /// <param name="retrievalReference">Opayo&#39;s unique Authorisation Code for a successfully authorised transaction. Only present if &#x60;status&#x60; is &#x60;Ok&#x60;..</param>
        /// <param name="bankResponseCode">Also known as the decline code, these are codes that are specific to your merchant bank. Please contact them for a description of each code. *This is only returned for transaction type &#x60;Payment&#x60;* .</param>
        /// <param name="bankAuthorisationCode">The authorisation code returned from your merchant bank..</param>
        /// <param name="amount">amount.</param>
        /// <param name="avsCvcCheck">avsCvcCheck.</param>
        /// <param name="currency">The currency of the &#x60;amount&#x60; in 3 letter [ISO 4217 format](http://en.wikipedia.org/wiki/ISO_4217). *This is only returned in GET requests*.</param>
        /// <param name="paymentMethod">paymentMethod.</param>
        /// <param name="_3dSecure">_3dSecure.</param>
        public RetrieveTransaction200Response(string transactionId = default, TransactionTypeEnum? transactionType = default, StatusEnum? status = default, string statusCode = default, string statusDetail = default, string retrievalReference = default, string bankResponseCode = default, string bankAuthorisationCode = default, Amount amount = default, AvsCvcCheck avsCvcCheck = default, string currency = default, RetrieveTransaction200ResponsePaymentMethod paymentMethod = default, Model3DSecure _3dSecure = default)
        {
            TransactionId = transactionId;
            TransactionType = transactionType;
            Status = status;
            StatusCode = statusCode;
            StatusDetail = statusDetail;
            RetrievalReference = retrievalReference;
            BankResponseCode = bankResponseCode;
            BankAuthorisationCode = bankAuthorisationCode;
            Amount = amount;
            AvsCvcCheck = avsCvcCheck;
            Currency = currency;
            PaymentMethod = paymentMethod;
            _3DSecure = _3dSecure;
        }

        /// <summary>
        /// Opayo&#39;s unique reference for this transaction.
        /// </summary>
        /// <value>Opayo&#39;s unique reference for this transaction.</value>
        [DataMember(Name = "transactionId", EmitDefaultValue = false)]
        public string TransactionId { get; set; }

        /// <summary>
        /// Code related to the &#x60;status&#x60; of the transaction. *Successfully authorised transactions will have the &#x60;statusCode&#x60; of &#x60;0000&#x60;. You can lookup any other status code on our [website](https://www.sagepay.co.uk/support/error-codes).* 
        /// </summary>
        /// <value>Code related to the &#x60;status&#x60; of the transaction. *Successfully authorised transactions will have the &#x60;statusCode&#x60; of &#x60;0000&#x60;. You can lookup any other status code on our [website](https://www.sagepay.co.uk/support/error-codes).* </value>
        [DataMember(Name = "statusCode", EmitDefaultValue = false)]
        public string StatusCode { get; set; }

        /// <summary>
        /// A detailed reason for the &#x60;status&#x60; of the transaction.
        /// </summary>
        /// <value>A detailed reason for the &#x60;status&#x60; of the transaction.</value>
        [DataMember(Name = "statusDetail", EmitDefaultValue = false)]
        public string StatusDetail { get; set; }

        /// <summary>
        /// Opayo&#39;s unique Authorisation Code for a successfully authorised transaction. Only present if &#x60;status&#x60; is &#x60;Ok&#x60;.
        /// </summary>
        /// <value>Opayo&#39;s unique Authorisation Code for a successfully authorised transaction. Only present if &#x60;status&#x60; is &#x60;Ok&#x60;.</value>
        [DataMember(Name = "retrievalReference", EmitDefaultValue = false)]
        public string RetrievalReference { get; set; }

        /// <summary>
        /// Also known as the decline code, these are codes that are specific to your merchant bank. Please contact them for a description of each code. *This is only returned for transaction type &#x60;Payment&#x60;* 
        /// </summary>
        /// <value>Also known as the decline code, these are codes that are specific to your merchant bank. Please contact them for a description of each code. *This is only returned for transaction type &#x60;Payment&#x60;* </value>
        [DataMember(Name = "bankResponseCode", EmitDefaultValue = false)]
        public string BankResponseCode { get; set; }

        /// <summary>
        /// The authorisation code returned from your merchant bank.
        /// </summary>
        /// <value>The authorisation code returned from your merchant bank.</value>
        [DataMember(Name = "bankAuthorisationCode", EmitDefaultValue = false)]
        public string BankAuthorisationCode { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public Amount Amount { get; set; }

        /// <summary>
        /// Gets or Sets AvsCvcCheck
        /// </summary>
        [DataMember(Name = "avsCvcCheck", EmitDefaultValue = false)]
        public AvsCvcCheck AvsCvcCheck { get; set; }

        /// <summary>
        /// The currency of the &#x60;amount&#x60; in 3 letter [ISO 4217 format](http://en.wikipedia.org/wiki/ISO_4217). *This is only returned in GET requests*
        /// </summary>
        /// <value>The currency of the &#x60;amount&#x60; in 3 letter [ISO 4217 format](http://en.wikipedia.org/wiki/ISO_4217). *This is only returned in GET requests*</value>
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or Sets PaymentMethod
        /// </summary>
        [DataMember(Name = "paymentMethod", EmitDefaultValue = false)]
        public RetrieveTransaction200ResponsePaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Gets or Sets _3DSecure
        /// </summary>
        [DataMember(Name = "3DSecure", EmitDefaultValue = false)]
        public Model3DSecure _3DSecure { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RetrieveTransaction200Response {\n");
            sb.Append("  TransactionId: ").Append(TransactionId).Append("\n");
            sb.Append("  TransactionType: ").Append(TransactionType).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  StatusCode: ").Append(StatusCode).Append("\n");
            sb.Append("  StatusDetail: ").Append(StatusDetail).Append("\n");
            sb.Append("  RetrievalReference: ").Append(RetrievalReference).Append("\n");
            sb.Append("  BankResponseCode: ").Append(BankResponseCode).Append("\n");
            sb.Append("  BankAuthorisationCode: ").Append(BankAuthorisationCode).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  AvsCvcCheck: ").Append(AvsCvcCheck).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  PaymentMethod: ").Append(PaymentMethod).Append("\n");
            sb.Append("  _3DSecure: ").Append(_3DSecure).Append("\n");
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
            return Equals(input as RetrieveTransaction200Response);
        }

        /// <summary>
        /// Returns true if RetrieveTransaction200Response instances are equal
        /// </summary>
        /// <param name="input">Instance of RetrieveTransaction200Response to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RetrieveTransaction200Response input)
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
                    TransactionType == input.TransactionType ||
                    TransactionType.Equals(input.TransactionType)
                ) &&
                (
                    Status == input.Status ||
                    Status.Equals(input.Status)
                ) &&
                (
                    StatusCode == input.StatusCode ||
                    StatusCode != null &&
                    StatusCode.Equals(input.StatusCode)
                ) &&
                (
                    StatusDetail == input.StatusDetail ||
                    StatusDetail != null &&
                    StatusDetail.Equals(input.StatusDetail)
                ) &&
                (
                    RetrievalReference == input.RetrievalReference ||
                    RetrievalReference != null &&
                    RetrievalReference.Equals(input.RetrievalReference)
                ) &&
                (
                    BankResponseCode == input.BankResponseCode ||
                    BankResponseCode != null &&
                    BankResponseCode.Equals(input.BankResponseCode)
                ) &&
                (
                    BankAuthorisationCode == input.BankAuthorisationCode ||
                    BankAuthorisationCode != null &&
                    BankAuthorisationCode.Equals(input.BankAuthorisationCode)
                ) &&
                (
                    Amount == input.Amount ||
                    Amount != null &&
                    Amount.Equals(input.Amount)
                ) &&
                (
                    AvsCvcCheck == input.AvsCvcCheck ||
                    AvsCvcCheck != null &&
                    AvsCvcCheck.Equals(input.AvsCvcCheck)
                ) &&
                (
                    Currency == input.Currency ||
                    Currency != null &&
                    Currency.Equals(input.Currency)
                ) &&
                (
                    PaymentMethod == input.PaymentMethod ||
                    PaymentMethod != null &&
                    PaymentMethod.Equals(input.PaymentMethod)
                ) &&
                (
                    _3DSecure == input._3DSecure ||
                    _3DSecure != null &&
                    _3DSecure.Equals(input._3DSecure)
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
                hashCode = hashCode * 59 + TransactionType.GetHashCode();
                hashCode = hashCode * 59 + Status.GetHashCode();
                if (StatusCode != null)
                {
                    hashCode = hashCode * 59 + StatusCode.GetHashCode();
                }
                if (StatusDetail != null)
                {
                    hashCode = hashCode * 59 + StatusDetail.GetHashCode();
                }
                if (RetrievalReference != null)
                {
                    hashCode = hashCode * 59 + RetrievalReference.GetHashCode();
                }
                if (BankResponseCode != null)
                {
                    hashCode = hashCode * 59 + BankResponseCode.GetHashCode();
                }
                if (BankAuthorisationCode != null)
                {
                    hashCode = hashCode * 59 + BankAuthorisationCode.GetHashCode();
                }
                if (Amount != null)
                {
                    hashCode = hashCode * 59 + Amount.GetHashCode();
                }
                if (AvsCvcCheck != null)
                {
                    hashCode = hashCode * 59 + AvsCvcCheck.GetHashCode();
                }
                if (Currency != null)
                {
                    hashCode = hashCode * 59 + Currency.GetHashCode();
                }
                if (PaymentMethod != null)
                {
                    hashCode = hashCode * 59 + PaymentMethod.GetHashCode();
                }
                if (_3DSecure != null)
                {
                    hashCode = hashCode * 59 + _3DSecure.GetHashCode();
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
            // Currency (string) maxLength
            if (Currency != null && Currency.Length > 3)
            {
                yield return new ValidationResult("Invalid value for Currency, length must be less than 3.", new[] { "Currency" });
            }

            // Currency (string) minLength
            if (Currency != null && Currency.Length < 3)
            {
                yield return new ValidationResult("Invalid value for Currency, length must be greater than 3.", new[] { "Currency" });
            }

            yield break;
        }
    }

}
