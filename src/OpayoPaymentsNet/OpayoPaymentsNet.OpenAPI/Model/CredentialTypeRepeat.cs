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
    /// The &#x60;credentialType&#x60; object is required for Repeat transactions where &#x60;transactionType&#x60;:&#x60;Repeat&#x60;. It advises the card issuer the reason you are using a stored credential.
    /// </summary>
    [DataContract(Name = "credentialTypeRepeat")]
    public partial class CredentialTypeRepeat : IEquatable<CredentialTypeRepeat>, IValidatableObject
    {
        /// <summary>
        /// Required when you are repeating a previously stored credential.   * &#x60;Subsequent&#x60; &#x3D; You are using a stored credential 
        /// </summary>
        /// <value>Required when you are repeating a previously stored credential.   * &#x60;Subsequent&#x60; &#x3D; You are using a stored credential </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CofUsageEnum
        {
            /// <summary>
            /// Enum Subsequent for value: Subsequent
            /// </summary>
            [EnumMember(Value = "Subsequent")]
            Subsequent = 1

        }


        /// <summary>
        /// Required when you are repeating a previously stored credential.   * &#x60;Subsequent&#x60; &#x3D; You are using a stored credential 
        /// </summary>
        /// <value>Required when you are repeating a previously stored credential.   * &#x60;Subsequent&#x60; &#x3D; You are using a stored credential </value>
        [DataMember(Name = "cofUsage", IsRequired = true, EmitDefaultValue = true)]
        public CofUsageEnum CofUsage { get; set; }
        /// <summary>
        /// Indicates whether the cardholder is in-session (CIT), where they are on your website and they select the submit button to make a payment. Or the cardholder is off-session (MIT), where they are not involved in the payment flow and the merchant initiates the transaction for goods or services provided. Repeats will always be classed as Merchant Initiated Transactions (MIT).   * &#x60;MIT&#x60; &#x3D; Merchant Initiated Transaction. The &#x60;cofUsage&#x60;:&#x60;Subsequent&#x60; must be submitted. 3D Secure authentication is not required. 
        /// </summary>
        /// <value>Indicates whether the cardholder is in-session (CIT), where they are on your website and they select the submit button to make a payment. Or the cardholder is off-session (MIT), where they are not involved in the payment flow and the merchant initiates the transaction for goods or services provided. Repeats will always be classed as Merchant Initiated Transactions (MIT).   * &#x60;MIT&#x60; &#x3D; Merchant Initiated Transaction. The &#x60;cofUsage&#x60;:&#x60;Subsequent&#x60; must be submitted. 3D Secure authentication is not required. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InitiatedTypeEnum
        {
            /// <summary>
            /// Enum MIT for value: MIT
            /// </summary>
            [EnumMember(Value = "MIT")]
            MIT = 1

        }


        /// <summary>
        /// Indicates whether the cardholder is in-session (CIT), where they are on your website and they select the submit button to make a payment. Or the cardholder is off-session (MIT), where they are not involved in the payment flow and the merchant initiates the transaction for goods or services provided. Repeats will always be classed as Merchant Initiated Transactions (MIT).   * &#x60;MIT&#x60; &#x3D; Merchant Initiated Transaction. The &#x60;cofUsage&#x60;:&#x60;Subsequent&#x60; must be submitted. 3D Secure authentication is not required. 
        /// </summary>
        /// <value>Indicates whether the cardholder is in-session (CIT), where they are on your website and they select the submit button to make a payment. Or the cardholder is off-session (MIT), where they are not involved in the payment flow and the merchant initiates the transaction for goods or services provided. Repeats will always be classed as Merchant Initiated Transactions (MIT).   * &#x60;MIT&#x60; &#x3D; Merchant Initiated Transaction. The &#x60;cofUsage&#x60;:&#x60;Subsequent&#x60; must be submitted. 3D Secure authentication is not required. </value>
        [DataMember(Name = "initiatedType", IsRequired = true, EmitDefaultValue = true)]
        public InitiatedTypeEnum InitiatedType { get; set; }
        /// <summary>
        /// Indicates what you&#39;ll be storing and using the credential on file for. You must check first with your acquirer to see that they support the type of MIT you intend to use. Unscheduled Credential on File and Recurring payments are typically supported by all acquirers. Required if &#x60;initiatedType&#x60;:&#x60;MIT&#x60;, highly recommended if &#x60;initiatedType&#x60;:&#x60;CIT&#x60;.   * &#x60;Instalment&#x60; &#x3D; A single purchase of goods/services paid for over multiple payments.   * &#x60;Recurring&#x60; &#x3D; A purchase of goods/services provided at fixed regular intervals not exceeding one year between transactions.   * &#x60;Unscheduled&#x60; &#x3D; A purchase of goods/services provided at irregular intervals with a fixed or variable amount.   * &#x60;Incremental&#x60; &#x3D; An additional purchase made after an initial or estimated authorisation. Example; room service is added to the cardholders stay. Only available for certain MCCs, such as Hotels, Car Rental companies.   * &#x60;DelayedCharge&#x60; &#x3D; An additional charge made after original services are rendered. Example; a parking fine. Only available for certain MCCs such as Car Rental companies.   * &#x60;NoShow&#x60; &#x3D; A charge for services where the cardholder entered into an agreement to purchase, but did not meet the terms of the agreement. Example; A no show after booking a hotel room. Only available for certain MCCs, such as Hotels, Car Rental companies.   * &#x60;Reauthorisation&#x60; &#x3D; A further purchase is made after the original purchase.  Example; extended stays/rentals. Can also be used in split shipment scenarios.   * &#x60;Resubmission&#x60; &#x3D; An authorisation request has been declined due to insufficient funds &#x60;bankResponseCode&#x60;:&#x60;51&#x60;, at the time the goods or services have already provided. You can resubmit your transaction to attempt to get a successful authorisation. 
        /// </summary>
        /// <value>Indicates what you&#39;ll be storing and using the credential on file for. You must check first with your acquirer to see that they support the type of MIT you intend to use. Unscheduled Credential on File and Recurring payments are typically supported by all acquirers. Required if &#x60;initiatedType&#x60;:&#x60;MIT&#x60;, highly recommended if &#x60;initiatedType&#x60;:&#x60;CIT&#x60;.   * &#x60;Instalment&#x60; &#x3D; A single purchase of goods/services paid for over multiple payments.   * &#x60;Recurring&#x60; &#x3D; A purchase of goods/services provided at fixed regular intervals not exceeding one year between transactions.   * &#x60;Unscheduled&#x60; &#x3D; A purchase of goods/services provided at irregular intervals with a fixed or variable amount.   * &#x60;Incremental&#x60; &#x3D; An additional purchase made after an initial or estimated authorisation. Example; room service is added to the cardholders stay. Only available for certain MCCs, such as Hotels, Car Rental companies.   * &#x60;DelayedCharge&#x60; &#x3D; An additional charge made after original services are rendered. Example; a parking fine. Only available for certain MCCs such as Car Rental companies.   * &#x60;NoShow&#x60; &#x3D; A charge for services where the cardholder entered into an agreement to purchase, but did not meet the terms of the agreement. Example; A no show after booking a hotel room. Only available for certain MCCs, such as Hotels, Car Rental companies.   * &#x60;Reauthorisation&#x60; &#x3D; A further purchase is made after the original purchase.  Example; extended stays/rentals. Can also be used in split shipment scenarios.   * &#x60;Resubmission&#x60; &#x3D; An authorisation request has been declined due to insufficient funds &#x60;bankResponseCode&#x60;:&#x60;51&#x60;, at the time the goods or services have already provided. You can resubmit your transaction to attempt to get a successful authorisation. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MitTypeEnum
        {
            /// <summary>
            /// Enum Instalment for value: Instalment
            /// </summary>
            [EnumMember(Value = "Instalment")]
            Instalment = 1,

            /// <summary>
            /// Enum Recurring for value: Recurring
            /// </summary>
            [EnumMember(Value = "Recurring")]
            Recurring = 2,

            /// <summary>
            /// Enum Unscheduled for value: Unscheduled
            /// </summary>
            [EnumMember(Value = "Unscheduled")]
            Unscheduled = 3,

            /// <summary>
            /// Enum Incremental for value: Incremental
            /// </summary>
            [EnumMember(Value = "Incremental")]
            Incremental = 4,

            /// <summary>
            /// Enum DelayedCharge for value: DelayedCharge
            /// </summary>
            [EnumMember(Value = "DelayedCharge")]
            DelayedCharge = 5,

            /// <summary>
            /// Enum NoShow for value: NoShow
            /// </summary>
            [EnumMember(Value = "NoShow")]
            NoShow = 6,

            /// <summary>
            /// Enum Reauthorisation for value: Reauthorisation
            /// </summary>
            [EnumMember(Value = "Reauthorisation")]
            Reauthorisation = 7,

            /// <summary>
            /// Enum Resubmission for value: Resubmission
            /// </summary>
            [EnumMember(Value = "Resubmission")]
            Resubmission = 8

        }


        /// <summary>
        /// Indicates what you&#39;ll be storing and using the credential on file for. You must check first with your acquirer to see that they support the type of MIT you intend to use. Unscheduled Credential on File and Recurring payments are typically supported by all acquirers. Required if &#x60;initiatedType&#x60;:&#x60;MIT&#x60;, highly recommended if &#x60;initiatedType&#x60;:&#x60;CIT&#x60;.   * &#x60;Instalment&#x60; &#x3D; A single purchase of goods/services paid for over multiple payments.   * &#x60;Recurring&#x60; &#x3D; A purchase of goods/services provided at fixed regular intervals not exceeding one year between transactions.   * &#x60;Unscheduled&#x60; &#x3D; A purchase of goods/services provided at irregular intervals with a fixed or variable amount.   * &#x60;Incremental&#x60; &#x3D; An additional purchase made after an initial or estimated authorisation. Example; room service is added to the cardholders stay. Only available for certain MCCs, such as Hotels, Car Rental companies.   * &#x60;DelayedCharge&#x60; &#x3D; An additional charge made after original services are rendered. Example; a parking fine. Only available for certain MCCs such as Car Rental companies.   * &#x60;NoShow&#x60; &#x3D; A charge for services where the cardholder entered into an agreement to purchase, but did not meet the terms of the agreement. Example; A no show after booking a hotel room. Only available for certain MCCs, such as Hotels, Car Rental companies.   * &#x60;Reauthorisation&#x60; &#x3D; A further purchase is made after the original purchase.  Example; extended stays/rentals. Can also be used in split shipment scenarios.   * &#x60;Resubmission&#x60; &#x3D; An authorisation request has been declined due to insufficient funds &#x60;bankResponseCode&#x60;:&#x60;51&#x60;, at the time the goods or services have already provided. You can resubmit your transaction to attempt to get a successful authorisation. 
        /// </summary>
        /// <value>Indicates what you&#39;ll be storing and using the credential on file for. You must check first with your acquirer to see that they support the type of MIT you intend to use. Unscheduled Credential on File and Recurring payments are typically supported by all acquirers. Required if &#x60;initiatedType&#x60;:&#x60;MIT&#x60;, highly recommended if &#x60;initiatedType&#x60;:&#x60;CIT&#x60;.   * &#x60;Instalment&#x60; &#x3D; A single purchase of goods/services paid for over multiple payments.   * &#x60;Recurring&#x60; &#x3D; A purchase of goods/services provided at fixed regular intervals not exceeding one year between transactions.   * &#x60;Unscheduled&#x60; &#x3D; A purchase of goods/services provided at irregular intervals with a fixed or variable amount.   * &#x60;Incremental&#x60; &#x3D; An additional purchase made after an initial or estimated authorisation. Example; room service is added to the cardholders stay. Only available for certain MCCs, such as Hotels, Car Rental companies.   * &#x60;DelayedCharge&#x60; &#x3D; An additional charge made after original services are rendered. Example; a parking fine. Only available for certain MCCs such as Car Rental companies.   * &#x60;NoShow&#x60; &#x3D; A charge for services where the cardholder entered into an agreement to purchase, but did not meet the terms of the agreement. Example; A no show after booking a hotel room. Only available for certain MCCs, such as Hotels, Car Rental companies.   * &#x60;Reauthorisation&#x60; &#x3D; A further purchase is made after the original purchase.  Example; extended stays/rentals. Can also be used in split shipment scenarios.   * &#x60;Resubmission&#x60; &#x3D; An authorisation request has been declined due to insufficient funds &#x60;bankResponseCode&#x60;:&#x60;51&#x60;, at the time the goods or services have already provided. You can resubmit your transaction to attempt to get a successful authorisation. </value>
        [DataMember(Name = "mitType", EmitDefaultValue = false)]
        public MitTypeEnum? MitType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialTypeRepeat" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CredentialTypeRepeat() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialTypeRepeat" /> class.
        /// </summary>
        /// <param name="cofUsage">Required when you are repeating a previously stored credential.   * &#x60;Subsequent&#x60; &#x3D; You are using a stored credential  (required).</param>
        /// <param name="initiatedType">Indicates whether the cardholder is in-session (CIT), where they are on your website and they select the submit button to make a payment. Or the cardholder is off-session (MIT), where they are not involved in the payment flow and the merchant initiates the transaction for goods or services provided. Repeats will always be classed as Merchant Initiated Transactions (MIT).   * &#x60;MIT&#x60; &#x3D; Merchant Initiated Transaction. The &#x60;cofUsage&#x60;:&#x60;Subsequent&#x60; must be submitted. 3D Secure authentication is not required.  (required).</param>
        /// <param name="mitType">Indicates what you&#39;ll be storing and using the credential on file for. You must check first with your acquirer to see that they support the type of MIT you intend to use. Unscheduled Credential on File and Recurring payments are typically supported by all acquirers. Required if &#x60;initiatedType&#x60;:&#x60;MIT&#x60;, highly recommended if &#x60;initiatedType&#x60;:&#x60;CIT&#x60;.   * &#x60;Instalment&#x60; &#x3D; A single purchase of goods/services paid for over multiple payments.   * &#x60;Recurring&#x60; &#x3D; A purchase of goods/services provided at fixed regular intervals not exceeding one year between transactions.   * &#x60;Unscheduled&#x60; &#x3D; A purchase of goods/services provided at irregular intervals with a fixed or variable amount.   * &#x60;Incremental&#x60; &#x3D; An additional purchase made after an initial or estimated authorisation. Example; room service is added to the cardholders stay. Only available for certain MCCs, such as Hotels, Car Rental companies.   * &#x60;DelayedCharge&#x60; &#x3D; An additional charge made after original services are rendered. Example; a parking fine. Only available for certain MCCs such as Car Rental companies.   * &#x60;NoShow&#x60; &#x3D; A charge for services where the cardholder entered into an agreement to purchase, but did not meet the terms of the agreement. Example; A no show after booking a hotel room. Only available for certain MCCs, such as Hotels, Car Rental companies.   * &#x60;Reauthorisation&#x60; &#x3D; A further purchase is made after the original purchase.  Example; extended stays/rentals. Can also be used in split shipment scenarios.   * &#x60;Resubmission&#x60; &#x3D; An authorisation request has been declined due to insufficient funds &#x60;bankResponseCode&#x60;:&#x60;51&#x60;, at the time the goods or services have already provided. You can resubmit your transaction to attempt to get a successful authorisation. .</param>
        /// <param name="recurringExpiry">YYYYMMDD. Required if &#x60;mitType&#x60;:&#x60;Recurring&#x60; or &#x60;mitType&#x60;:&#x60;Instalment&#x60;. This value relates to the date of when the last Recurring payment or Instalment will occur. If you submit a Recurring or Instalment transaction request after this date for the stored credential, the card issuer may decline the transaction or provide a &#39;soft decline&#39;..</param>
        /// <param name="recurringFrequency">Value is in days. Required if &#x60;mitType&#x60;:&#x60;Recurring&#x60; or &#x60;mitType&#x60;:&#x60;Instalment&#x60;. The regular frequency of the Recurring payment or Instalment..</param>
        /// <param name="purchaseInstalData">Value is in days. Required if &#x60;mitType&#x60;:&#x60;Instalment&#x60;. Must be a value greater than 1, example, 2 and upwards. The number of instalments required to fully pay off the received goods or services. Any extra instalments taken greater than the value entered, may lead to the card issuer declining the transaction request..</param>
        public CredentialTypeRepeat(CofUsageEnum cofUsage = default, InitiatedTypeEnum initiatedType = default, MitTypeEnum? mitType = default, string recurringExpiry = default, string recurringFrequency = default, string purchaseInstalData = default)
        {
            CofUsage = cofUsage;
            InitiatedType = initiatedType;
            MitType = mitType;
            RecurringExpiry = recurringExpiry;
            RecurringFrequency = recurringFrequency;
            PurchaseInstalData = purchaseInstalData;
        }

        /// <summary>
        /// YYYYMMDD. Required if &#x60;mitType&#x60;:&#x60;Recurring&#x60; or &#x60;mitType&#x60;:&#x60;Instalment&#x60;. This value relates to the date of when the last Recurring payment or Instalment will occur. If you submit a Recurring or Instalment transaction request after this date for the stored credential, the card issuer may decline the transaction or provide a &#39;soft decline&#39;.
        /// </summary>
        /// <value>YYYYMMDD. Required if &#x60;mitType&#x60;:&#x60;Recurring&#x60; or &#x60;mitType&#x60;:&#x60;Instalment&#x60;. This value relates to the date of when the last Recurring payment or Instalment will occur. If you submit a Recurring or Instalment transaction request after this date for the stored credential, the card issuer may decline the transaction or provide a &#39;soft decline&#39;.</value>
        [DataMember(Name = "recurringExpiry", EmitDefaultValue = false)]
        public string RecurringExpiry { get; set; }

        /// <summary>
        /// Value is in days. Required if &#x60;mitType&#x60;:&#x60;Recurring&#x60; or &#x60;mitType&#x60;:&#x60;Instalment&#x60;. The regular frequency of the Recurring payment or Instalment.
        /// </summary>
        /// <value>Value is in days. Required if &#x60;mitType&#x60;:&#x60;Recurring&#x60; or &#x60;mitType&#x60;:&#x60;Instalment&#x60;. The regular frequency of the Recurring payment or Instalment.</value>
        [DataMember(Name = "recurringFrequency", EmitDefaultValue = false)]
        public string RecurringFrequency { get; set; }

        /// <summary>
        /// Value is in days. Required if &#x60;mitType&#x60;:&#x60;Instalment&#x60;. Must be a value greater than 1, example, 2 and upwards. The number of instalments required to fully pay off the received goods or services. Any extra instalments taken greater than the value entered, may lead to the card issuer declining the transaction request.
        /// </summary>
        /// <value>Value is in days. Required if &#x60;mitType&#x60;:&#x60;Instalment&#x60;. Must be a value greater than 1, example, 2 and upwards. The number of instalments required to fully pay off the received goods or services. Any extra instalments taken greater than the value entered, may lead to the card issuer declining the transaction request.</value>
        [DataMember(Name = "purchaseInstalData", EmitDefaultValue = false)]
        public string PurchaseInstalData { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CredentialTypeRepeat {\n");
            sb.Append("  CofUsage: ").Append(CofUsage).Append("\n");
            sb.Append("  InitiatedType: ").Append(InitiatedType).Append("\n");
            sb.Append("  MitType: ").Append(MitType).Append("\n");
            sb.Append("  RecurringExpiry: ").Append(RecurringExpiry).Append("\n");
            sb.Append("  RecurringFrequency: ").Append(RecurringFrequency).Append("\n");
            sb.Append("  PurchaseInstalData: ").Append(PurchaseInstalData).Append("\n");
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
            return Equals(input as CredentialTypeRepeat);
        }

        /// <summary>
        /// Returns true if CredentialTypeRepeat instances are equal
        /// </summary>
        /// <param name="input">Instance of CredentialTypeRepeat to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CredentialTypeRepeat input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    CofUsage == input.CofUsage ||
                    CofUsage.Equals(input.CofUsage)
                ) &&
                (
                    InitiatedType == input.InitiatedType ||
                    InitiatedType.Equals(input.InitiatedType)
                ) &&
                (
                    MitType == input.MitType ||
                    MitType.Equals(input.MitType)
                ) &&
                (
                    RecurringExpiry == input.RecurringExpiry ||
                    RecurringExpiry != null &&
                    RecurringExpiry.Equals(input.RecurringExpiry)
                ) &&
                (
                    RecurringFrequency == input.RecurringFrequency ||
                    RecurringFrequency != null &&
                    RecurringFrequency.Equals(input.RecurringFrequency)
                ) &&
                (
                    PurchaseInstalData == input.PurchaseInstalData ||
                    PurchaseInstalData != null &&
                    PurchaseInstalData.Equals(input.PurchaseInstalData)
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
                hashCode = hashCode * 59 + CofUsage.GetHashCode();
                hashCode = hashCode * 59 + InitiatedType.GetHashCode();
                hashCode = hashCode * 59 + MitType.GetHashCode();
                if (RecurringExpiry != null)
                {
                    hashCode = hashCode * 59 + RecurringExpiry.GetHashCode();
                }
                if (RecurringFrequency != null)
                {
                    hashCode = hashCode * 59 + RecurringFrequency.GetHashCode();
                }
                if (PurchaseInstalData != null)
                {
                    hashCode = hashCode * 59 + PurchaseInstalData.GetHashCode();
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
            // RecurringExpiry (string) maxLength
            if (RecurringExpiry != null && RecurringExpiry.Length > 8)
            {
                yield return new ValidationResult("Invalid value for RecurringExpiry, length must be less than 8.", new[] { "RecurringExpiry" });
            }

            // RecurringFrequency (string) maxLength
            if (RecurringFrequency != null && RecurringFrequency.Length > 4)
            {
                yield return new ValidationResult("Invalid value for RecurringFrequency, length must be less than 4.", new[] { "RecurringFrequency" });
            }

            // PurchaseInstalData (string) maxLength
            if (PurchaseInstalData != null && PurchaseInstalData.Length > 3)
            {
                yield return new ValidationResult("Invalid value for PurchaseInstalData, length must be less than 3.", new[] { "PurchaseInstalData" });
            }

            yield break;
        }
    }

}
