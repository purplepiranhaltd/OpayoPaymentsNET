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
    /// Merchant&#39;s assessment of the level of fraud risk for the specific authentication for both the cardholder and the authentication being conducted. E.g. Are you shipping goods to the cardholder&#39;s billing address, is this a first-time order or reorder.
    /// </summary>
    [DataContract(Name = "strongCustomerAuthentication_merchantRiskIndicator")]
    public partial class StrongCustomerAuthenticationMerchantRiskIndicator : IEquatable<StrongCustomerAuthenticationMerchantRiskIndicator>, IValidatableObject
    {
        /// <summary>
        /// Indicates the merchandise delivery timeframe.   * &#x60;ElectronicDelivery&#x60; &#x3D; Electronic Delivery   * &#x60;SameDayShipping&#x60; &#x3D; Same day shipping   * &#x60;OvernightShipping&#x60; &#x3D; Overnight shipping   * &#x60;TwoDayOrMoreShipping&#x60; &#x3D; Two-day or more shipping 
        /// </summary>
        /// <value>Indicates the merchandise delivery timeframe.   * &#x60;ElectronicDelivery&#x60; &#x3D; Electronic Delivery   * &#x60;SameDayShipping&#x60; &#x3D; Same day shipping   * &#x60;OvernightShipping&#x60; &#x3D; Overnight shipping   * &#x60;TwoDayOrMoreShipping&#x60; &#x3D; Two-day or more shipping </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeliveryTimeframeEnum
        {
            /// <summary>
            /// Enum ElectronicDelivery for value: ElectronicDelivery
            /// </summary>
            [EnumMember(Value = "ElectronicDelivery")]
            ElectronicDelivery = 1,

            /// <summary>
            /// Enum SameDayShipping for value: SameDayShipping
            /// </summary>
            [EnumMember(Value = "SameDayShipping")]
            SameDayShipping = 2,

            /// <summary>
            /// Enum OvernightShipping for value: OvernightShipping
            /// </summary>
            [EnumMember(Value = "OvernightShipping")]
            OvernightShipping = 3,

            /// <summary>
            /// Enum TwoDayOrMoreShipping for value: TwoDayOrMoreShipping
            /// </summary>
            [EnumMember(Value = "TwoDayOrMoreShipping")]
            TwoDayOrMoreShipping = 4

        }


        /// <summary>
        /// Indicates the merchandise delivery timeframe.   * &#x60;ElectronicDelivery&#x60; &#x3D; Electronic Delivery   * &#x60;SameDayShipping&#x60; &#x3D; Same day shipping   * &#x60;OvernightShipping&#x60; &#x3D; Overnight shipping   * &#x60;TwoDayOrMoreShipping&#x60; &#x3D; Two-day or more shipping 
        /// </summary>
        /// <value>Indicates the merchandise delivery timeframe.   * &#x60;ElectronicDelivery&#x60; &#x3D; Electronic Delivery   * &#x60;SameDayShipping&#x60; &#x3D; Same day shipping   * &#x60;OvernightShipping&#x60; &#x3D; Overnight shipping   * &#x60;TwoDayOrMoreShipping&#x60; &#x3D; Two-day or more shipping </value>
        [DataMember(Name = "deliveryTimeframe", EmitDefaultValue = false)]
        public DeliveryTimeframeEnum? DeliveryTimeframe { get; set; }
        /// <summary>
        /// Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.   * &#x60;MerchandiseAvailable&#x60; &#x3D; Merchandise available   * &#x60;FutureAvailability&#x60; &#x3D; Future availability 
        /// </summary>
        /// <value>Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.   * &#x60;MerchandiseAvailable&#x60; &#x3D; Merchandise available   * &#x60;FutureAvailability&#x60; &#x3D; Future availability </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PreOrderPurchaseIndEnum
        {
            /// <summary>
            /// Enum MerchandiseAvailable for value: MerchandiseAvailable
            /// </summary>
            [EnumMember(Value = "MerchandiseAvailable")]
            MerchandiseAvailable = 1,

            /// <summary>
            /// Enum FutureAvailability for value: FutureAvailability
            /// </summary>
            [EnumMember(Value = "FutureAvailability")]
            FutureAvailability = 2

        }


        /// <summary>
        /// Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.   * &#x60;MerchandiseAvailable&#x60; &#x3D; Merchandise available   * &#x60;FutureAvailability&#x60; &#x3D; Future availability 
        /// </summary>
        /// <value>Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.   * &#x60;MerchandiseAvailable&#x60; &#x3D; Merchandise available   * &#x60;FutureAvailability&#x60; &#x3D; Future availability </value>
        [DataMember(Name = "preOrderPurchaseInd", EmitDefaultValue = false)]
        public PreOrderPurchaseIndEnum? PreOrderPurchaseInd { get; set; }
        /// <summary>
        /// Indicates whether the cardholder is reordering previously purchased merchandise.   * &#x60;FirstTimeOrdered&#x60; &#x3D; First time ordered   * &#x60;Reordered&#x60; &#x3D; Reordered 
        /// </summary>
        /// <value>Indicates whether the cardholder is reordering previously purchased merchandise.   * &#x60;FirstTimeOrdered&#x60; &#x3D; First time ordered   * &#x60;Reordered&#x60; &#x3D; Reordered </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ReorderItemsIndEnum
        {
            /// <summary>
            /// Enum FirstTimeOrdered for value: FirstTimeOrdered
            /// </summary>
            [EnumMember(Value = "FirstTimeOrdered")]
            FirstTimeOrdered = 1,

            /// <summary>
            /// Enum Reordered for value: Reordered
            /// </summary>
            [EnumMember(Value = "Reordered")]
            Reordered = 2

        }


        /// <summary>
        /// Indicates whether the cardholder is reordering previously purchased merchandise.   * &#x60;FirstTimeOrdered&#x60; &#x3D; First time ordered   * &#x60;Reordered&#x60; &#x3D; Reordered 
        /// </summary>
        /// <value>Indicates whether the cardholder is reordering previously purchased merchandise.   * &#x60;FirstTimeOrdered&#x60; &#x3D; First time ordered   * &#x60;Reordered&#x60; &#x3D; Reordered </value>
        [DataMember(Name = "reorderItemsInd", EmitDefaultValue = false)]
        public ReorderItemsIndEnum? ReorderItemsInd { get; set; }
        /// <summary>
        /// Indicates shipping method chosen for the transaction. You must choose the Shipping Indicator code that most accurately describes the cardholder&#39;s specific transaction, not their general business.  If one or more items are included in the sale, use the Shipping Indicator code for the physical goods, or if all digital goods, use the Shipping Indicator code that describes the most expensive item.   * &#x60;CardholderBillingAddress&#x60; &#x3D; Ship to cardholder&#39;s billing address   * &#x60;OtherVerifiedAddress&#x60; &#x3D; Ship to another verified address on file with merchant   * &#x60;DifferentToCardholderBillingAddress&#x60; &#x3D; Ship to address that is different than the cardholder&#39;s billing address   * &#x60;LocalPickUp&#x60; &#x3D; &#39;Ship to Store�? / Pick-up at local store (Store address shall be populated in shipping address fields)   * &#x60;DigitalGoods&#x60; &#x3D; Digital goods (includes online services, electronic gift cards and redemption codes)   * &#x60;NonShippedTickets&#x60; &#x3D; Travel and Event tickets, not shipped   * &#x60;Other&#x60; &#x3D; Other (for example, Gaming, digital services not shipped, e-media subscriptions, etc.) 
        /// </summary>
        /// <value>Indicates shipping method chosen for the transaction. You must choose the Shipping Indicator code that most accurately describes the cardholder&#39;s specific transaction, not their general business.  If one or more items are included in the sale, use the Shipping Indicator code for the physical goods, or if all digital goods, use the Shipping Indicator code that describes the most expensive item.   * &#x60;CardholderBillingAddress&#x60; &#x3D; Ship to cardholder&#39;s billing address   * &#x60;OtherVerifiedAddress&#x60; &#x3D; Ship to another verified address on file with merchant   * &#x60;DifferentToCardholderBillingAddress&#x60; &#x3D; Ship to address that is different than the cardholder&#39;s billing address   * &#x60;LocalPickUp&#x60; &#x3D; &#39;Ship to Store�? / Pick-up at local store (Store address shall be populated in shipping address fields)   * &#x60;DigitalGoods&#x60; &#x3D; Digital goods (includes online services, electronic gift cards and redemption codes)   * &#x60;NonShippedTickets&#x60; &#x3D; Travel and Event tickets, not shipped   * &#x60;Other&#x60; &#x3D; Other (for example, Gaming, digital services not shipped, e-media subscriptions, etc.) </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ShipIndicatorEnum
        {
            /// <summary>
            /// Enum CardholderBillingAddress for value: CardholderBillingAddress
            /// </summary>
            [EnumMember(Value = "CardholderBillingAddress")]
            CardholderBillingAddress = 1,

            /// <summary>
            /// Enum OtherVerifiedAddress for value: OtherVerifiedAddress
            /// </summary>
            [EnumMember(Value = "OtherVerifiedAddress")]
            OtherVerifiedAddress = 2,

            /// <summary>
            /// Enum DifferentToCardholderBillingAddress for value: DifferentToCardholderBillingAddress
            /// </summary>
            [EnumMember(Value = "DifferentToCardholderBillingAddress")]
            DifferentToCardholderBillingAddress = 3,

            /// <summary>
            /// Enum LocalPickUp for value: LocalPickUp
            /// </summary>
            [EnumMember(Value = "LocalPickUp")]
            LocalPickUp = 4,

            /// <summary>
            /// Enum DigitalGoods for value: DigitalGoods
            /// </summary>
            [EnumMember(Value = "DigitalGoods")]
            DigitalGoods = 5,

            /// <summary>
            /// Enum NonShippedTickets for value: NonShippedTickets
            /// </summary>
            [EnumMember(Value = "NonShippedTickets")]
            NonShippedTickets = 6,

            /// <summary>
            /// Enum Other for value: Other
            /// </summary>
            [EnumMember(Value = "Other")]
            Other = 7

        }


        /// <summary>
        /// Indicates shipping method chosen for the transaction. You must choose the Shipping Indicator code that most accurately describes the cardholder&#39;s specific transaction, not their general business.  If one or more items are included in the sale, use the Shipping Indicator code for the physical goods, or if all digital goods, use the Shipping Indicator code that describes the most expensive item.   * &#x60;CardholderBillingAddress&#x60; &#x3D; Ship to cardholder&#39;s billing address   * &#x60;OtherVerifiedAddress&#x60; &#x3D; Ship to another verified address on file with merchant   * &#x60;DifferentToCardholderBillingAddress&#x60; &#x3D; Ship to address that is different than the cardholder&#39;s billing address   * &#x60;LocalPickUp&#x60; &#x3D; &#39;Ship to Store�? / Pick-up at local store (Store address shall be populated in shipping address fields)   * &#x60;DigitalGoods&#x60; &#x3D; Digital goods (includes online services, electronic gift cards and redemption codes)   * &#x60;NonShippedTickets&#x60; &#x3D; Travel and Event tickets, not shipped   * &#x60;Other&#x60; &#x3D; Other (for example, Gaming, digital services not shipped, e-media subscriptions, etc.) 
        /// </summary>
        /// <value>Indicates shipping method chosen for the transaction. You must choose the Shipping Indicator code that most accurately describes the cardholder&#39;s specific transaction, not their general business.  If one or more items are included in the sale, use the Shipping Indicator code for the physical goods, or if all digital goods, use the Shipping Indicator code that describes the most expensive item.   * &#x60;CardholderBillingAddress&#x60; &#x3D; Ship to cardholder&#39;s billing address   * &#x60;OtherVerifiedAddress&#x60; &#x3D; Ship to another verified address on file with merchant   * &#x60;DifferentToCardholderBillingAddress&#x60; &#x3D; Ship to address that is different than the cardholder&#39;s billing address   * &#x60;LocalPickUp&#x60; &#x3D; &#39;Ship to Store�? / Pick-up at local store (Store address shall be populated in shipping address fields)   * &#x60;DigitalGoods&#x60; &#x3D; Digital goods (includes online services, electronic gift cards and redemption codes)   * &#x60;NonShippedTickets&#x60; &#x3D; Travel and Event tickets, not shipped   * &#x60;Other&#x60; &#x3D; Other (for example, Gaming, digital services not shipped, e-media subscriptions, etc.) </value>
        [DataMember(Name = "shipIndicator", EmitDefaultValue = false)]
        public ShipIndicatorEnum? ShipIndicator { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StrongCustomerAuthenticationMerchantRiskIndicator" /> class.
        /// </summary>
        /// <param name="deliveryEmailAddress">For Electronic delivery, the email address to which the merchandise was delivered..</param>
        /// <param name="deliveryTimeframe">Indicates the merchandise delivery timeframe.   * &#x60;ElectronicDelivery&#x60; &#x3D; Electronic Delivery   * &#x60;SameDayShipping&#x60; &#x3D; Same day shipping   * &#x60;OvernightShipping&#x60; &#x3D; Overnight shipping   * &#x60;TwoDayOrMoreShipping&#x60; &#x3D; Two-day or more shipping .</param>
        /// <param name="giftCardAmount">For prepaid or gift card purchase, the purchase amount total of prepaid or gift card(s) in major units (for example, GBP 123.45 is 123)..</param>
        /// <param name="giftCardCount">For prepaid or gift card purchase, total count of individual prepaid or gift cards/codes purchased..</param>
        /// <param name="preOrderDate">For a pre-ordered purchase, the expected date that the merchandise will be available..</param>
        /// <param name="preOrderPurchaseInd">Indicates whether Cardholder is placing an order for merchandise with a future availability or release date.   * &#x60;MerchandiseAvailable&#x60; &#x3D; Merchandise available   * &#x60;FutureAvailability&#x60; &#x3D; Future availability .</param>
        /// <param name="reorderItemsInd">Indicates whether the cardholder is reordering previously purchased merchandise.   * &#x60;FirstTimeOrdered&#x60; &#x3D; First time ordered   * &#x60;Reordered&#x60; &#x3D; Reordered .</param>
        /// <param name="shipIndicator">Indicates shipping method chosen for the transaction. You must choose the Shipping Indicator code that most accurately describes the cardholder&#39;s specific transaction, not their general business.  If one or more items are included in the sale, use the Shipping Indicator code for the physical goods, or if all digital goods, use the Shipping Indicator code that describes the most expensive item.   * &#x60;CardholderBillingAddress&#x60; &#x3D; Ship to cardholder&#39;s billing address   * &#x60;OtherVerifiedAddress&#x60; &#x3D; Ship to another verified address on file with merchant   * &#x60;DifferentToCardholderBillingAddress&#x60; &#x3D; Ship to address that is different than the cardholder&#39;s billing address   * &#x60;LocalPickUp&#x60; &#x3D; &#39;Ship to Store�? / Pick-up at local store (Store address shall be populated in shipping address fields)   * &#x60;DigitalGoods&#x60; &#x3D; Digital goods (includes online services, electronic gift cards and redemption codes)   * &#x60;NonShippedTickets&#x60; &#x3D; Travel and Event tickets, not shipped   * &#x60;Other&#x60; &#x3D; Other (for example, Gaming, digital services not shipped, e-media subscriptions, etc.) .</param>
        public StrongCustomerAuthenticationMerchantRiskIndicator(string deliveryEmailAddress = default, DeliveryTimeframeEnum? deliveryTimeframe = default, string giftCardAmount = default, string giftCardCount = default, string preOrderDate = default, PreOrderPurchaseIndEnum? preOrderPurchaseInd = default, ReorderItemsIndEnum? reorderItemsInd = default, ShipIndicatorEnum? shipIndicator = default)
        {
            DeliveryEmailAddress = deliveryEmailAddress;
            DeliveryTimeframe = deliveryTimeframe;
            GiftCardAmount = giftCardAmount;
            GiftCardCount = giftCardCount;
            PreOrderDate = preOrderDate;
            PreOrderPurchaseInd = preOrderPurchaseInd;
            ReorderItemsInd = reorderItemsInd;
            ShipIndicator = shipIndicator;
        }

        /// <summary>
        /// For Electronic delivery, the email address to which the merchandise was delivered.
        /// </summary>
        /// <value>For Electronic delivery, the email address to which the merchandise was delivered.</value>
        [DataMember(Name = "deliveryEmailAddress", EmitDefaultValue = false)]
        public string DeliveryEmailAddress { get; set; }

        /// <summary>
        /// For prepaid or gift card purchase, the purchase amount total of prepaid or gift card(s) in major units (for example, GBP 123.45 is 123).
        /// </summary>
        /// <value>For prepaid or gift card purchase, the purchase amount total of prepaid or gift card(s) in major units (for example, GBP 123.45 is 123).</value>
        [DataMember(Name = "giftCardAmount", EmitDefaultValue = false)]
        public string GiftCardAmount { get; set; }

        /// <summary>
        /// For prepaid or gift card purchase, total count of individual prepaid or gift cards/codes purchased.
        /// </summary>
        /// <value>For prepaid or gift card purchase, total count of individual prepaid or gift cards/codes purchased.</value>
        [DataMember(Name = "giftCardCount", EmitDefaultValue = false)]
        public string GiftCardCount { get; set; }

        /// <summary>
        /// For a pre-ordered purchase, the expected date that the merchandise will be available.
        /// </summary>
        /// <value>For a pre-ordered purchase, the expected date that the merchandise will be available.</value>
        [DataMember(Name = "preOrderDate", EmitDefaultValue = false)]
        public string PreOrderDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StrongCustomerAuthenticationMerchantRiskIndicator {\n");
            sb.Append("  DeliveryEmailAddress: ").Append(DeliveryEmailAddress).Append("\n");
            sb.Append("  DeliveryTimeframe: ").Append(DeliveryTimeframe).Append("\n");
            sb.Append("  GiftCardAmount: ").Append(GiftCardAmount).Append("\n");
            sb.Append("  GiftCardCount: ").Append(GiftCardCount).Append("\n");
            sb.Append("  PreOrderDate: ").Append(PreOrderDate).Append("\n");
            sb.Append("  PreOrderPurchaseInd: ").Append(PreOrderPurchaseInd).Append("\n");
            sb.Append("  ReorderItemsInd: ").Append(ReorderItemsInd).Append("\n");
            sb.Append("  ShipIndicator: ").Append(ShipIndicator).Append("\n");
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
            return Equals(input as StrongCustomerAuthenticationMerchantRiskIndicator);
        }

        /// <summary>
        /// Returns true if StrongCustomerAuthenticationMerchantRiskIndicator instances are equal
        /// </summary>
        /// <param name="input">Instance of StrongCustomerAuthenticationMerchantRiskIndicator to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StrongCustomerAuthenticationMerchantRiskIndicator input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    DeliveryEmailAddress == input.DeliveryEmailAddress ||
                    DeliveryEmailAddress != null &&
                    DeliveryEmailAddress.Equals(input.DeliveryEmailAddress)
                ) &&
                (
                    DeliveryTimeframe == input.DeliveryTimeframe ||
                    DeliveryTimeframe.Equals(input.DeliveryTimeframe)
                ) &&
                (
                    GiftCardAmount == input.GiftCardAmount ||
                    GiftCardAmount != null &&
                    GiftCardAmount.Equals(input.GiftCardAmount)
                ) &&
                (
                    GiftCardCount == input.GiftCardCount ||
                    GiftCardCount != null &&
                    GiftCardCount.Equals(input.GiftCardCount)
                ) &&
                (
                    PreOrderDate == input.PreOrderDate ||
                    PreOrderDate != null &&
                    PreOrderDate.Equals(input.PreOrderDate)
                ) &&
                (
                    PreOrderPurchaseInd == input.PreOrderPurchaseInd ||
                    PreOrderPurchaseInd.Equals(input.PreOrderPurchaseInd)
                ) &&
                (
                    ReorderItemsInd == input.ReorderItemsInd ||
                    ReorderItemsInd.Equals(input.ReorderItemsInd)
                ) &&
                (
                    ShipIndicator == input.ShipIndicator ||
                    ShipIndicator.Equals(input.ShipIndicator)
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
                if (DeliveryEmailAddress != null)
                {
                    hashCode = hashCode * 59 + DeliveryEmailAddress.GetHashCode();
                }
                hashCode = hashCode * 59 + DeliveryTimeframe.GetHashCode();
                if (GiftCardAmount != null)
                {
                    hashCode = hashCode * 59 + GiftCardAmount.GetHashCode();
                }
                if (GiftCardCount != null)
                {
                    hashCode = hashCode * 59 + GiftCardCount.GetHashCode();
                }
                if (PreOrderDate != null)
                {
                    hashCode = hashCode * 59 + PreOrderDate.GetHashCode();
                }
                hashCode = hashCode * 59 + PreOrderPurchaseInd.GetHashCode();
                hashCode = hashCode * 59 + ReorderItemsInd.GetHashCode();
                hashCode = hashCode * 59 + ShipIndicator.GetHashCode();
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
            // DeliveryEmailAddress (string) maxLength
            if (DeliveryEmailAddress != null && DeliveryEmailAddress.Length > 50)
            {
                yield return new ValidationResult("Invalid value for DeliveryEmailAddress, length must be less than 50.", new[] { "DeliveryEmailAddress" });
            }

            // GiftCardAmount (string) maxLength
            if (GiftCardAmount != null && GiftCardAmount.Length > 15)
            {
                yield return new ValidationResult("Invalid value for GiftCardAmount, length must be less than 15.", new[] { "GiftCardAmount" });
            }

            // GiftCardCount (string) maxLength
            if (GiftCardCount != null && GiftCardCount.Length > 2)
            {
                yield return new ValidationResult("Invalid value for GiftCardCount, length must be less than 2.", new[] { "GiftCardCount" });
            }

            // PreOrderDate (string) maxLength
            if (PreOrderDate != null && PreOrderDate.Length > 8)
            {
                yield return new ValidationResult("Invalid value for PreOrderDate, length must be less than 8.", new[] { "PreOrderDate" });
            }

            // PreOrderDate (string) minLength
            if (PreOrderDate != null && PreOrderDate.Length < 8)
            {
                yield return new ValidationResult("Invalid value for PreOrderDate, length must be greater than 8.", new[] { "PreOrderDate" });
            }

            yield break;
        }
    }

}
