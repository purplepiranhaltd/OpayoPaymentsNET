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
    /// The &#x60;shippingDetails&#x60; object is used to specify the shipping address details for a transaction. If not provided the values provided in the &#x60;billingAddress&#x60; object will be used for shipping information instead.
    /// </summary>
    [DataContract(Name = "Paypal_shippingDetails")]
    public partial class PaypalShippingDetails : IEquatable<PaypalShippingDetails>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaypalShippingDetails" /> class.
        /// </summary>
        /// <param name="recipientFirstName">Recipient&#39;s first names..</param>
        /// <param name="recipientLastName">Recipient&#39;s last name..</param>
        /// <param name="shippingAddress1">Shipping address line 1..</param>
        /// <param name="shippingAddress2">Shipping address line 2..</param>
        /// <param name="shippingAddress3">Shipping address line 3..</param>
        /// <param name="shippingCity">Shipping city..</param>
        /// <param name="shippingPostalCode">Shipping postal code. Not required when &#x60;shippingCountry&#x60; is &#x60;IE&#x60;..</param>
        /// <param name="shippingCountry">Shipping country. Two letter country code defined in [ISO 3166-1](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2).</param>
        /// <param name="shippingState">Two letter state code defined in [ISO 3166-2](http://en.wikipedia.org/wiki/ISO_3166-2:US). Required when &#x60;shippingCountry&#x60; is &#x60;US&#x60;..</param>
        public PaypalShippingDetails(string recipientFirstName = default, string recipientLastName = default, string shippingAddress1 = default, string shippingAddress2 = default, string shippingAddress3 = default, string shippingCity = default, string shippingPostalCode = default, string shippingCountry = default, string shippingState = default)
        {
            RecipientFirstName = recipientFirstName;
            RecipientLastName = recipientLastName;
            ShippingAddress1 = shippingAddress1;
            ShippingAddress2 = shippingAddress2;
            ShippingAddress3 = shippingAddress3;
            ShippingCity = shippingCity;
            ShippingPostalCode = shippingPostalCode;
            ShippingCountry = shippingCountry;
            ShippingState = shippingState;
        }

        /// <summary>
        /// Recipient&#39;s first names.
        /// </summary>
        /// <value>Recipient&#39;s first names.</value>
        [DataMember(Name = "recipientFirstName", EmitDefaultValue = false)]
        public string RecipientFirstName { get; set; }

        /// <summary>
        /// Recipient&#39;s last name.
        /// </summary>
        /// <value>Recipient&#39;s last name.</value>
        [DataMember(Name = "recipientLastName", EmitDefaultValue = false)]
        public string RecipientLastName { get; set; }

        /// <summary>
        /// Shipping address line 1.
        /// </summary>
        /// <value>Shipping address line 1.</value>
        [DataMember(Name = "shippingAddress1", EmitDefaultValue = false)]
        public string ShippingAddress1 { get; set; }

        /// <summary>
        /// Shipping address line 2.
        /// </summary>
        /// <value>Shipping address line 2.</value>
        [DataMember(Name = "shippingAddress2", EmitDefaultValue = false)]
        public string ShippingAddress2 { get; set; }

        /// <summary>
        /// Shipping address line 3.
        /// </summary>
        /// <value>Shipping address line 3.</value>
        [DataMember(Name = "shippingAddress3", EmitDefaultValue = false)]
        public string ShippingAddress3 { get; set; }

        /// <summary>
        /// Shipping city.
        /// </summary>
        /// <value>Shipping city.</value>
        [DataMember(Name = "shippingCity", EmitDefaultValue = false)]
        public string ShippingCity { get; set; }

        /// <summary>
        /// Shipping postal code. Not required when &#x60;shippingCountry&#x60; is &#x60;IE&#x60;.
        /// </summary>
        /// <value>Shipping postal code. Not required when &#x60;shippingCountry&#x60; is &#x60;IE&#x60;.</value>
        [DataMember(Name = "shippingPostalCode", EmitDefaultValue = false)]
        public string ShippingPostalCode { get; set; }

        /// <summary>
        /// Shipping country. Two letter country code defined in [ISO 3166-1](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
        /// </summary>
        /// <value>Shipping country. Two letter country code defined in [ISO 3166-1](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)</value>
        [DataMember(Name = "shippingCountry", EmitDefaultValue = false)]
        public string ShippingCountry { get; set; }

        /// <summary>
        /// Two letter state code defined in [ISO 3166-2](http://en.wikipedia.org/wiki/ISO_3166-2:US). Required when &#x60;shippingCountry&#x60; is &#x60;US&#x60;.
        /// </summary>
        /// <value>Two letter state code defined in [ISO 3166-2](http://en.wikipedia.org/wiki/ISO_3166-2:US). Required when &#x60;shippingCountry&#x60; is &#x60;US&#x60;.</value>
        [DataMember(Name = "shippingState", EmitDefaultValue = false)]
        public string ShippingState { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PaypalShippingDetails {\n");
            sb.Append("  RecipientFirstName: ").Append(RecipientFirstName).Append("\n");
            sb.Append("  RecipientLastName: ").Append(RecipientLastName).Append("\n");
            sb.Append("  ShippingAddress1: ").Append(ShippingAddress1).Append("\n");
            sb.Append("  ShippingAddress2: ").Append(ShippingAddress2).Append("\n");
            sb.Append("  ShippingAddress3: ").Append(ShippingAddress3).Append("\n");
            sb.Append("  ShippingCity: ").Append(ShippingCity).Append("\n");
            sb.Append("  ShippingPostalCode: ").Append(ShippingPostalCode).Append("\n");
            sb.Append("  ShippingCountry: ").Append(ShippingCountry).Append("\n");
            sb.Append("  ShippingState: ").Append(ShippingState).Append("\n");
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
            return Equals(input as PaypalShippingDetails);
        }

        /// <summary>
        /// Returns true if PaypalShippingDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of PaypalShippingDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PaypalShippingDetails input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    RecipientFirstName == input.RecipientFirstName ||
                    RecipientFirstName != null &&
                    RecipientFirstName.Equals(input.RecipientFirstName)
                ) &&
                (
                    RecipientLastName == input.RecipientLastName ||
                    RecipientLastName != null &&
                    RecipientLastName.Equals(input.RecipientLastName)
                ) &&
                (
                    ShippingAddress1 == input.ShippingAddress1 ||
                    ShippingAddress1 != null &&
                    ShippingAddress1.Equals(input.ShippingAddress1)
                ) &&
                (
                    ShippingAddress2 == input.ShippingAddress2 ||
                    ShippingAddress2 != null &&
                    ShippingAddress2.Equals(input.ShippingAddress2)
                ) &&
                (
                    ShippingAddress3 == input.ShippingAddress3 ||
                    ShippingAddress3 != null &&
                    ShippingAddress3.Equals(input.ShippingAddress3)
                ) &&
                (
                    ShippingCity == input.ShippingCity ||
                    ShippingCity != null &&
                    ShippingCity.Equals(input.ShippingCity)
                ) &&
                (
                    ShippingPostalCode == input.ShippingPostalCode ||
                    ShippingPostalCode != null &&
                    ShippingPostalCode.Equals(input.ShippingPostalCode)
                ) &&
                (
                    ShippingCountry == input.ShippingCountry ||
                    ShippingCountry != null &&
                    ShippingCountry.Equals(input.ShippingCountry)
                ) &&
                (
                    ShippingState == input.ShippingState ||
                    ShippingState != null &&
                    ShippingState.Equals(input.ShippingState)
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
                if (RecipientFirstName != null)
                {
                    hashCode = hashCode * 59 + RecipientFirstName.GetHashCode();
                }
                if (RecipientLastName != null)
                {
                    hashCode = hashCode * 59 + RecipientLastName.GetHashCode();
                }
                if (ShippingAddress1 != null)
                {
                    hashCode = hashCode * 59 + ShippingAddress1.GetHashCode();
                }
                if (ShippingAddress2 != null)
                {
                    hashCode = hashCode * 59 + ShippingAddress2.GetHashCode();
                }
                if (ShippingAddress3 != null)
                {
                    hashCode = hashCode * 59 + ShippingAddress3.GetHashCode();
                }
                if (ShippingCity != null)
                {
                    hashCode = hashCode * 59 + ShippingCity.GetHashCode();
                }
                if (ShippingPostalCode != null)
                {
                    hashCode = hashCode * 59 + ShippingPostalCode.GetHashCode();
                }
                if (ShippingCountry != null)
                {
                    hashCode = hashCode * 59 + ShippingCountry.GetHashCode();
                }
                if (ShippingState != null)
                {
                    hashCode = hashCode * 59 + ShippingState.GetHashCode();
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
            // RecipientFirstName (string) maxLength
            if (RecipientFirstName != null && RecipientFirstName.Length > 20)
            {
                yield return new ValidationResult("Invalid value for RecipientFirstName, length must be less than 20.", new[] { "RecipientFirstName" });
            }

            // RecipientLastName (string) maxLength
            if (RecipientLastName != null && RecipientLastName.Length > 20)
            {
                yield return new ValidationResult("Invalid value for RecipientLastName, length must be less than 20.", new[] { "RecipientLastName" });
            }

            // ShippingAddress1 (string) maxLength
            if (ShippingAddress1 != null && ShippingAddress1.Length > 50)
            {
                yield return new ValidationResult("Invalid value for ShippingAddress1, length must be less than 50.", new[] { "ShippingAddress1" });
            }

            // ShippingAddress2 (string) maxLength
            if (ShippingAddress2 != null && ShippingAddress2.Length > 50)
            {
                yield return new ValidationResult("Invalid value for ShippingAddress2, length must be less than 50.", new[] { "ShippingAddress2" });
            }

            // ShippingAddress3 (string) maxLength
            if (ShippingAddress3 != null && ShippingAddress3.Length > 50)
            {
                yield return new ValidationResult("Invalid value for ShippingAddress3, length must be less than 50.", new[] { "ShippingAddress3" });
            }

            // ShippingCity (string) maxLength
            if (ShippingCity != null && ShippingCity.Length > 40)
            {
                yield return new ValidationResult("Invalid value for ShippingCity, length must be less than 40.", new[] { "ShippingCity" });
            }

            // ShippingPostalCode (string) maxLength
            if (ShippingPostalCode != null && ShippingPostalCode.Length > 10)
            {
                yield return new ValidationResult("Invalid value for ShippingPostalCode, length must be less than 10.", new[] { "ShippingPostalCode" });
            }

            // ShippingCountry (string) maxLength
            if (ShippingCountry != null && ShippingCountry.Length > 2)
            {
                yield return new ValidationResult("Invalid value for ShippingCountry, length must be less than 2.", new[] { "ShippingCountry" });
            }

            // ShippingCountry (string) minLength
            if (ShippingCountry != null && ShippingCountry.Length < 2)
            {
                yield return new ValidationResult("Invalid value for ShippingCountry, length must be greater than 2.", new[] { "ShippingCountry" });
            }

            // ShippingState (string) maxLength
            if (ShippingState != null && ShippingState.Length > 2)
            {
                yield return new ValidationResult("Invalid value for ShippingState, length must be less than 2.", new[] { "ShippingState" });
            }

            // ShippingState (string) minLength
            if (ShippingState != null && ShippingState.Length < 2)
            {
                yield return new ValidationResult("Invalid value for ShippingState, length must be greater than 2.", new[] { "ShippingState" });
            }

            yield break;
        }
    }

}
