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
    /// Additional information about the Cardholder&#39;s account that has been provided by you. E.g. How long has the cardholder had the account on your website.
    /// </summary>
    [DataContract(Name = "strongCustomerAuthentication_acctInfo")]
    public partial class StrongCustomerAuthenticationAcctInfo : IEquatable<StrongCustomerAuthenticationAcctInfo>, IValidatableObject
    {
        /// <summary>
        /// Length of time that the cardholder has had their online account with you.    * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;CreatedDuringTransaction&#x60; &#x3D; Created during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days 
        /// </summary>
        /// <value>Length of time that the cardholder has had their online account with you.    * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;CreatedDuringTransaction&#x60; &#x3D; Created during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChAccAgeIndEnum
        {
            /// <summary>
            /// Enum GuestCheckout for value: GuestCheckout
            /// </summary>
            [EnumMember(Value = "GuestCheckout")]
            GuestCheckout = 1,

            /// <summary>
            /// Enum CreatedDuringTransaction for value: CreatedDuringTransaction
            /// </summary>
            [EnumMember(Value = "CreatedDuringTransaction")]
            CreatedDuringTransaction = 2,

            /// <summary>
            /// Enum LessThanThirtyDays for value: LessThanThirtyDays
            /// </summary>
            [EnumMember(Value = "LessThanThirtyDays")]
            LessThanThirtyDays = 3,

            /// <summary>
            /// Enum ThirtyToSixtyDays for value: ThirtyToSixtyDays
            /// </summary>
            [EnumMember(Value = "ThirtyToSixtyDays")]
            ThirtyToSixtyDays = 4,

            /// <summary>
            /// Enum MoreThanSixtyDays for value: MoreThanSixtyDays
            /// </summary>
            [EnumMember(Value = "MoreThanSixtyDays")]
            MoreThanSixtyDays = 5

        }


        /// <summary>
        /// Length of time that the cardholder has had their online account with you.    * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;CreatedDuringTransaction&#x60; &#x3D; Created during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days 
        /// </summary>
        /// <value>Length of time that the cardholder has had their online account with you.    * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;CreatedDuringTransaction&#x60; &#x3D; Created during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days </value>
        [DataMember(Name = "chAccAgeInd", EmitDefaultValue = false)]
        public ChAccAgeIndEnum? ChAccAgeInd { get; set; }
        /// <summary>
        /// Length of time since the cardholder&#39;s online account information last changed, including Billing or Shipping address, new payment account, or new user(s) added.   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days 
        /// </summary>
        /// <value>Length of time since the cardholder&#39;s online account information last changed, including Billing or Shipping address, new payment account, or new user(s) added.   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChAccChangeIndEnum
        {
            /// <summary>
            /// Enum DuringTransaction for value: DuringTransaction
            /// </summary>
            [EnumMember(Value = "DuringTransaction")]
            DuringTransaction = 1,

            /// <summary>
            /// Enum LessThanThirtyDays for value: LessThanThirtyDays
            /// </summary>
            [EnumMember(Value = "LessThanThirtyDays")]
            LessThanThirtyDays = 2,

            /// <summary>
            /// Enum ThirtyToSixtyDays for value: ThirtyToSixtyDays
            /// </summary>
            [EnumMember(Value = "ThirtyToSixtyDays")]
            ThirtyToSixtyDays = 3,

            /// <summary>
            /// Enum MoreThanSixtyDays for value: MoreThanSixtyDays
            /// </summary>
            [EnumMember(Value = "MoreThanSixtyDays")]
            MoreThanSixtyDays = 4

        }


        /// <summary>
        /// Length of time since the cardholder&#39;s online account information last changed, including Billing or Shipping address, new payment account, or new user(s) added.   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days 
        /// </summary>
        /// <value>Length of time since the cardholder&#39;s online account information last changed, including Billing or Shipping address, new payment account, or new user(s) added.   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days </value>
        [DataMember(Name = "chAccChangeInd", EmitDefaultValue = false)]
        public ChAccChangeIndEnum? ChAccChangeInd { get; set; }
        /// <summary>
        /// Indicates the length of time since the cardholder&#39;s online account had a password change or account reset.   * &#x60;NoChange&#x60; &#x3D; No change   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days 
        /// </summary>
        /// <value>Indicates the length of time since the cardholder&#39;s online account had a password change or account reset.   * &#x60;NoChange&#x60; &#x3D; No change   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChAccPwChangeIndEnum
        {
            /// <summary>
            /// Enum NoChange for value: NoChange
            /// </summary>
            [EnumMember(Value = "NoChange")]
            NoChange = 1,

            /// <summary>
            /// Enum DuringTransaction for value: DuringTransaction
            /// </summary>
            [EnumMember(Value = "DuringTransaction")]
            DuringTransaction = 2,

            /// <summary>
            /// Enum LessThanThirtyDays for value: LessThanThirtyDays
            /// </summary>
            [EnumMember(Value = "LessThanThirtyDays")]
            LessThanThirtyDays = 3,

            /// <summary>
            /// Enum ThirtyToSixtyDays for value: ThirtyToSixtyDays
            /// </summary>
            [EnumMember(Value = "ThirtyToSixtyDays")]
            ThirtyToSixtyDays = 4,

            /// <summary>
            /// Enum MoreThanSixtyDays for value: MoreThanSixtyDays
            /// </summary>
            [EnumMember(Value = "MoreThanSixtyDays")]
            MoreThanSixtyDays = 5

        }


        /// <summary>
        /// Indicates the length of time since the cardholder&#39;s online account had a password change or account reset.   * &#x60;NoChange&#x60; &#x3D; No change   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days 
        /// </summary>
        /// <value>Indicates the length of time since the cardholder&#39;s online account had a password change or account reset.   * &#x60;NoChange&#x60; &#x3D; No change   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days </value>
        [DataMember(Name = "chAccPwChangeInd", EmitDefaultValue = false)]
        public ChAccPwChangeIndEnum? ChAccPwChangeInd { get; set; }
        /// <summary>
        /// Indicates the length of time that the payment account was enrolled in the cardholder&#39;s account with you.   * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;DuringTransaction&#x60; &#x3D; During this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 day 
        /// </summary>
        /// <value>Indicates the length of time that the payment account was enrolled in the cardholder&#39;s account with you.   * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;DuringTransaction&#x60; &#x3D; During this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 day </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PaymentAccIndEnum
        {
            /// <summary>
            /// Enum GuestCheckout for value: GuestCheckout
            /// </summary>
            [EnumMember(Value = "GuestCheckout")]
            GuestCheckout = 1,

            /// <summary>
            /// Enum DuringTransaction for value: DuringTransaction
            /// </summary>
            [EnumMember(Value = "DuringTransaction")]
            DuringTransaction = 2,

            /// <summary>
            /// Enum LessThanThirtyDays for value: LessThanThirtyDays
            /// </summary>
            [EnumMember(Value = "LessThanThirtyDays")]
            LessThanThirtyDays = 3,

            /// <summary>
            /// Enum ThirtyToSixtyDays for value: ThirtyToSixtyDays
            /// </summary>
            [EnumMember(Value = "ThirtyToSixtyDays")]
            ThirtyToSixtyDays = 4,

            /// <summary>
            /// Enum MoreThanSixtyDays for value: MoreThanSixtyDays
            /// </summary>
            [EnumMember(Value = "MoreThanSixtyDays")]
            MoreThanSixtyDays = 5

        }


        /// <summary>
        /// Indicates the length of time that the payment account was enrolled in the cardholder&#39;s account with you.   * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;DuringTransaction&#x60; &#x3D; During this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 day 
        /// </summary>
        /// <value>Indicates the length of time that the payment account was enrolled in the cardholder&#39;s account with you.   * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;DuringTransaction&#x60; &#x3D; During this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 day </value>
        [DataMember(Name = "paymentAccInd", EmitDefaultValue = false)]
        public PaymentAccIndEnum? PaymentAccInd { get; set; }
        /// <summary>
        /// Indicates when the shipping address used for this transaction was first used with you.   * &#x60;ThisTransaction&#x60; &#x3D; This transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days 
        /// </summary>
        /// <value>Indicates when the shipping address used for this transaction was first used with you.   * &#x60;ThisTransaction&#x60; &#x3D; This transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ShipAddressUsageIndEnum
        {
            /// <summary>
            /// Enum ThisTransaction for value: ThisTransaction
            /// </summary>
            [EnumMember(Value = "ThisTransaction")]
            ThisTransaction = 1,

            /// <summary>
            /// Enum LessThanThirtyDays for value: LessThanThirtyDays
            /// </summary>
            [EnumMember(Value = "LessThanThirtyDays")]
            LessThanThirtyDays = 2,

            /// <summary>
            /// Enum ThirtyToSixtyDays for value: ThirtyToSixtyDays
            /// </summary>
            [EnumMember(Value = "ThirtyToSixtyDays")]
            ThirtyToSixtyDays = 3,

            /// <summary>
            /// Enum MoreThanSixtyDays for value: MoreThanSixtyDays
            /// </summary>
            [EnumMember(Value = "MoreThanSixtyDays")]
            MoreThanSixtyDays = 4

        }


        /// <summary>
        /// Indicates when the shipping address used for this transaction was first used with you.   * &#x60;ThisTransaction&#x60; &#x3D; This transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days 
        /// </summary>
        /// <value>Indicates when the shipping address used for this transaction was first used with you.   * &#x60;ThisTransaction&#x60; &#x3D; This transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days </value>
        [DataMember(Name = "shipAddressUsageInd", EmitDefaultValue = false)]
        public ShipAddressUsageIndEnum? ShipAddressUsageInd { get; set; }
        /// <summary>
        /// Indicates if the Cardholder Name on the account is identical to the shipping Name used for this transaction.  * &#x60;FullMatch&#x60; &#x3D; Account Name identical to shipping Name  * &#x60;NoMatch&#x60; &#x3D; Account Name different than shipping Name 
        /// </summary>
        /// <value>Indicates if the Cardholder Name on the account is identical to the shipping Name used for this transaction.  * &#x60;FullMatch&#x60; &#x3D; Account Name identical to shipping Name  * &#x60;NoMatch&#x60; &#x3D; Account Name different than shipping Name </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ShipNameIndicatorEnum
        {
            /// <summary>
            /// Enum FullMatch for value: FullMatch
            /// </summary>
            [EnumMember(Value = "FullMatch")]
            FullMatch = 1,

            /// <summary>
            /// Enum NoMatch for value: NoMatch
            /// </summary>
            [EnumMember(Value = "NoMatch")]
            NoMatch = 2

        }


        /// <summary>
        /// Indicates if the Cardholder Name on the account is identical to the shipping Name used for this transaction.  * &#x60;FullMatch&#x60; &#x3D; Account Name identical to shipping Name  * &#x60;NoMatch&#x60; &#x3D; Account Name different than shipping Name 
        /// </summary>
        /// <value>Indicates if the Cardholder Name on the account is identical to the shipping Name used for this transaction.  * &#x60;FullMatch&#x60; &#x3D; Account Name identical to shipping Name  * &#x60;NoMatch&#x60; &#x3D; Account Name different than shipping Name </value>
        [DataMember(Name = "shipNameIndicator", EmitDefaultValue = false)]
        public ShipNameIndicatorEnum? ShipNameIndicator { get; set; }
        /// <summary>
        /// Indicates whether you have experienced suspicious activity (including previous fraud) on the cardholder account.  * &#x60;NotSuspicious&#x60; &#x3D; No suspicious activity has been observed  * &#x60;Suspicious&#x60; &#x3D; Suspicious activity has been observed 
        /// </summary>
        /// <value>Indicates whether you have experienced suspicious activity (including previous fraud) on the cardholder account.  * &#x60;NotSuspicious&#x60; &#x3D; No suspicious activity has been observed  * &#x60;Suspicious&#x60; &#x3D; Suspicious activity has been observed </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SuspiciousAccActivityEnum
        {
            /// <summary>
            /// Enum NotSuspicious for value: NotSuspicious
            /// </summary>
            [EnumMember(Value = "NotSuspicious")]
            NotSuspicious = 1,

            /// <summary>
            /// Enum Suspicious for value: Suspicious
            /// </summary>
            [EnumMember(Value = "Suspicious")]
            Suspicious = 2

        }


        /// <summary>
        /// Indicates whether you have experienced suspicious activity (including previous fraud) on the cardholder account.  * &#x60;NotSuspicious&#x60; &#x3D; No suspicious activity has been observed  * &#x60;Suspicious&#x60; &#x3D; Suspicious activity has been observed 
        /// </summary>
        /// <value>Indicates whether you have experienced suspicious activity (including previous fraud) on the cardholder account.  * &#x60;NotSuspicious&#x60; &#x3D; No suspicious activity has been observed  * &#x60;Suspicious&#x60; &#x3D; Suspicious activity has been observed </value>
        [DataMember(Name = "suspiciousAccActivity", EmitDefaultValue = false)]
        public SuspiciousAccActivityEnum? SuspiciousAccActivity { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StrongCustomerAuthenticationAcctInfo" /> class.
        /// </summary>
        /// <param name="chAccAgeInd">Length of time that the cardholder has had their online account with you.    * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;CreatedDuringTransaction&#x60; &#x3D; Created during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days .</param>
        /// <param name="chAccChange">Date that the cardholder&#39;s online account last changed, including Billing or Shipping address, new payment account, or new user(s) added..</param>
        /// <param name="chAccChangeInd">Length of time since the cardholder&#39;s online account information last changed, including Billing or Shipping address, new payment account, or new user(s) added.   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days .</param>
        /// <param name="chAccDate">Date that the cardholder opened their online account with you..</param>
        /// <param name="chAccPwChange">Date that cardholder&#39;s online account had a password change or account reset..</param>
        /// <param name="chAccPwChangeInd">Indicates the length of time since the cardholder&#39;s online account had a password change or account reset.   * &#x60;NoChange&#x60; &#x3D; No change   * &#x60;DuringTransaction&#x60; &#x3D; Changed during this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days .</param>
        /// <param name="nbPurchaseAccount">Number of purchases with this cardholder account during the previous six months..</param>
        /// <param name="provisionAttemptsDay">Number of Add Card attempts in the last 24 hours..</param>
        /// <param name="txnActivityDay">Number of transactions (successful and abandoned) for this cardholder account with you, across all payment accounts in the previous 24 hours..</param>
        /// <param name="txnActivityYear">Number of transactions (successful and abandoned) for this cardholder account with you, across all payment accounts in the previous year..</param>
        /// <param name="paymentAccAge">Date that the payment account was enrolled in the cardholder&#39;s account with you..</param>
        /// <param name="paymentAccInd">Indicates the length of time that the payment account was enrolled in the cardholder&#39;s account with you.   * &#x60;GuestCheckout&#x60; &#x3D; No account (guest check-out)   * &#x60;DuringTransaction&#x60; &#x3D; During this transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 day .</param>
        /// <param name="shipAddressUsage">Date when the shipping address used for this transaction was first used with you..</param>
        /// <param name="shipAddressUsageInd">Indicates when the shipping address used for this transaction was first used with you.   * &#x60;ThisTransaction&#x60; &#x3D; This transaction   * &#x60;LessThanThirtyDays&#x60; &#x3D; Less than 30 days   * &#x60;ThirtyToSixtyDays&#x60; &#x3D; 30-60 days   * &#x60;MoreThanSixtyDays&#x60; &#x3D; More than 60 days .</param>
        /// <param name="shipNameIndicator">Indicates if the Cardholder Name on the account is identical to the shipping Name used for this transaction.  * &#x60;FullMatch&#x60; &#x3D; Account Name identical to shipping Name  * &#x60;NoMatch&#x60; &#x3D; Account Name different than shipping Name .</param>
        /// <param name="suspiciousAccActivity">Indicates whether you have experienced suspicious activity (including previous fraud) on the cardholder account.  * &#x60;NotSuspicious&#x60; &#x3D; No suspicious activity has been observed  * &#x60;Suspicious&#x60; &#x3D; Suspicious activity has been observed .</param>
        public StrongCustomerAuthenticationAcctInfo(ChAccAgeIndEnum? chAccAgeInd = default, string chAccChange = default, ChAccChangeIndEnum? chAccChangeInd = default, string chAccDate = default, string chAccPwChange = default, ChAccPwChangeIndEnum? chAccPwChangeInd = default, string nbPurchaseAccount = default, string provisionAttemptsDay = default, string txnActivityDay = default, string txnActivityYear = default, string paymentAccAge = default, PaymentAccIndEnum? paymentAccInd = default, string shipAddressUsage = default, ShipAddressUsageIndEnum? shipAddressUsageInd = default, ShipNameIndicatorEnum? shipNameIndicator = default, SuspiciousAccActivityEnum? suspiciousAccActivity = default)
        {
            ChAccAgeInd = chAccAgeInd;
            ChAccChange = chAccChange;
            ChAccChangeInd = chAccChangeInd;
            ChAccDate = chAccDate;
            ChAccPwChange = chAccPwChange;
            ChAccPwChangeInd = chAccPwChangeInd;
            NbPurchaseAccount = nbPurchaseAccount;
            ProvisionAttemptsDay = provisionAttemptsDay;
            TxnActivityDay = txnActivityDay;
            TxnActivityYear = txnActivityYear;
            PaymentAccAge = paymentAccAge;
            PaymentAccInd = paymentAccInd;
            ShipAddressUsage = shipAddressUsage;
            ShipAddressUsageInd = shipAddressUsageInd;
            ShipNameIndicator = shipNameIndicator;
            SuspiciousAccActivity = suspiciousAccActivity;
        }

        /// <summary>
        /// Date that the cardholder&#39;s online account last changed, including Billing or Shipping address, new payment account, or new user(s) added.
        /// </summary>
        /// <value>Date that the cardholder&#39;s online account last changed, including Billing or Shipping address, new payment account, or new user(s) added.</value>
        [DataMember(Name = "chAccChange", EmitDefaultValue = false)]
        public string ChAccChange { get; set; }

        /// <summary>
        /// Date that the cardholder opened their online account with you.
        /// </summary>
        /// <value>Date that the cardholder opened their online account with you.</value>
        [DataMember(Name = "chAccDate", EmitDefaultValue = false)]
        public string ChAccDate { get; set; }

        /// <summary>
        /// Date that cardholder&#39;s online account had a password change or account reset.
        /// </summary>
        /// <value>Date that cardholder&#39;s online account had a password change or account reset.</value>
        [DataMember(Name = "chAccPwChange", EmitDefaultValue = false)]
        public string ChAccPwChange { get; set; }

        /// <summary>
        /// Number of purchases with this cardholder account during the previous six months.
        /// </summary>
        /// <value>Number of purchases with this cardholder account during the previous six months.</value>
        [DataMember(Name = "nbPurchaseAccount", EmitDefaultValue = false)]
        public string NbPurchaseAccount { get; set; }

        /// <summary>
        /// Number of Add Card attempts in the last 24 hours.
        /// </summary>
        /// <value>Number of Add Card attempts in the last 24 hours.</value>
        [DataMember(Name = "provisionAttemptsDay", EmitDefaultValue = false)]
        public string ProvisionAttemptsDay { get; set; }

        /// <summary>
        /// Number of transactions (successful and abandoned) for this cardholder account with you, across all payment accounts in the previous 24 hours.
        /// </summary>
        /// <value>Number of transactions (successful and abandoned) for this cardholder account with you, across all payment accounts in the previous 24 hours.</value>
        [DataMember(Name = "txnActivityDay", EmitDefaultValue = false)]
        public string TxnActivityDay { get; set; }

        /// <summary>
        /// Number of transactions (successful and abandoned) for this cardholder account with you, across all payment accounts in the previous year.
        /// </summary>
        /// <value>Number of transactions (successful and abandoned) for this cardholder account with you, across all payment accounts in the previous year.</value>
        [DataMember(Name = "txnActivityYear", EmitDefaultValue = false)]
        public string TxnActivityYear { get; set; }

        /// <summary>
        /// Date that the payment account was enrolled in the cardholder&#39;s account with you.
        /// </summary>
        /// <value>Date that the payment account was enrolled in the cardholder&#39;s account with you.</value>
        [DataMember(Name = "paymentAccAge", EmitDefaultValue = false)]
        public string PaymentAccAge { get; set; }

        /// <summary>
        /// Date when the shipping address used for this transaction was first used with you.
        /// </summary>
        /// <value>Date when the shipping address used for this transaction was first used with you.</value>
        [DataMember(Name = "shipAddressUsage", EmitDefaultValue = false)]
        public string ShipAddressUsage { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StrongCustomerAuthenticationAcctInfo {\n");
            sb.Append("  ChAccAgeInd: ").Append(ChAccAgeInd).Append("\n");
            sb.Append("  ChAccChange: ").Append(ChAccChange).Append("\n");
            sb.Append("  ChAccChangeInd: ").Append(ChAccChangeInd).Append("\n");
            sb.Append("  ChAccDate: ").Append(ChAccDate).Append("\n");
            sb.Append("  ChAccPwChange: ").Append(ChAccPwChange).Append("\n");
            sb.Append("  ChAccPwChangeInd: ").Append(ChAccPwChangeInd).Append("\n");
            sb.Append("  NbPurchaseAccount: ").Append(NbPurchaseAccount).Append("\n");
            sb.Append("  ProvisionAttemptsDay: ").Append(ProvisionAttemptsDay).Append("\n");
            sb.Append("  TxnActivityDay: ").Append(TxnActivityDay).Append("\n");
            sb.Append("  TxnActivityYear: ").Append(TxnActivityYear).Append("\n");
            sb.Append("  PaymentAccAge: ").Append(PaymentAccAge).Append("\n");
            sb.Append("  PaymentAccInd: ").Append(PaymentAccInd).Append("\n");
            sb.Append("  ShipAddressUsage: ").Append(ShipAddressUsage).Append("\n");
            sb.Append("  ShipAddressUsageInd: ").Append(ShipAddressUsageInd).Append("\n");
            sb.Append("  ShipNameIndicator: ").Append(ShipNameIndicator).Append("\n");
            sb.Append("  SuspiciousAccActivity: ").Append(SuspiciousAccActivity).Append("\n");
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
            return Equals(input as StrongCustomerAuthenticationAcctInfo);
        }

        /// <summary>
        /// Returns true if StrongCustomerAuthenticationAcctInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of StrongCustomerAuthenticationAcctInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StrongCustomerAuthenticationAcctInfo input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    ChAccAgeInd == input.ChAccAgeInd ||
                    ChAccAgeInd.Equals(input.ChAccAgeInd)
                ) &&
                (
                    ChAccChange == input.ChAccChange ||
                    ChAccChange != null &&
                    ChAccChange.Equals(input.ChAccChange)
                ) &&
                (
                    ChAccChangeInd == input.ChAccChangeInd ||
                    ChAccChangeInd.Equals(input.ChAccChangeInd)
                ) &&
                (
                    ChAccDate == input.ChAccDate ||
                    ChAccDate != null &&
                    ChAccDate.Equals(input.ChAccDate)
                ) &&
                (
                    ChAccPwChange == input.ChAccPwChange ||
                    ChAccPwChange != null &&
                    ChAccPwChange.Equals(input.ChAccPwChange)
                ) &&
                (
                    ChAccPwChangeInd == input.ChAccPwChangeInd ||
                    ChAccPwChangeInd.Equals(input.ChAccPwChangeInd)
                ) &&
                (
                    NbPurchaseAccount == input.NbPurchaseAccount ||
                    NbPurchaseAccount != null &&
                    NbPurchaseAccount.Equals(input.NbPurchaseAccount)
                ) &&
                (
                    ProvisionAttemptsDay == input.ProvisionAttemptsDay ||
                    ProvisionAttemptsDay != null &&
                    ProvisionAttemptsDay.Equals(input.ProvisionAttemptsDay)
                ) &&
                (
                    TxnActivityDay == input.TxnActivityDay ||
                    TxnActivityDay != null &&
                    TxnActivityDay.Equals(input.TxnActivityDay)
                ) &&
                (
                    TxnActivityYear == input.TxnActivityYear ||
                    TxnActivityYear != null &&
                    TxnActivityYear.Equals(input.TxnActivityYear)
                ) &&
                (
                    PaymentAccAge == input.PaymentAccAge ||
                    PaymentAccAge != null &&
                    PaymentAccAge.Equals(input.PaymentAccAge)
                ) &&
                (
                    PaymentAccInd == input.PaymentAccInd ||
                    PaymentAccInd.Equals(input.PaymentAccInd)
                ) &&
                (
                    ShipAddressUsage == input.ShipAddressUsage ||
                    ShipAddressUsage != null &&
                    ShipAddressUsage.Equals(input.ShipAddressUsage)
                ) &&
                (
                    ShipAddressUsageInd == input.ShipAddressUsageInd ||
                    ShipAddressUsageInd.Equals(input.ShipAddressUsageInd)
                ) &&
                (
                    ShipNameIndicator == input.ShipNameIndicator ||
                    ShipNameIndicator.Equals(input.ShipNameIndicator)
                ) &&
                (
                    SuspiciousAccActivity == input.SuspiciousAccActivity ||
                    SuspiciousAccActivity.Equals(input.SuspiciousAccActivity)
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
                hashCode = hashCode * 59 + ChAccAgeInd.GetHashCode();
                if (ChAccChange != null)
                {
                    hashCode = hashCode * 59 + ChAccChange.GetHashCode();
                }
                hashCode = hashCode * 59 + ChAccChangeInd.GetHashCode();
                if (ChAccDate != null)
                {
                    hashCode = hashCode * 59 + ChAccDate.GetHashCode();
                }
                if (ChAccPwChange != null)
                {
                    hashCode = hashCode * 59 + ChAccPwChange.GetHashCode();
                }
                hashCode = hashCode * 59 + ChAccPwChangeInd.GetHashCode();
                if (NbPurchaseAccount != null)
                {
                    hashCode = hashCode * 59 + NbPurchaseAccount.GetHashCode();
                }
                if (ProvisionAttemptsDay != null)
                {
                    hashCode = hashCode * 59 + ProvisionAttemptsDay.GetHashCode();
                }
                if (TxnActivityDay != null)
                {
                    hashCode = hashCode * 59 + TxnActivityDay.GetHashCode();
                }
                if (TxnActivityYear != null)
                {
                    hashCode = hashCode * 59 + TxnActivityYear.GetHashCode();
                }
                if (PaymentAccAge != null)
                {
                    hashCode = hashCode * 59 + PaymentAccAge.GetHashCode();
                }
                hashCode = hashCode * 59 + PaymentAccInd.GetHashCode();
                if (ShipAddressUsage != null)
                {
                    hashCode = hashCode * 59 + ShipAddressUsage.GetHashCode();
                }
                hashCode = hashCode * 59 + ShipAddressUsageInd.GetHashCode();
                hashCode = hashCode * 59 + ShipNameIndicator.GetHashCode();
                hashCode = hashCode * 59 + SuspiciousAccActivity.GetHashCode();
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
            // ChAccDate (string) maxLength
            if (ChAccDate != null && ChAccDate.Length > 8)
            {
                yield return new ValidationResult("Invalid value for ChAccDate, length must be less than 8.", new[] { "ChAccDate" });
            }

            // ChAccDate (string) minLength
            if (ChAccDate != null && ChAccDate.Length < 8)
            {
                yield return new ValidationResult("Invalid value for ChAccDate, length must be greater than 8.", new[] { "ChAccDate" });
            }

            // ChAccPwChange (string) maxLength
            if (ChAccPwChange != null && ChAccPwChange.Length > 8)
            {
                yield return new ValidationResult("Invalid value for ChAccPwChange, length must be less than 8.", new[] { "ChAccPwChange" });
            }

            // ChAccPwChange (string) minLength
            if (ChAccPwChange != null && ChAccPwChange.Length < 8)
            {
                yield return new ValidationResult("Invalid value for ChAccPwChange, length must be greater than 8.", new[] { "ChAccPwChange" });
            }

            // NbPurchaseAccount (string) maxLength
            if (NbPurchaseAccount != null && NbPurchaseAccount.Length > 4)
            {
                yield return new ValidationResult("Invalid value for NbPurchaseAccount, length must be less than 4.", new[] { "NbPurchaseAccount" });
            }

            // ProvisionAttemptsDay (string) maxLength
            if (ProvisionAttemptsDay != null && ProvisionAttemptsDay.Length > 3)
            {
                yield return new ValidationResult("Invalid value for ProvisionAttemptsDay, length must be less than 3.", new[] { "ProvisionAttemptsDay" });
            }

            // TxnActivityDay (string) maxLength
            if (TxnActivityDay != null && TxnActivityDay.Length > 3)
            {
                yield return new ValidationResult("Invalid value for TxnActivityDay, length must be less than 3.", new[] { "TxnActivityDay" });
            }

            // TxnActivityYear (string) maxLength
            if (TxnActivityYear != null && TxnActivityYear.Length > 3)
            {
                yield return new ValidationResult("Invalid value for TxnActivityYear, length must be less than 3.", new[] { "TxnActivityYear" });
            }

            // PaymentAccAge (string) maxLength
            if (PaymentAccAge != null && PaymentAccAge.Length > 8)
            {
                yield return new ValidationResult("Invalid value for PaymentAccAge, length must be less than 8.", new[] { "PaymentAccAge" });
            }

            // PaymentAccAge (string) minLength
            if (PaymentAccAge != null && PaymentAccAge.Length < 8)
            {
                yield return new ValidationResult("Invalid value for PaymentAccAge, length must be greater than 8.", new[] { "PaymentAccAge" });
            }

            // ShipAddressUsage (string) maxLength
            if (ShipAddressUsage != null && ShipAddressUsage.Length > 8)
            {
                yield return new ValidationResult("Invalid value for ShipAddressUsage, length must be less than 8.", new[] { "ShipAddressUsage" });
            }

            // ShipAddressUsage (string) minLength
            if (ShipAddressUsage != null && ShipAddressUsage.Length < 8)
            {
                yield return new ValidationResult("Invalid value for ShipAddressUsage, length must be greater than 8.", new[] { "ShipAddressUsage" });
            }

            yield break;
        }
    }

}
