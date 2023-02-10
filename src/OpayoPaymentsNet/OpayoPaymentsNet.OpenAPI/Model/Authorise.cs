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
    /// Authorise
    /// </summary>
    [DataContract(Name = "Authorise")]
    public partial class Authorise : IEquatable<Authorise>, IValidatableObject
    {
        /// <summary>
        /// The type of the transaction
        /// </summary>
        /// <value>The type of the transaction</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TransactionTypeEnum
        {
            /// <summary>
            /// Enum Authorise for value: Authorise
            /// </summary>
            [EnumMember(Value = "Authorise")]
            Authorise = 1

        }


        /// <summary>
        /// The type of the transaction
        /// </summary>
        /// <value>The type of the transaction</value>
        [DataMember(Name = "transactionType", EmitDefaultValue = false)]
        public TransactionTypeEnum? TransactionType { get; set; }
        /// <summary>
        /// Use this field to override your default account level AVS CVC settings.  * &#x60;UseMSPSetting&#x60; - Use default MySagePay settings.  * &#x60;Force&#x60; - Apply authentication even if turned off.  * &#x60;Disable&#x60; - Disable authentication and rules.  * &#x60;ForceIgnoringRules&#x60; - Apply authentication but ignore rules. 
        /// </summary>
        /// <value>Use this field to override your default account level AVS CVC settings.  * &#x60;UseMSPSetting&#x60; - Use default MySagePay settings.  * &#x60;Force&#x60; - Apply authentication even if turned off.  * &#x60;Disable&#x60; - Disable authentication and rules.  * &#x60;ForceIgnoringRules&#x60; - Apply authentication but ignore rules. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ApplyAvsCvcCheckEnum
        {
            /// <summary>
            /// Enum UseMSPSetting for value: UseMSPSetting
            /// </summary>
            [EnumMember(Value = "UseMSPSetting")]
            UseMSPSetting = 1,

            /// <summary>
            /// Enum Force for value: Force
            /// </summary>
            [EnumMember(Value = "Force")]
            Force = 2,

            /// <summary>
            /// Enum Disable for value: Disable
            /// </summary>
            [EnumMember(Value = "Disable")]
            Disable = 3,

            /// <summary>
            /// Enum ForceIgnoringRules for value: ForceIgnoringRules
            /// </summary>
            [EnumMember(Value = "ForceIgnoringRules")]
            ForceIgnoringRules = 4

        }


        /// <summary>
        /// Use this field to override your default account level AVS CVC settings.  * &#x60;UseMSPSetting&#x60; - Use default MySagePay settings.  * &#x60;Force&#x60; - Apply authentication even if turned off.  * &#x60;Disable&#x60; - Disable authentication and rules.  * &#x60;ForceIgnoringRules&#x60; - Apply authentication but ignore rules. 
        /// </summary>
        /// <value>Use this field to override your default account level AVS CVC settings.  * &#x60;UseMSPSetting&#x60; - Use default MySagePay settings.  * &#x60;Force&#x60; - Apply authentication even if turned off.  * &#x60;Disable&#x60; - Disable authentication and rules.  * &#x60;ForceIgnoringRules&#x60; - Apply authentication but ignore rules. </value>
        [DataMember(Name = "applyAvsCvcCheck", EmitDefaultValue = false)]
        public ApplyAvsCvcCheckEnum? ApplyAvsCvcCheck { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Authorise" /> class.
        /// </summary>
        /// <param name="transactionType">The type of the transaction.</param>
        /// <param name="referenceTransactionId">The &#x60;transactionId&#x60; of the referenced transaction..</param>
        /// <param name="vendorTxCode">Your unique reference for this transaction..</param>
        /// <param name="amount">The amount charged to the customer in the smallest currency unit. (e.g 100 pence to charge £1.00, or 1 to charge ¥1 (0-decimal currency)..</param>
        /// <param name="description">A brief description of the goods or services purchased..</param>
        /// <param name="applyAvsCvcCheck">Use this field to override your default account level AVS CVC settings.  * &#x60;UseMSPSetting&#x60; - Use default MySagePay settings.  * &#x60;Force&#x60; - Apply authentication even if turned off.  * &#x60;Disable&#x60; - Disable authentication and rules.  * &#x60;ForceIgnoringRules&#x60; - Apply authentication but ignore rules. .</param>
        /// <param name="cv2">The card security code, also known as CV2, CVV, or CVC. This is used in CV2 checks..</param>
        public Authorise(TransactionTypeEnum? transactionType = default, string referenceTransactionId = default, string vendorTxCode = default, int amount = default, string description = default, ApplyAvsCvcCheckEnum? applyAvsCvcCheck = default, string cv2 = default)
        {
            TransactionType = transactionType;
            ReferenceTransactionId = referenceTransactionId;
            VendorTxCode = vendorTxCode;
            Amount = amount;
            Description = description;
            ApplyAvsCvcCheck = applyAvsCvcCheck;
            Cv2 = cv2;
        }

        /// <summary>
        /// The &#x60;transactionId&#x60; of the referenced transaction.
        /// </summary>
        /// <value>The &#x60;transactionId&#x60; of the referenced transaction.</value>
        [DataMember(Name = "referenceTransactionId", EmitDefaultValue = false)]
        public string ReferenceTransactionId { get; set; }

        /// <summary>
        /// Your unique reference for this transaction.
        /// </summary>
        /// <value>Your unique reference for this transaction.</value>
        [DataMember(Name = "vendorTxCode", EmitDefaultValue = false)]
        public string VendorTxCode { get; set; }

        /// <summary>
        /// The amount charged to the customer in the smallest currency unit. (e.g 100 pence to charge £1.00, or 1 to charge ¥1 (0-decimal currency).
        /// </summary>
        /// <value>The amount charged to the customer in the smallest currency unit. (e.g 100 pence to charge £1.00, or 1 to charge ¥1 (0-decimal currency).</value>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public int Amount { get; set; }

        /// <summary>
        /// A brief description of the goods or services purchased.
        /// </summary>
        /// <value>A brief description of the goods or services purchased.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The card security code, also known as CV2, CVV, or CVC. This is used in CV2 checks.
        /// </summary>
        /// <value>The card security code, also known as CV2, CVV, or CVC. This is used in CV2 checks.</value>
        [DataMember(Name = "cv2", EmitDefaultValue = false)]
        public string Cv2 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Authorise {\n");
            sb.Append("  TransactionType: ").Append(TransactionType).Append("\n");
            sb.Append("  ReferenceTransactionId: ").Append(ReferenceTransactionId).Append("\n");
            sb.Append("  VendorTxCode: ").Append(VendorTxCode).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ApplyAvsCvcCheck: ").Append(ApplyAvsCvcCheck).Append("\n");
            sb.Append("  Cv2: ").Append(Cv2).Append("\n");
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
            return Equals(input as Authorise);
        }

        /// <summary>
        /// Returns true if Authorise instances are equal
        /// </summary>
        /// <param name="input">Instance of Authorise to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Authorise input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    TransactionType == input.TransactionType ||
                    TransactionType.Equals(input.TransactionType)
                ) &&
                (
                    ReferenceTransactionId == input.ReferenceTransactionId ||
                    ReferenceTransactionId != null &&
                    ReferenceTransactionId.Equals(input.ReferenceTransactionId)
                ) &&
                (
                    VendorTxCode == input.VendorTxCode ||
                    VendorTxCode != null &&
                    VendorTxCode.Equals(input.VendorTxCode)
                ) &&
                (
                    Amount == input.Amount ||
                    Amount.Equals(input.Amount)
                ) &&
                (
                    Description == input.Description ||
                    Description != null &&
                    Description.Equals(input.Description)
                ) &&
                (
                    ApplyAvsCvcCheck == input.ApplyAvsCvcCheck ||
                    ApplyAvsCvcCheck.Equals(input.ApplyAvsCvcCheck)
                ) &&
                (
                    Cv2 == input.Cv2 ||
                    Cv2 != null &&
                    Cv2.Equals(input.Cv2)
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
                hashCode = hashCode * 59 + TransactionType.GetHashCode();
                if (ReferenceTransactionId != null)
                {
                    hashCode = hashCode * 59 + ReferenceTransactionId.GetHashCode();
                }
                if (VendorTxCode != null)
                {
                    hashCode = hashCode * 59 + VendorTxCode.GetHashCode();
                }
                hashCode = hashCode * 59 + Amount.GetHashCode();
                if (Description != null)
                {
                    hashCode = hashCode * 59 + Description.GetHashCode();
                }
                hashCode = hashCode * 59 + ApplyAvsCvcCheck.GetHashCode();
                if (Cv2 != null)
                {
                    hashCode = hashCode * 59 + Cv2.GetHashCode();
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
            // VendorTxCode (string) maxLength
            if (VendorTxCode != null && VendorTxCode.Length > 40)
            {
                yield return new ValidationResult("Invalid value for VendorTxCode, length must be less than 40.", new[] { "VendorTxCode" });
            }

            // Description (string) maxLength
            if (Description != null && Description.Length > 100)
            {
                yield return new ValidationResult("Invalid value for Description, length must be less than 100.", new[] { "Description" });
            }

            // Cv2 (string) maxLength
            if (Cv2 != null && Cv2.Length > 4)
            {
                yield return new ValidationResult("Invalid value for Cv2, length must be less than 4.", new[] { "Cv2" });
            }

            // Cv2 (string) minLength
            if (Cv2 != null && Cv2.Length < 3)
            {
                yield return new ValidationResult("Invalid value for Cv2, length must be greater than 3.", new[] { "Cv2" });
            }

            yield break;
        }
    }

}