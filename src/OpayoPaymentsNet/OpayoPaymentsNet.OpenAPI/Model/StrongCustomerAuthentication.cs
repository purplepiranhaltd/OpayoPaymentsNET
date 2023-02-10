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
    /// The &#x60;strongCustomerAuthentication&#x60; object is used for 3D Secure Version 2.
    /// </summary>
    [DataContract(Name = "strongCustomerAuthentication")]
    public partial class StrongCustomerAuthentication : IEquatable<StrongCustomerAuthentication>, IValidatableObject
    {
        /// <summary>
        /// Value representing the bit depth of the colour palette for displaying images, in bits per pixel.   Obtained from Cardholder browser using the &#x60;screen.colorDepth&#x60; property.   * &#x60;1&#x60; &#x3D; 1 bit  * &#x60;4&#x60; &#x3D; 4 bits  * &#x60;8&#x60; &#x3D; 8 bits  * &#x60;15&#x60; &#x3D; 15 bits  * &#x60;16&#x60; &#x3D; 16 bits  * &#x60;24&#x60; &#x3D; 24 bits  * &#x60;32&#x60; &#x3D; 32 bits  * &#x60;48&#x60; &#x3D; 48 bits  Required if &#x60;browserJavascriptEnabled&#x60; is &#x60;true&#x60;. 
        /// </summary>
        /// <value>Value representing the bit depth of the colour palette for displaying images, in bits per pixel.   Obtained from Cardholder browser using the &#x60;screen.colorDepth&#x60; property.   * &#x60;1&#x60; &#x3D; 1 bit  * &#x60;4&#x60; &#x3D; 4 bits  * &#x60;8&#x60; &#x3D; 8 bits  * &#x60;15&#x60; &#x3D; 15 bits  * &#x60;16&#x60; &#x3D; 16 bits  * &#x60;24&#x60; &#x3D; 24 bits  * &#x60;32&#x60; &#x3D; 32 bits  * &#x60;48&#x60; &#x3D; 48 bits  Required if &#x60;browserJavascriptEnabled&#x60; is &#x60;true&#x60;. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum BrowserColorDepthEnum
        {
            /// <summary>
            /// Enum _1 for value: 1
            /// </summary>
            [EnumMember(Value = "1")]
            _1 = 1,

            /// <summary>
            /// Enum _4 for value: 4
            /// </summary>
            [EnumMember(Value = "4")]
            _4 = 2,

            /// <summary>
            /// Enum _8 for value: 8
            /// </summary>
            [EnumMember(Value = "8")]
            _8 = 3,

            /// <summary>
            /// Enum _15 for value: 15
            /// </summary>
            [EnumMember(Value = "15")]
            _15 = 4,

            /// <summary>
            /// Enum _16 for value: 16
            /// </summary>
            [EnumMember(Value = "16")]
            _16 = 5,

            /// <summary>
            /// Enum _24 for value: 24
            /// </summary>
            [EnumMember(Value = "24")]
            _24 = 6,

            /// <summary>
            /// Enum _32 for value: 32
            /// </summary>
            [EnumMember(Value = "32")]
            _32 = 7,

            /// <summary>
            /// Enum _48 for value: 48
            /// </summary>
            [EnumMember(Value = "48")]
            _48 = 8

        }


        /// <summary>
        /// Value representing the bit depth of the colour palette for displaying images, in bits per pixel.   Obtained from Cardholder browser using the &#x60;screen.colorDepth&#x60; property.   * &#x60;1&#x60; &#x3D; 1 bit  * &#x60;4&#x60; &#x3D; 4 bits  * &#x60;8&#x60; &#x3D; 8 bits  * &#x60;15&#x60; &#x3D; 15 bits  * &#x60;16&#x60; &#x3D; 16 bits  * &#x60;24&#x60; &#x3D; 24 bits  * &#x60;32&#x60; &#x3D; 32 bits  * &#x60;48&#x60; &#x3D; 48 bits  Required if &#x60;browserJavascriptEnabled&#x60; is &#x60;true&#x60;. 
        /// </summary>
        /// <value>Value representing the bit depth of the colour palette for displaying images, in bits per pixel.   Obtained from Cardholder browser using the &#x60;screen.colorDepth&#x60; property.   * &#x60;1&#x60; &#x3D; 1 bit  * &#x60;4&#x60; &#x3D; 4 bits  * &#x60;8&#x60; &#x3D; 8 bits  * &#x60;15&#x60; &#x3D; 15 bits  * &#x60;16&#x60; &#x3D; 16 bits  * &#x60;24&#x60; &#x3D; 24 bits  * &#x60;32&#x60; &#x3D; 32 bits  * &#x60;48&#x60; &#x3D; 48 bits  Required if &#x60;browserJavascriptEnabled&#x60; is &#x60;true&#x60;. </value>
        [DataMember(Name = "browserColorDepth", EmitDefaultValue = false)]
        public BrowserColorDepthEnum? BrowserColorDepth { get; set; }
        /// <summary>
        /// Dimensions of the challenge window that has been displayed to the Cardholder.   The ACS shall reply with content that is formatted to appropriately render the challenge UI in this window, to provide the best possible user experience.  Preconfigured sizes are width x height in pixels of the window displayed in the Cardholder browser window.   * &#x60;Small&#x60; &#x3D; 250 x 400  * &#x60;Medium&#x60; &#x3D; 390 x 400  * &#x60;Large&#x60; &#x3D; 500 x 600  * &#x60;ExtraLarge&#x60; &#x3D; 600 x 400  * &#x60;FullScreen&#x60; &#x3D; Full screen 
        /// </summary>
        /// <value>Dimensions of the challenge window that has been displayed to the Cardholder.   The ACS shall reply with content that is formatted to appropriately render the challenge UI in this window, to provide the best possible user experience.  Preconfigured sizes are width x height in pixels of the window displayed in the Cardholder browser window.   * &#x60;Small&#x60; &#x3D; 250 x 400  * &#x60;Medium&#x60; &#x3D; 390 x 400  * &#x60;Large&#x60; &#x3D; 500 x 600  * &#x60;ExtraLarge&#x60; &#x3D; 600 x 400  * &#x60;FullScreen&#x60; &#x3D; Full screen </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChallengeWindowSizeEnum
        {
            /// <summary>
            /// Enum Small for value: Small
            /// </summary>
            [EnumMember(Value = "Small")]
            Small = 1,

            /// <summary>
            /// Enum Medium for value: Medium
            /// </summary>
            [EnumMember(Value = "Medium")]
            Medium = 2,

            /// <summary>
            /// Enum Large for value: Large
            /// </summary>
            [EnumMember(Value = "Large")]
            Large = 3,

            /// <summary>
            /// Enum ExtraLarge for value: ExtraLarge
            /// </summary>
            [EnumMember(Value = "ExtraLarge")]
            ExtraLarge = 4,

            /// <summary>
            /// Enum FullScreen for value: FullScreen
            /// </summary>
            [EnumMember(Value = "FullScreen")]
            FullScreen = 5

        }


        /// <summary>
        /// Dimensions of the challenge window that has been displayed to the Cardholder.   The ACS shall reply with content that is formatted to appropriately render the challenge UI in this window, to provide the best possible user experience.  Preconfigured sizes are width x height in pixels of the window displayed in the Cardholder browser window.   * &#x60;Small&#x60; &#x3D; 250 x 400  * &#x60;Medium&#x60; &#x3D; 390 x 400  * &#x60;Large&#x60; &#x3D; 500 x 600  * &#x60;ExtraLarge&#x60; &#x3D; 600 x 400  * &#x60;FullScreen&#x60; &#x3D; Full screen 
        /// </summary>
        /// <value>Dimensions of the challenge window that has been displayed to the Cardholder.   The ACS shall reply with content that is formatted to appropriately render the challenge UI in this window, to provide the best possible user experience.  Preconfigured sizes are width x height in pixels of the window displayed in the Cardholder browser window.   * &#x60;Small&#x60; &#x3D; 250 x 400  * &#x60;Medium&#x60; &#x3D; 390 x 400  * &#x60;Large&#x60; &#x3D; 500 x 600  * &#x60;ExtraLarge&#x60; &#x3D; 600 x 400  * &#x60;FullScreen&#x60; &#x3D; Full screen </value>
        [DataMember(Name = "challengeWindowSize", IsRequired = true, EmitDefaultValue = true)]
        public ChallengeWindowSizeEnum ChallengeWindowSize { get; set; }
        /// <summary>
        /// Identifies the type of transaction being authenticated.    * &#x60;GoodsAndServicePurchase&#x60; &#x3D; Goods/ Service Purchase   * &#x60;CheckAcceptance&#x60; &#x3D; Check Acceptance   * &#x60;AccountFunding&#x60; &#x3D; Account Funding   * &#x60;QuasiCashTransaction&#x60; &#x3D; Quasi-Cash Transaction   * &#x60;PrepaidActivationAndLoad&#x60; &#x3D; Prepaid Activation and Load  Values derived from the 8583 ISO Standard. 
        /// </summary>
        /// <value>Identifies the type of transaction being authenticated.    * &#x60;GoodsAndServicePurchase&#x60; &#x3D; Goods/ Service Purchase   * &#x60;CheckAcceptance&#x60; &#x3D; Check Acceptance   * &#x60;AccountFunding&#x60; &#x3D; Account Funding   * &#x60;QuasiCashTransaction&#x60; &#x3D; Quasi-Cash Transaction   * &#x60;PrepaidActivationAndLoad&#x60; &#x3D; Prepaid Activation and Load  Values derived from the 8583 ISO Standard. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TransTypeEnum
        {
            /// <summary>
            /// Enum GoodsAndServicePurchase for value: GoodsAndServicePurchase
            /// </summary>
            [EnumMember(Value = "GoodsAndServicePurchase")]
            GoodsAndServicePurchase = 1,

            /// <summary>
            /// Enum CheckAcceptance for value: CheckAcceptance
            /// </summary>
            [EnumMember(Value = "CheckAcceptance")]
            CheckAcceptance = 2,

            /// <summary>
            /// Enum AccountFunding for value: AccountFunding
            /// </summary>
            [EnumMember(Value = "AccountFunding")]
            AccountFunding = 3,

            /// <summary>
            /// Enum QuasiCashTransaction for value: QuasiCashTransaction
            /// </summary>
            [EnumMember(Value = "QuasiCashTransaction")]
            QuasiCashTransaction = 4,

            /// <summary>
            /// Enum PrepaidActivationAndLoad for value: PrepaidActivationAndLoad
            /// </summary>
            [EnumMember(Value = "PrepaidActivationAndLoad")]
            PrepaidActivationAndLoad = 5

        }


        /// <summary>
        /// Identifies the type of transaction being authenticated.    * &#x60;GoodsAndServicePurchase&#x60; &#x3D; Goods/ Service Purchase   * &#x60;CheckAcceptance&#x60; &#x3D; Check Acceptance   * &#x60;AccountFunding&#x60; &#x3D; Account Funding   * &#x60;QuasiCashTransaction&#x60; &#x3D; Quasi-Cash Transaction   * &#x60;PrepaidActivationAndLoad&#x60; &#x3D; Prepaid Activation and Load  Values derived from the 8583 ISO Standard. 
        /// </summary>
        /// <value>Identifies the type of transaction being authenticated.    * &#x60;GoodsAndServicePurchase&#x60; &#x3D; Goods/ Service Purchase   * &#x60;CheckAcceptance&#x60; &#x3D; Check Acceptance   * &#x60;AccountFunding&#x60; &#x3D; Account Funding   * &#x60;QuasiCashTransaction&#x60; &#x3D; Quasi-Cash Transaction   * &#x60;PrepaidActivationAndLoad&#x60; &#x3D; Prepaid Activation and Load  Values derived from the 8583 ISO Standard. </value>
        [DataMember(Name = "transType", IsRequired = true, EmitDefaultValue = true)]
        public TransTypeEnum TransType { get; set; }
        /// <summary>
        /// Indicates the reason you&#39;re bypassing 3D Secure authentication. Use in conjunction with &#x60;apply3DSecure&#x60;:&#x60;Disable&#x60;. You must first get permission from your acquirer to use exemptions. Using exemptions means that fraud liability, for the transaction, is shifted to you the merchant. If the card issuer does not agree with the exemption, they can return a &#39;soft decline&#39; - response code of &#x60;bankResponseCode&#x60;:&#x60;65&#x60; or &#x60;bankResponseCode&#x60;:&#x60;1A&#x60; - Opayo will automatically request for 3D Secure authentication and submit another authorisation request to the card issuer with 3D Secure authentication data. It is important that you correctly populate the required field values for the &#x60;strongCustomerAuthentication&#x60; object.   * &#x60;LowValue&#x60; &#x3D; Low Value Transaction (LVT); the transaction value must be 30 EUR or less and is permitted for a maximum of five consecutive LVTs or a maximum cumulative LVT amount can be 100 EUR. On the sixth LVT or when the cumulative LVT amount is over 100 EUR, then 3D Secure authentication must be performed. Since the cardholder could have used their LVT exemptions elsewhere on other merchants&#39; sites, you would not be able to accurately use this exemption. Only the card issuer will know if the LVT exemption counters have been reached.   * &#x60;TransactionRiskAnalysis&#x60; &#x3D; Transaction Risk Analysis (TRA); if you or your acquirer have a low number of chargebacks over a given number of transactions, the card schemes will have more trust in you and the acquirer and permit eligible merchants to bypass authentication using the TRA exemption.   * &#x60;TrustedMerchant&#x60; &#x3D; Trusted beneficiaries / merchant; you can use this exemption if the cardholder adds you to a trusted beneficiaries list. They can do this if prompted to do so by their card issuer either when they log into their bank account or during a challenge authentication flow.   * &#x60;SecureCorporatePayment&#x60; &#x3D; Secure Corporate Payments; if your client uses a secure corporate card such as a lodge corporate card or virtual card numbers, then these are exempt from 3D Secure authentication. These payments will be typically Business to Business payments (B2B), which will already have dedicated corporate processes and protocols in place. This exemption does not apply for personal corporate cards.   * &#x60;DelegatedAuthentication&#x60; &#x3D; Delegated Authentication; You can request for this exemption to not perform 3D Secure authentication again if you have already performed it. To be able to do this, you must already have undergone accreditation with the card schemes for 3D Secure authentication. This means the card schemes now trust you to perform 3D Secure authentication independently of them (the card schemes have delegated authentication to you). 
        /// </summary>
        /// <value>Indicates the reason you&#39;re bypassing 3D Secure authentication. Use in conjunction with &#x60;apply3DSecure&#x60;:&#x60;Disable&#x60;. You must first get permission from your acquirer to use exemptions. Using exemptions means that fraud liability, for the transaction, is shifted to you the merchant. If the card issuer does not agree with the exemption, they can return a &#39;soft decline&#39; - response code of &#x60;bankResponseCode&#x60;:&#x60;65&#x60; or &#x60;bankResponseCode&#x60;:&#x60;1A&#x60; - Opayo will automatically request for 3D Secure authentication and submit another authorisation request to the card issuer with 3D Secure authentication data. It is important that you correctly populate the required field values for the &#x60;strongCustomerAuthentication&#x60; object.   * &#x60;LowValue&#x60; &#x3D; Low Value Transaction (LVT); the transaction value must be 30 EUR or less and is permitted for a maximum of five consecutive LVTs or a maximum cumulative LVT amount can be 100 EUR. On the sixth LVT or when the cumulative LVT amount is over 100 EUR, then 3D Secure authentication must be performed. Since the cardholder could have used their LVT exemptions elsewhere on other merchants&#39; sites, you would not be able to accurately use this exemption. Only the card issuer will know if the LVT exemption counters have been reached.   * &#x60;TransactionRiskAnalysis&#x60; &#x3D; Transaction Risk Analysis (TRA); if you or your acquirer have a low number of chargebacks over a given number of transactions, the card schemes will have more trust in you and the acquirer and permit eligible merchants to bypass authentication using the TRA exemption.   * &#x60;TrustedMerchant&#x60; &#x3D; Trusted beneficiaries / merchant; you can use this exemption if the cardholder adds you to a trusted beneficiaries list. They can do this if prompted to do so by their card issuer either when they log into their bank account or during a challenge authentication flow.   * &#x60;SecureCorporatePayment&#x60; &#x3D; Secure Corporate Payments; if your client uses a secure corporate card such as a lodge corporate card or virtual card numbers, then these are exempt from 3D Secure authentication. These payments will be typically Business to Business payments (B2B), which will already have dedicated corporate processes and protocols in place. This exemption does not apply for personal corporate cards.   * &#x60;DelegatedAuthentication&#x60; &#x3D; Delegated Authentication; You can request for this exemption to not perform 3D Secure authentication again if you have already performed it. To be able to do this, you must already have undergone accreditation with the card schemes for 3D Secure authentication. This means the card schemes now trust you to perform 3D Secure authentication independently of them (the card schemes have delegated authentication to you). </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ThreeDSExemptionIndicatorEnum
        {
            /// <summary>
            /// Enum LowValue for value: LowValue
            /// </summary>
            [EnumMember(Value = "LowValue")]
            LowValue = 1,

            /// <summary>
            /// Enum TransactionRiskAnalysis for value: TransactionRiskAnalysis
            /// </summary>
            [EnumMember(Value = "TransactionRiskAnalysis")]
            TransactionRiskAnalysis = 2,

            /// <summary>
            /// Enum TrustedMerchant for value: TrustedMerchant
            /// </summary>
            [EnumMember(Value = "TrustedMerchant")]
            TrustedMerchant = 3,

            /// <summary>
            /// Enum SecureCorporatePayment for value: SecureCorporatePayment
            /// </summary>
            [EnumMember(Value = "SecureCorporatePayment")]
            SecureCorporatePayment = 4,

            /// <summary>
            /// Enum DelegatedAuthentication for value: DelegatedAuthentication
            /// </summary>
            [EnumMember(Value = "DelegatedAuthentication")]
            DelegatedAuthentication = 5

        }


        /// <summary>
        /// Indicates the reason you&#39;re bypassing 3D Secure authentication. Use in conjunction with &#x60;apply3DSecure&#x60;:&#x60;Disable&#x60;. You must first get permission from your acquirer to use exemptions. Using exemptions means that fraud liability, for the transaction, is shifted to you the merchant. If the card issuer does not agree with the exemption, they can return a &#39;soft decline&#39; - response code of &#x60;bankResponseCode&#x60;:&#x60;65&#x60; or &#x60;bankResponseCode&#x60;:&#x60;1A&#x60; - Opayo will automatically request for 3D Secure authentication and submit another authorisation request to the card issuer with 3D Secure authentication data. It is important that you correctly populate the required field values for the &#x60;strongCustomerAuthentication&#x60; object.   * &#x60;LowValue&#x60; &#x3D; Low Value Transaction (LVT); the transaction value must be 30 EUR or less and is permitted for a maximum of five consecutive LVTs or a maximum cumulative LVT amount can be 100 EUR. On the sixth LVT or when the cumulative LVT amount is over 100 EUR, then 3D Secure authentication must be performed. Since the cardholder could have used their LVT exemptions elsewhere on other merchants&#39; sites, you would not be able to accurately use this exemption. Only the card issuer will know if the LVT exemption counters have been reached.   * &#x60;TransactionRiskAnalysis&#x60; &#x3D; Transaction Risk Analysis (TRA); if you or your acquirer have a low number of chargebacks over a given number of transactions, the card schemes will have more trust in you and the acquirer and permit eligible merchants to bypass authentication using the TRA exemption.   * &#x60;TrustedMerchant&#x60; &#x3D; Trusted beneficiaries / merchant; you can use this exemption if the cardholder adds you to a trusted beneficiaries list. They can do this if prompted to do so by their card issuer either when they log into their bank account or during a challenge authentication flow.   * &#x60;SecureCorporatePayment&#x60; &#x3D; Secure Corporate Payments; if your client uses a secure corporate card such as a lodge corporate card or virtual card numbers, then these are exempt from 3D Secure authentication. These payments will be typically Business to Business payments (B2B), which will already have dedicated corporate processes and protocols in place. This exemption does not apply for personal corporate cards.   * &#x60;DelegatedAuthentication&#x60; &#x3D; Delegated Authentication; You can request for this exemption to not perform 3D Secure authentication again if you have already performed it. To be able to do this, you must already have undergone accreditation with the card schemes for 3D Secure authentication. This means the card schemes now trust you to perform 3D Secure authentication independently of them (the card schemes have delegated authentication to you). 
        /// </summary>
        /// <value>Indicates the reason you&#39;re bypassing 3D Secure authentication. Use in conjunction with &#x60;apply3DSecure&#x60;:&#x60;Disable&#x60;. You must first get permission from your acquirer to use exemptions. Using exemptions means that fraud liability, for the transaction, is shifted to you the merchant. If the card issuer does not agree with the exemption, they can return a &#39;soft decline&#39; - response code of &#x60;bankResponseCode&#x60;:&#x60;65&#x60; or &#x60;bankResponseCode&#x60;:&#x60;1A&#x60; - Opayo will automatically request for 3D Secure authentication and submit another authorisation request to the card issuer with 3D Secure authentication data. It is important that you correctly populate the required field values for the &#x60;strongCustomerAuthentication&#x60; object.   * &#x60;LowValue&#x60; &#x3D; Low Value Transaction (LVT); the transaction value must be 30 EUR or less and is permitted for a maximum of five consecutive LVTs or a maximum cumulative LVT amount can be 100 EUR. On the sixth LVT or when the cumulative LVT amount is over 100 EUR, then 3D Secure authentication must be performed. Since the cardholder could have used their LVT exemptions elsewhere on other merchants&#39; sites, you would not be able to accurately use this exemption. Only the card issuer will know if the LVT exemption counters have been reached.   * &#x60;TransactionRiskAnalysis&#x60; &#x3D; Transaction Risk Analysis (TRA); if you or your acquirer have a low number of chargebacks over a given number of transactions, the card schemes will have more trust in you and the acquirer and permit eligible merchants to bypass authentication using the TRA exemption.   * &#x60;TrustedMerchant&#x60; &#x3D; Trusted beneficiaries / merchant; you can use this exemption if the cardholder adds you to a trusted beneficiaries list. They can do this if prompted to do so by their card issuer either when they log into their bank account or during a challenge authentication flow.   * &#x60;SecureCorporatePayment&#x60; &#x3D; Secure Corporate Payments; if your client uses a secure corporate card such as a lodge corporate card or virtual card numbers, then these are exempt from 3D Secure authentication. These payments will be typically Business to Business payments (B2B), which will already have dedicated corporate processes and protocols in place. This exemption does not apply for personal corporate cards.   * &#x60;DelegatedAuthentication&#x60; &#x3D; Delegated Authentication; You can request for this exemption to not perform 3D Secure authentication again if you have already performed it. To be able to do this, you must already have undergone accreditation with the card schemes for 3D Secure authentication. This means the card schemes now trust you to perform 3D Secure authentication independently of them (the card schemes have delegated authentication to you). </value>
        [DataMember(Name = "threeDSExemptionIndicator", EmitDefaultValue = false)]
        public ThreeDSExemptionIndicatorEnum? ThreeDSExemptionIndicator { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StrongCustomerAuthentication" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected StrongCustomerAuthentication() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="StrongCustomerAuthentication" /> class.
        /// </summary>
        /// <param name="notificationURL">Fully qualified URL of the system that receives the CRes message or Error Message and where your customer will be returned once they have completed their challenge. The CRes message is posted by the ACS through the Cardholder browser at the end of the challenge AND once it receives an RRes (Result Response) message from Opayo. (required).</param>
        /// <param name="browserIP">The IPv4 or IPv6 address of the client connecting to your server making the payment as returned by the HTTP headers. This should be a full IP address which you can obtain from your server scripts. There is no need to pad IPv4 IP addresses with leading zeros (eg 12.34.45.56 not 012.034.045.056), doing so will cause transactions to be rejected. (required).</param>
        /// <param name="browserAcceptHeader">Exact content of the HTTP accept headers as sent to the 3DS Requestor from the Cardholder&#39;s browser. (required).</param>
        /// <param name="browserJavascriptEnabled">Boolean that represents the ability of the cardholder browser to execute JavaScript. (required) (default to false).</param>
        /// <param name="browserJavaEnabled">Boolean that represents the ability of the cardholder browser to execute Java. Value is returned from the &#x60;navigator.javaEnabled&#x60; property. Required if &#x60;browserJavascriptEnabled&#x60; is &#x60;true&#x60;. (default to false).</param>
        /// <param name="browserLanguage">Value representing the browser language as defined in IETF BCP47. Returned from &#x60;navigator.language&#x60; property. (required).</param>
        /// <param name="browserColorDepth">Value representing the bit depth of the colour palette for displaying images, in bits per pixel.   Obtained from Cardholder browser using the &#x60;screen.colorDepth&#x60; property.   * &#x60;1&#x60; &#x3D; 1 bit  * &#x60;4&#x60; &#x3D; 4 bits  * &#x60;8&#x60; &#x3D; 8 bits  * &#x60;15&#x60; &#x3D; 15 bits  * &#x60;16&#x60; &#x3D; 16 bits  * &#x60;24&#x60; &#x3D; 24 bits  * &#x60;32&#x60; &#x3D; 32 bits  * &#x60;48&#x60; &#x3D; 48 bits  Required if &#x60;browserJavascriptEnabled&#x60; is &#x60;true&#x60;. .</param>
        /// <param name="browserScreenHeight">Total height of the Cardholder&#39;s screen in pixels. Value is returned from the &#x60;screen.height&#x60; property. Required if &#x60;BrowserJavascriptEnabled&#x60; is &#x60;true&#x60;..</param>
        /// <param name="browserScreenWidth">Total width of the cardholder&#39;s screen in pixels. Value is returned from the &#x60;screen.width&#x60; property. Required if &#x60;BrowserJavascriptEnabled&#x60; is &#x60;true&#x60;..</param>
        /// <param name="browserTZ">Time-zone offset in minutes between UTC and the Cardholder browser local time.   &#x60;Note&#x60; : The offset is positive if the local time zone is behind UTC and negative if it is ahead.    Example time zone offset values in minutes:  If UTC -5 hours (-300 minutes):  * 300  * +300  If UTC +5 hours (300 minutes):  * -300  Required if &#x60;browserJavascriptEnabled&#x60; is &#x60;true&#x60;. .</param>
        /// <param name="browserUserAgent">Exact content of the HTTP user-agent header. (required).</param>
        /// <param name="challengeWindowSize">Dimensions of the challenge window that has been displayed to the Cardholder.   The ACS shall reply with content that is formatted to appropriately render the challenge UI in this window, to provide the best possible user experience.  Preconfigured sizes are width x height in pixels of the window displayed in the Cardholder browser window.   * &#x60;Small&#x60; &#x3D; 250 x 400  * &#x60;Medium&#x60; &#x3D; 390 x 400  * &#x60;Large&#x60; &#x3D; 500 x 600  * &#x60;ExtraLarge&#x60; &#x3D; 600 x 400  * &#x60;FullScreen&#x60; &#x3D; Full screen  (required).</param>
        /// <param name="acctID">The account ID, if applicable, of your customers account on your website..</param>
        /// <param name="transType">Identifies the type of transaction being authenticated.    * &#x60;GoodsAndServicePurchase&#x60; &#x3D; Goods/ Service Purchase   * &#x60;CheckAcceptance&#x60; &#x3D; Check Acceptance   * &#x60;AccountFunding&#x60; &#x3D; Account Funding   * &#x60;QuasiCashTransaction&#x60; &#x3D; Quasi-Cash Transaction   * &#x60;PrepaidActivationAndLoad&#x60; &#x3D; Prepaid Activation and Load  Values derived from the 8583 ISO Standard.  (required).</param>
        /// <param name="threeDSRequestorAuthenticationInfo">threeDSRequestorAuthenticationInfo.</param>
        /// <param name="threeDSRequestorPriorAuthenticationInfo">threeDSRequestorPriorAuthenticationInfo.</param>
        /// <param name="acctInfo">acctInfo.</param>
        /// <param name="merchantRiskIndicator">merchantRiskIndicator.</param>
        /// <param name="threeDSExemptionIndicator">Indicates the reason you&#39;re bypassing 3D Secure authentication. Use in conjunction with &#x60;apply3DSecure&#x60;:&#x60;Disable&#x60;. You must first get permission from your acquirer to use exemptions. Using exemptions means that fraud liability, for the transaction, is shifted to you the merchant. If the card issuer does not agree with the exemption, they can return a &#39;soft decline&#39; - response code of &#x60;bankResponseCode&#x60;:&#x60;65&#x60; or &#x60;bankResponseCode&#x60;:&#x60;1A&#x60; - Opayo will automatically request for 3D Secure authentication and submit another authorisation request to the card issuer with 3D Secure authentication data. It is important that you correctly populate the required field values for the &#x60;strongCustomerAuthentication&#x60; object.   * &#x60;LowValue&#x60; &#x3D; Low Value Transaction (LVT); the transaction value must be 30 EUR or less and is permitted for a maximum of five consecutive LVTs or a maximum cumulative LVT amount can be 100 EUR. On the sixth LVT or when the cumulative LVT amount is over 100 EUR, then 3D Secure authentication must be performed. Since the cardholder could have used their LVT exemptions elsewhere on other merchants&#39; sites, you would not be able to accurately use this exemption. Only the card issuer will know if the LVT exemption counters have been reached.   * &#x60;TransactionRiskAnalysis&#x60; &#x3D; Transaction Risk Analysis (TRA); if you or your acquirer have a low number of chargebacks over a given number of transactions, the card schemes will have more trust in you and the acquirer and permit eligible merchants to bypass authentication using the TRA exemption.   * &#x60;TrustedMerchant&#x60; &#x3D; Trusted beneficiaries / merchant; you can use this exemption if the cardholder adds you to a trusted beneficiaries list. They can do this if prompted to do so by their card issuer either when they log into their bank account or during a challenge authentication flow.   * &#x60;SecureCorporatePayment&#x60; &#x3D; Secure Corporate Payments; if your client uses a secure corporate card such as a lodge corporate card or virtual card numbers, then these are exempt from 3D Secure authentication. These payments will be typically Business to Business payments (B2B), which will already have dedicated corporate processes and protocols in place. This exemption does not apply for personal corporate cards.   * &#x60;DelegatedAuthentication&#x60; &#x3D; Delegated Authentication; You can request for this exemption to not perform 3D Secure authentication again if you have already performed it. To be able to do this, you must already have undergone accreditation with the card schemes for 3D Secure authentication. This means the card schemes now trust you to perform 3D Secure authentication independently of them (the card schemes have delegated authentication to you). .</param>
        /// <param name="website">Fully qualified URL of the website this transaction came from. This field is useful if transactions can originate from more than one website.  Supplying this information will enable reporting to be performed by website..</param>
        public StrongCustomerAuthentication(string notificationURL = default, string browserIP = default, string browserAcceptHeader = default, bool browserJavascriptEnabled = false, bool browserJavaEnabled = false, string browserLanguage = default, BrowserColorDepthEnum? browserColorDepth = default, string browserScreenHeight = default, string browserScreenWidth = default, string browserTZ = default, string browserUserAgent = default, ChallengeWindowSizeEnum challengeWindowSize = default, string acctID = default, TransTypeEnum transType = default, StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo threeDSRequestorAuthenticationInfo = default, StrongCustomerAuthenticationThreeDSRequestorPriorAuthenticationInfo threeDSRequestorPriorAuthenticationInfo = default, StrongCustomerAuthenticationAcctInfo acctInfo = default, StrongCustomerAuthenticationMerchantRiskIndicator merchantRiskIndicator = default, ThreeDSExemptionIndicatorEnum? threeDSExemptionIndicator = default, string website = default)
        {
            // to ensure "notificationURL" is required (not null)
            if (notificationURL == null)
            {
                throw new ArgumentNullException("notificationURL is a required property for StrongCustomerAuthentication and cannot be null");
            }
            NotificationURL = notificationURL;
            // to ensure "browserIP" is required (not null)
            if (browserIP == null)
            {
                throw new ArgumentNullException("browserIP is a required property for StrongCustomerAuthentication and cannot be null");
            }
            BrowserIP = browserIP;
            // to ensure "browserAcceptHeader" is required (not null)
            if (browserAcceptHeader == null)
            {
                throw new ArgumentNullException("browserAcceptHeader is a required property for StrongCustomerAuthentication and cannot be null");
            }
            BrowserAcceptHeader = browserAcceptHeader;
            BrowserJavascriptEnabled = browserJavascriptEnabled;
            // to ensure "browserLanguage" is required (not null)
            if (browserLanguage == null)
            {
                throw new ArgumentNullException("browserLanguage is a required property for StrongCustomerAuthentication and cannot be null");
            }
            BrowserLanguage = browserLanguage;
            // to ensure "browserUserAgent" is required (not null)
            if (browserUserAgent == null)
            {
                throw new ArgumentNullException("browserUserAgent is a required property for StrongCustomerAuthentication and cannot be null");
            }
            BrowserUserAgent = browserUserAgent;
            ChallengeWindowSize = challengeWindowSize;
            TransType = transType;
            BrowserJavaEnabled = browserJavaEnabled;
            BrowserColorDepth = browserColorDepth;
            BrowserScreenHeight = browserScreenHeight;
            BrowserScreenWidth = browserScreenWidth;
            BrowserTZ = browserTZ;
            AcctID = acctID;
            ThreeDSRequestorAuthenticationInfo = threeDSRequestorAuthenticationInfo;
            ThreeDSRequestorPriorAuthenticationInfo = threeDSRequestorPriorAuthenticationInfo;
            AcctInfo = acctInfo;
            MerchantRiskIndicator = merchantRiskIndicator;
            ThreeDSExemptionIndicator = threeDSExemptionIndicator;
            Website = website;
        }

        /// <summary>
        /// Fully qualified URL of the system that receives the CRes message or Error Message and where your customer will be returned once they have completed their challenge. The CRes message is posted by the ACS through the Cardholder browser at the end of the challenge AND once it receives an RRes (Result Response) message from Opayo.
        /// </summary>
        /// <value>Fully qualified URL of the system that receives the CRes message or Error Message and where your customer will be returned once they have completed their challenge. The CRes message is posted by the ACS through the Cardholder browser at the end of the challenge AND once it receives an RRes (Result Response) message from Opayo.</value>
        [DataMember(Name = "notificationURL", IsRequired = true, EmitDefaultValue = true)]
        public string NotificationURL { get; set; }

        /// <summary>
        /// The IPv4 or IPv6 address of the client connecting to your server making the payment as returned by the HTTP headers. This should be a full IP address which you can obtain from your server scripts. There is no need to pad IPv4 IP addresses with leading zeros (eg 12.34.45.56 not 012.034.045.056), doing so will cause transactions to be rejected.
        /// </summary>
        /// <value>The IPv4 or IPv6 address of the client connecting to your server making the payment as returned by the HTTP headers. This should be a full IP address which you can obtain from your server scripts. There is no need to pad IPv4 IP addresses with leading zeros (eg 12.34.45.56 not 012.034.045.056), doing so will cause transactions to be rejected.</value>
        [DataMember(Name = "browserIP", IsRequired = true, EmitDefaultValue = true)]
        public string BrowserIP { get; set; }

        /// <summary>
        /// Exact content of the HTTP accept headers as sent to the 3DS Requestor from the Cardholder&#39;s browser.
        /// </summary>
        /// <value>Exact content of the HTTP accept headers as sent to the 3DS Requestor from the Cardholder&#39;s browser.</value>
        [DataMember(Name = "browserAcceptHeader", IsRequired = true, EmitDefaultValue = true)]
        public string BrowserAcceptHeader { get; set; }

        /// <summary>
        /// Boolean that represents the ability of the cardholder browser to execute JavaScript.
        /// </summary>
        /// <value>Boolean that represents the ability of the cardholder browser to execute JavaScript.</value>
        [DataMember(Name = "browserJavascriptEnabled", IsRequired = true, EmitDefaultValue = true)]
        public bool BrowserJavascriptEnabled { get; set; }

        /// <summary>
        /// Boolean that represents the ability of the cardholder browser to execute Java. Value is returned from the &#x60;navigator.javaEnabled&#x60; property. Required if &#x60;browserJavascriptEnabled&#x60; is &#x60;true&#x60;.
        /// </summary>
        /// <value>Boolean that represents the ability of the cardholder browser to execute Java. Value is returned from the &#x60;navigator.javaEnabled&#x60; property. Required if &#x60;browserJavascriptEnabled&#x60; is &#x60;true&#x60;.</value>
        [DataMember(Name = "browserJavaEnabled", EmitDefaultValue = true)]
        public bool BrowserJavaEnabled { get; set; }

        /// <summary>
        /// Value representing the browser language as defined in IETF BCP47. Returned from &#x60;navigator.language&#x60; property.
        /// </summary>
        /// <value>Value representing the browser language as defined in IETF BCP47. Returned from &#x60;navigator.language&#x60; property.</value>
        [DataMember(Name = "browserLanguage", IsRequired = true, EmitDefaultValue = true)]
        public string BrowserLanguage { get; set; }

        /// <summary>
        /// Total height of the Cardholder&#39;s screen in pixels. Value is returned from the &#x60;screen.height&#x60; property. Required if &#x60;BrowserJavascriptEnabled&#x60; is &#x60;true&#x60;.
        /// </summary>
        /// <value>Total height of the Cardholder&#39;s screen in pixels. Value is returned from the &#x60;screen.height&#x60; property. Required if &#x60;BrowserJavascriptEnabled&#x60; is &#x60;true&#x60;.</value>
        [DataMember(Name = "browserScreenHeight", EmitDefaultValue = false)]
        public string BrowserScreenHeight { get; set; }

        /// <summary>
        /// Total width of the cardholder&#39;s screen in pixels. Value is returned from the &#x60;screen.width&#x60; property. Required if &#x60;BrowserJavascriptEnabled&#x60; is &#x60;true&#x60;.
        /// </summary>
        /// <value>Total width of the cardholder&#39;s screen in pixels. Value is returned from the &#x60;screen.width&#x60; property. Required if &#x60;BrowserJavascriptEnabled&#x60; is &#x60;true&#x60;.</value>
        [DataMember(Name = "browserScreenWidth", EmitDefaultValue = false)]
        public string BrowserScreenWidth { get; set; }

        /// <summary>
        /// Time-zone offset in minutes between UTC and the Cardholder browser local time.   &#x60;Note&#x60; : The offset is positive if the local time zone is behind UTC and negative if it is ahead.    Example time zone offset values in minutes:  If UTC -5 hours (-300 minutes):  * 300  * +300  If UTC +5 hours (300 minutes):  * -300  Required if &#x60;browserJavascriptEnabled&#x60; is &#x60;true&#x60;. 
        /// </summary>
        /// <value>Time-zone offset in minutes between UTC and the Cardholder browser local time.   &#x60;Note&#x60; : The offset is positive if the local time zone is behind UTC and negative if it is ahead.    Example time zone offset values in minutes:  If UTC -5 hours (-300 minutes):  * 300  * +300  If UTC +5 hours (300 minutes):  * -300  Required if &#x60;browserJavascriptEnabled&#x60; is &#x60;true&#x60;. </value>
        [DataMember(Name = "browserTZ", EmitDefaultValue = false)]
        public string BrowserTZ { get; set; }

        /// <summary>
        /// Exact content of the HTTP user-agent header.
        /// </summary>
        /// <value>Exact content of the HTTP user-agent header.</value>
        [DataMember(Name = "browserUserAgent", IsRequired = true, EmitDefaultValue = true)]
        public string BrowserUserAgent { get; set; }

        /// <summary>
        /// The account ID, if applicable, of your customers account on your website.
        /// </summary>
        /// <value>The account ID, if applicable, of your customers account on your website.</value>
        [DataMember(Name = "acctID", EmitDefaultValue = false)]
        public string AcctID { get; set; }

        /// <summary>
        /// Gets or Sets ThreeDSRequestorAuthenticationInfo
        /// </summary>
        [DataMember(Name = "threeDSRequestorAuthenticationInfo", EmitDefaultValue = false)]
        public StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo ThreeDSRequestorAuthenticationInfo { get; set; }

        /// <summary>
        /// Gets or Sets ThreeDSRequestorPriorAuthenticationInfo
        /// </summary>
        [DataMember(Name = "threeDSRequestorPriorAuthenticationInfo", EmitDefaultValue = false)]
        public StrongCustomerAuthenticationThreeDSRequestorPriorAuthenticationInfo ThreeDSRequestorPriorAuthenticationInfo { get; set; }

        /// <summary>
        /// Gets or Sets AcctInfo
        /// </summary>
        [DataMember(Name = "acctInfo", EmitDefaultValue = false)]
        public StrongCustomerAuthenticationAcctInfo AcctInfo { get; set; }

        /// <summary>
        /// Gets or Sets MerchantRiskIndicator
        /// </summary>
        [DataMember(Name = "merchantRiskIndicator", EmitDefaultValue = false)]
        public StrongCustomerAuthenticationMerchantRiskIndicator MerchantRiskIndicator { get; set; }

        /// <summary>
        /// Fully qualified URL of the website this transaction came from. This field is useful if transactions can originate from more than one website.  Supplying this information will enable reporting to be performed by website.
        /// </summary>
        /// <value>Fully qualified URL of the website this transaction came from. This field is useful if transactions can originate from more than one website.  Supplying this information will enable reporting to be performed by website.</value>
        [DataMember(Name = "website", EmitDefaultValue = false)]
        public string Website { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StrongCustomerAuthentication {\n");
            sb.Append("  NotificationURL: ").Append(NotificationURL).Append("\n");
            sb.Append("  BrowserIP: ").Append(BrowserIP).Append("\n");
            sb.Append("  BrowserAcceptHeader: ").Append(BrowserAcceptHeader).Append("\n");
            sb.Append("  BrowserJavascriptEnabled: ").Append(BrowserJavascriptEnabled).Append("\n");
            sb.Append("  BrowserJavaEnabled: ").Append(BrowserJavaEnabled).Append("\n");
            sb.Append("  BrowserLanguage: ").Append(BrowserLanguage).Append("\n");
            sb.Append("  BrowserColorDepth: ").Append(BrowserColorDepth).Append("\n");
            sb.Append("  BrowserScreenHeight: ").Append(BrowserScreenHeight).Append("\n");
            sb.Append("  BrowserScreenWidth: ").Append(BrowserScreenWidth).Append("\n");
            sb.Append("  BrowserTZ: ").Append(BrowserTZ).Append("\n");
            sb.Append("  BrowserUserAgent: ").Append(BrowserUserAgent).Append("\n");
            sb.Append("  ChallengeWindowSize: ").Append(ChallengeWindowSize).Append("\n");
            sb.Append("  AcctID: ").Append(AcctID).Append("\n");
            sb.Append("  TransType: ").Append(TransType).Append("\n");
            sb.Append("  ThreeDSRequestorAuthenticationInfo: ").Append(ThreeDSRequestorAuthenticationInfo).Append("\n");
            sb.Append("  ThreeDSRequestorPriorAuthenticationInfo: ").Append(ThreeDSRequestorPriorAuthenticationInfo).Append("\n");
            sb.Append("  AcctInfo: ").Append(AcctInfo).Append("\n");
            sb.Append("  MerchantRiskIndicator: ").Append(MerchantRiskIndicator).Append("\n");
            sb.Append("  ThreeDSExemptionIndicator: ").Append(ThreeDSExemptionIndicator).Append("\n");
            sb.Append("  Website: ").Append(Website).Append("\n");
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
            return Equals(input as StrongCustomerAuthentication);
        }

        /// <summary>
        /// Returns true if StrongCustomerAuthentication instances are equal
        /// </summary>
        /// <param name="input">Instance of StrongCustomerAuthentication to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StrongCustomerAuthentication input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    NotificationURL == input.NotificationURL ||
                    NotificationURL != null &&
                    NotificationURL.Equals(input.NotificationURL)
                ) &&
                (
                    BrowserIP == input.BrowserIP ||
                    BrowserIP != null &&
                    BrowserIP.Equals(input.BrowserIP)
                ) &&
                (
                    BrowserAcceptHeader == input.BrowserAcceptHeader ||
                    BrowserAcceptHeader != null &&
                    BrowserAcceptHeader.Equals(input.BrowserAcceptHeader)
                ) &&
                (
                    BrowserJavascriptEnabled == input.BrowserJavascriptEnabled ||
                    BrowserJavascriptEnabled.Equals(input.BrowserJavascriptEnabled)
                ) &&
                (
                    BrowserJavaEnabled == input.BrowserJavaEnabled ||
                    BrowserJavaEnabled.Equals(input.BrowserJavaEnabled)
                ) &&
                (
                    BrowserLanguage == input.BrowserLanguage ||
                    BrowserLanguage != null &&
                    BrowserLanguage.Equals(input.BrowserLanguage)
                ) &&
                (
                    BrowserColorDepth == input.BrowserColorDepth ||
                    BrowserColorDepth.Equals(input.BrowserColorDepth)
                ) &&
                (
                    BrowserScreenHeight == input.BrowserScreenHeight ||
                    BrowserScreenHeight != null &&
                    BrowserScreenHeight.Equals(input.BrowserScreenHeight)
                ) &&
                (
                    BrowserScreenWidth == input.BrowserScreenWidth ||
                    BrowserScreenWidth != null &&
                    BrowserScreenWidth.Equals(input.BrowserScreenWidth)
                ) &&
                (
                    BrowserTZ == input.BrowserTZ ||
                    BrowserTZ != null &&
                    BrowserTZ.Equals(input.BrowserTZ)
                ) &&
                (
                    BrowserUserAgent == input.BrowserUserAgent ||
                    BrowserUserAgent != null &&
                    BrowserUserAgent.Equals(input.BrowserUserAgent)
                ) &&
                (
                    ChallengeWindowSize == input.ChallengeWindowSize ||
                    ChallengeWindowSize.Equals(input.ChallengeWindowSize)
                ) &&
                (
                    AcctID == input.AcctID ||
                    AcctID != null &&
                    AcctID.Equals(input.AcctID)
                ) &&
                (
                    TransType == input.TransType ||
                    TransType.Equals(input.TransType)
                ) &&
                (
                    ThreeDSRequestorAuthenticationInfo == input.ThreeDSRequestorAuthenticationInfo ||
                    ThreeDSRequestorAuthenticationInfo != null &&
                    ThreeDSRequestorAuthenticationInfo.Equals(input.ThreeDSRequestorAuthenticationInfo)
                ) &&
                (
                    ThreeDSRequestorPriorAuthenticationInfo == input.ThreeDSRequestorPriorAuthenticationInfo ||
                    ThreeDSRequestorPriorAuthenticationInfo != null &&
                    ThreeDSRequestorPriorAuthenticationInfo.Equals(input.ThreeDSRequestorPriorAuthenticationInfo)
                ) &&
                (
                    AcctInfo == input.AcctInfo ||
                    AcctInfo != null &&
                    AcctInfo.Equals(input.AcctInfo)
                ) &&
                (
                    MerchantRiskIndicator == input.MerchantRiskIndicator ||
                    MerchantRiskIndicator != null &&
                    MerchantRiskIndicator.Equals(input.MerchantRiskIndicator)
                ) &&
                (
                    ThreeDSExemptionIndicator == input.ThreeDSExemptionIndicator ||
                    ThreeDSExemptionIndicator.Equals(input.ThreeDSExemptionIndicator)
                ) &&
                (
                    Website == input.Website ||
                    Website != null &&
                    Website.Equals(input.Website)
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
                if (NotificationURL != null)
                {
                    hashCode = hashCode * 59 + NotificationURL.GetHashCode();
                }
                if (BrowserIP != null)
                {
                    hashCode = hashCode * 59 + BrowserIP.GetHashCode();
                }
                if (BrowserAcceptHeader != null)
                {
                    hashCode = hashCode * 59 + BrowserAcceptHeader.GetHashCode();
                }
                hashCode = hashCode * 59 + BrowserJavascriptEnabled.GetHashCode();
                hashCode = hashCode * 59 + BrowserJavaEnabled.GetHashCode();
                if (BrowserLanguage != null)
                {
                    hashCode = hashCode * 59 + BrowserLanguage.GetHashCode();
                }
                hashCode = hashCode * 59 + BrowserColorDepth.GetHashCode();
                if (BrowserScreenHeight != null)
                {
                    hashCode = hashCode * 59 + BrowserScreenHeight.GetHashCode();
                }
                if (BrowserScreenWidth != null)
                {
                    hashCode = hashCode * 59 + BrowserScreenWidth.GetHashCode();
                }
                if (BrowserTZ != null)
                {
                    hashCode = hashCode * 59 + BrowserTZ.GetHashCode();
                }
                if (BrowserUserAgent != null)
                {
                    hashCode = hashCode * 59 + BrowserUserAgent.GetHashCode();
                }
                hashCode = hashCode * 59 + ChallengeWindowSize.GetHashCode();
                if (AcctID != null)
                {
                    hashCode = hashCode * 59 + AcctID.GetHashCode();
                }
                hashCode = hashCode * 59 + TransType.GetHashCode();
                if (ThreeDSRequestorAuthenticationInfo != null)
                {
                    hashCode = hashCode * 59 + ThreeDSRequestorAuthenticationInfo.GetHashCode();
                }
                if (ThreeDSRequestorPriorAuthenticationInfo != null)
                {
                    hashCode = hashCode * 59 + ThreeDSRequestorPriorAuthenticationInfo.GetHashCode();
                }
                if (AcctInfo != null)
                {
                    hashCode = hashCode * 59 + AcctInfo.GetHashCode();
                }
                if (MerchantRiskIndicator != null)
                {
                    hashCode = hashCode * 59 + MerchantRiskIndicator.GetHashCode();
                }
                hashCode = hashCode * 59 + ThreeDSExemptionIndicator.GetHashCode();
                if (Website != null)
                {
                    hashCode = hashCode * 59 + Website.GetHashCode();
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
            // NotificationURL (string) maxLength
            if (NotificationURL != null && NotificationURL.Length > 256)
            {
                yield return new ValidationResult("Invalid value for NotificationURL, length must be less than 256.", new[] { "NotificationURL" });
            }

            // BrowserIP (string) maxLength
            if (BrowserIP != null && BrowserIP.Length > 39)
            {
                yield return new ValidationResult("Invalid value for BrowserIP, length must be less than 39.", new[] { "BrowserIP" });
            }

            // BrowserAcceptHeader (string) maxLength
            if (BrowserAcceptHeader != null && BrowserAcceptHeader.Length > 2048)
            {
                yield return new ValidationResult("Invalid value for BrowserAcceptHeader, length must be less than 2048.", new[] { "BrowserAcceptHeader" });
            }

            // BrowserAcceptHeader (string) minLength
            if (BrowserAcceptHeader != null && BrowserAcceptHeader.Length < 1)
            {
                yield return new ValidationResult("Invalid value for BrowserAcceptHeader, length must be greater than 1.", new[] { "BrowserAcceptHeader" });
            }

            // BrowserLanguage (string) maxLength
            if (BrowserLanguage != null && BrowserLanguage.Length > 8)
            {
                yield return new ValidationResult("Invalid value for BrowserLanguage, length must be less than 8.", new[] { "BrowserLanguage" });
            }

            // BrowserLanguage (string) minLength
            if (BrowserLanguage != null && BrowserLanguage.Length < 1)
            {
                yield return new ValidationResult("Invalid value for BrowserLanguage, length must be greater than 1.", new[] { "BrowserLanguage" });
            }

            // BrowserScreenHeight (string) maxLength
            if (BrowserScreenHeight != null && BrowserScreenHeight.Length > 6)
            {
                yield return new ValidationResult("Invalid value for BrowserScreenHeight, length must be less than 6.", new[] { "BrowserScreenHeight" });
            }

            // BrowserScreenHeight (string) minLength
            if (BrowserScreenHeight != null && BrowserScreenHeight.Length < 1)
            {
                yield return new ValidationResult("Invalid value for BrowserScreenHeight, length must be greater than 1.", new[] { "BrowserScreenHeight" });
            }

            // BrowserScreenWidth (string) maxLength
            if (BrowserScreenWidth != null && BrowserScreenWidth.Length > 6)
            {
                yield return new ValidationResult("Invalid value for BrowserScreenWidth, length must be less than 6.", new[] { "BrowserScreenWidth" });
            }

            // BrowserScreenWidth (string) minLength
            if (BrowserScreenWidth != null && BrowserScreenWidth.Length < 1)
            {
                yield return new ValidationResult("Invalid value for BrowserScreenWidth, length must be greater than 1.", new[] { "BrowserScreenWidth" });
            }

            // BrowserTZ (string) maxLength
            if (BrowserTZ != null && BrowserTZ.Length > 6)
            {
                yield return new ValidationResult("Invalid value for BrowserTZ, length must be less than 6.", new[] { "BrowserTZ" });
            }

            // BrowserTZ (string) minLength
            if (BrowserTZ != null && BrowserTZ.Length < 1)
            {
                yield return new ValidationResult("Invalid value for BrowserTZ, length must be greater than 1.", new[] { "BrowserTZ" });
            }

            // BrowserUserAgent (string) maxLength
            if (BrowserUserAgent != null && BrowserUserAgent.Length > 2048)
            {
                yield return new ValidationResult("Invalid value for BrowserUserAgent, length must be less than 2048.", new[] { "BrowserUserAgent" });
            }

            // BrowserUserAgent (string) minLength
            if (BrowserUserAgent != null && BrowserUserAgent.Length < 1)
            {
                yield return new ValidationResult("Invalid value for BrowserUserAgent, length must be greater than 1.", new[] { "BrowserUserAgent" });
            }

            // AcctID (string) maxLength
            if (AcctID != null && AcctID.Length > 64)
            {
                yield return new ValidationResult("Invalid value for AcctID, length must be less than 64.", new[] { "AcctID" });
            }

            // Website (string) maxLength
            if (Website != null && Website.Length > 100)
            {
                yield return new ValidationResult("Invalid value for Website, length must be less than 100.", new[] { "Website" });
            }

            yield break;
        }
    }

}
