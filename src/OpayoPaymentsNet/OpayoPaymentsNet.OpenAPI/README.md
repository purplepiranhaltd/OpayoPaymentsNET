# Org.OpenAPITools - the C# library for the Opayo API Documentation

# Introduction

The Opayo REST API is based on [REST](http://en.wikipedia.org/wiki/Representational_state_transfer) principles. Our resource oriented URLs are only accessible via
HTTPS and are available in both our test and live environment.

We use [HTTP Authentication](#section/Authentication) and HTTP verbs for each method:

|Verb | Description                    |
|- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|
|GET  | Used for retrieving resources. |
|POST | Used for creating resources.   |

The Opayo API uses [JSON](http://en.wikipedia.org/wiki/JSON) format for both requests and responses.

We return [HTTP Response Codes](#section/Response-Codes) to indicate the success or failure of an API request, along with further information in the body.

## Environments

The Test Server is an exact copy of the Live System but without the banks attached. This means you get a true user experience but without the fear of any
money being taken from your cards during testing.

If you want to test our API without an account you can use one of our [sandbox accounts](#tag/Sandbox-Accounts).

If you would like to test our API with your own credentials you will need a Test Server account to be set up for you by the Opayo Support team. Your test
account can only be set up once you have submitted an online [Opayo application](https://applications.sagepay.com/apply).

Please ensure that you update your integration to the Live environment API endpoints and credentials before you go live.

## Getting your API credentials

Before you can start integrating with our REST API you need to get your Integration Key and Password. You can do that by following the guide below:

1. Go to MySagePay in either the [TEST](https://test.sagepay.com/mysagepay) or [LIVE](https://live.sagepay.com/mysagepay) environment and log in using the Administration log
in details that were provided to you during the setup of the account.

2. Once you are logged in as the Administrator, in the Password details section of the Administrator tab you will see an option to 'Create API credentials'.

3. To create your credentials you just have to select the tick-box labelled 'I understand that this will create new credentials and may break any existing Opayo API implementations.' and click on the 'Create API credentials' button.

4. Once you have opted to create your new credentials we will present you with the following information:

  - Environment: This specifies the environment for which the credentials apply (test or live)
  - Vendor Name: The vendor name for the account
  - Integration Key: The value for the Integration key (username)
  - Integration Password: The value for the Integration password

**When you choose to create new credentials, any previously generated credentials are immediately rendered invalid. Therefore, if you have already integrated with our REST API, you will not be able to authenticate your calls until you replace your expired credentials with the ones you just generated.**

Please store these credentials safely. If you lose them, you will need to generate a new set of credentials using the same process.

Please note that these credentials are only valid for our REST API.

# Versioning

The current version of the Opayo API is v1, as defined in the base URL.

To ensure we don't break your code, it's essential that you support the following compatible changes:

* Adding new API resources
* Adding new optional request parameters.
* Adding new response properties.
* Adding additional values to parameters or properties in requests and responses.
* Changing the length or format of existing fields and resources.

Each time we release a change which isn't backwards compatible (requires you to make a change), we will release a new version of the API.

Of course, we won't suddenly stop supporting older versions but we would advise that to make full use of new benefits, you try to use the latest version.

Read our [API changelog](#tag/API-Changelog) to learn more and keep track of any changes.


# Authentication
Requests to the Opayo API require authentication. We use [HTTP Basic authentication](https://en.wikipedia.org/wiki/Basic_access_authentication) for a simple,
yet secure method of enforcing access controls.

In order to access our protected resources you must authenticate with our API by providing us with your:

- Integration Key (Username)
- Integration Password (Password)

How to authenticate:

1. Using HTTP Basic authentication, you will need to combine into a string 'integrationKey:integrationPassword'.
1. The resulting string will have to be encoded using [Base64](https://en.wikipedia.org/wiki/Base64) encoding.
1. The encoded string will have to be included in the Authorization header.

_The only exception to the above is the [card identifier](#tag/Card-Identifiers). To create a card identifier you will need to use the Merchant Session Keys as an access token in the
Authorization request header field._

As the Opayo API is available in our test and live environments, we will provide you with different credentials for both.

Please ensure that you are using the correct credentials for each environment.

**Remember, all requests must be made over HTTPS. This is to ensure that all the sensitive customer information is protected.**

# Response Codes

As much as possible, we attempt to use appropriate HTTP status codes, as well as returning additional details to aid with error handling.

## HTTP Response Codes

The Opayo API will return appropriate HTTP status codes for every request.

| Code | Text                 | Description
|- -- -- -|- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --
| 200  | OK                   | Success! Everything worked as expected.
| 201  | Created              | Success! Everything worked as expected and a new resource has been created.
| 202  | Accepted             | The request has been accepted for processing, but the processing has not been completed.
| 204  | No Content           | The request has been successfully processed and is not returning any content.
| 400  | Bad Request          | The request could not be understood, generally a malformed body.
| 401  | Unauthorised         | Authentication credentials are missing or incorrect.
| 403  | Forbidden            | The request was formed correctly but is unsuccessful. Usually returned when a transaction request is declined or rejected.
| 404  | Not Found            | The resource does not exist.
| 405  | Method Not Allowed   | The method requested is not permitted against this resource.
| 408  | Request              | Timeout  Request timeout.
| 418  | I'm a teapot         | [https://en.wikipedia.org/wiki/418](https://en.wikipedia.org/wiki/Hyper_Text_Coffee_Pot_Control_Protocol)
| 422  | Unprocessable Entity | The request was well-formed but contains invalid values or missing properties.
| 500  | Server Error         | An issue occurred at Opayo.
| 502  | Bad Gateway          | An issue occurred at Opayo.

## Opayo Error Codes

As well as returning the HTTP response code, the Opayo API will, when possible, return more detail about the error in the body. This will contain the properties `code` and `description` in JSON format.

When the HTTP response code is `422`, `property` and `clientMessage` fields are also returned, identifying which specific property the error relates to and a user-friendly message. When multiple `422` errors are detected these will be returned in an `errors` array.

Below is a complete list of Opayo errors.

| HTTP   | Code | Description
|- -- -- -- -|- -- -- -|- -- -- -- -- -- --
| `400 ` | 1000 | Incorrect request format
| `401 ` | 1001 | Authentication values are missing
| `401 ` | 1002 | Authentication failed
| `422 ` | 1003 | Missing mandatory field
| `422 ` | 1004 | Invalid length
| `422 ` | 1005 | Contains invalid characters
| `404 ` | 1006 | Merchant Session Keys not found
| `422 ` | 1007 | The card number has failed our validity checks and is invalid
| `422 ` | 1008 | The card is not supported
| `422 ` | 1009 | Contains invalid value
| `422 ` | 1010 | Currency does not exist
| `422 ` | 1011 | Merchant Session Keys or card identifier invalid
| `404 ` | 1012 | Transaction not found
| `403 ` | 1013 | Transaction type not supported
| `403 ` | 1014 | Transaction status not applicable
| `422 ` | 1015 | The request entity was empty
| `422 ` | 1016 | This parameter requires an integer
| `403 ` | 1017 | Operation not allowed for this transaction
| `403 ` | 1018 | This refund amount will exceed the amount of the original transaction
| `404 ` | 1019 | Transaction instructions not found
| `422 ` | 1020 | Unable to save a card identifier that is already reusable
| `403 ` | 1021 | This release amount will exceed the amount of the original transaction
| `408 ` | 9998 | Request timeout
| `500 ` | 9999 | An internal error occurred at Opayo

### Example JSON

```JSON
{
   \"errors\":[
      {
         \"code\": \"1005\",
         \"property\": \"cardDetails.cardholderName\",
         \"description\": \"Contains invalid characters\",
         \"clientMessage\": \"The cardholder name contains invalid characters\"
      },
      {
         \"code\": \"1004\",
         \"property\": \"cardDetails.cardholderName\",
         \"description\": \"Invalid length\",
         \"clientMessage\": \"The cardholder name is too long\"
      },
      {
         \"code\": \"1003\",
         \"property\": \"cardDetails.cardNumber\",
         \"description\": \"Missing mandatory field\",
         \"clientMessage\": \"The card number is required\"
      },
      {
         \"code\": \"1005\",
         \"property\": \"cardDetails.expiryDate\",
         \"description\": \"Contains invalid characters\",
         \"clientMessage\": \"The expiry date has to be in MMYY format\"
      }
   ]
}
```

### Transaction Error Codes

During transaction registration you may receive HTTP 422 errors with a code and description not mentioned in the table above.

To get help with our terminology and those error codes you can visit [our website](https://www.opayo.co.uk/support/error-codes) and type the relevant error code there.


This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 1.0.0
- SDK version: 1.0.0
- Build package: org.openapitools.codegen.languages.CSharpNetCoreClientCodegen

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET Core >=1.0
- .NET Framework >=4.6
- Mono/Xamarin >=vNext

<a name="dependencies"></a>
## Dependencies

- [RestSharp](https://www.nuget.org/packages/RestSharp) - 106.13.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 13.0.2 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742).
NOTE: RestSharp for .Net Core creates a new socket for each api call, which can lead to a socket exhaustion problem. See [RestSharp#1406](https://github.com/restsharp/RestSharp/issues/1406).

<a name="installation"></a>
## Installation
Generate the DLL using your preferred tool (e.g. `dotnet build`)

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;
```
<a name="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

<a name="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.BasePath = "https://pi-test.sagepay.com/api/v1";
            // Configure HTTP basic authorization: BasicAuth
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new ApplePaySessionApi(config);
            var createAPSessionRequest = new CreateAPSessionRequest(); // CreateAPSessionRequest | Request payload (optional) 

            try
            {
                // Create an Apple Pay Session
                ApplePaySession result = apiInstance.CreateAPSession(createAPSessionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ApplePaySessionApi.CreateAPSession: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://pi-test.sagepay.com/api/v1*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*ApplePaySessionApi* | [**CreateAPSession**](docs\ApplePaySessionApi.md#createapsession) | **POST** /apple-pay-session | Create an Apple Pay Session
*CardIdentifiersApi* | [**CardIdentifiersCardIdentifierDelete**](docs\CardIdentifiersApi.md#cardidentifierscardidentifierdelete) | **DELETE** /card-identifiers/{cardIdentifier} | Remove Card Identifier
*CardIdentifiersApi* | [**CreateCi**](docs\CardIdentifiersApi.md#createci) | **POST** /card-identifiers | Create a new Card Identifier
*CardIdentifiersApi* | [**LinkCi**](docs\CardIdentifiersApi.md#linkci) | **POST** /card-identifiers/{cardIdentifier}/security-code | Link a Card Identifier
*Class3DSecureApi* | [**Create3DSecurev2**](docs\Class3DSecureApi.md#create3dsecurev2) | **POST** /transactions/{transactionId}/3d-secure-challenge | Create a 3D Secure challenge response (3DSv2)
*InstructionsApi* | [**CreateInstruction**](docs\InstructionsApi.md#createinstruction) | **POST** /transactions/{transactionId}/instructions | Create an Instruction
*MerchantSessionKeysApi* | [**CreateMsk**](docs\MerchantSessionKeysApi.md#createmsk) | **POST** /merchant-session-keys | Create a new Merchant Session Key
*MerchantSessionKeysApi* | [**MerchantSessionKeysMerchantSessionKeyGet**](docs\MerchantSessionKeysApi.md#merchantsessionkeysmerchantsessionkeyget) | **GET** /merchant-session-keys/{merchantSessionKey} | Check Merchant Session Key validity
*TransactionsApi* | [**CreateTransaction**](docs\TransactionsApi.md#createtransaction) | **POST** /transactions | Create a Transaction
*TransactionsApi* | [**RetrieveTransaction**](docs\TransactionsApi.md#retrievetransaction) | **GET** /transactions/{transactionId} | Retrieve a Transaction


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.Abort](docs\Abort.md)
 - [Model.Amount](docs\Amount.md)
 - [Model.ApplePaySession](docs\ApplePaySession.md)
 - [Model.Applepay](docs\Applepay.md)
 - [Model.Authenticate](docs\Authenticate.md)
 - [Model.Authorise](docs\Authorise.md)
 - [Model.AvsCvcCheck](docs\AvsCvcCheck.md)
 - [Model.BillingAddress](docs\BillingAddress.md)
 - [Model.Cancel](docs\Cancel.md)
 - [Model.Card](docs\Card.md)
 - [Model.CardAdditionalDeclineDetail](docs\CardAdditionalDeclineDetail.md)
 - [Model.CardDetails](docs\CardDetails.md)
 - [Model.CardIdentifiers](docs\CardIdentifiers.md)
 - [Model.Create3DSecurev2Request](docs\Create3DSecurev2Request.md)
 - [Model.CreateAPSessionRequest](docs\CreateAPSessionRequest.md)
 - [Model.CreateCiRequest](docs\CreateCiRequest.md)
 - [Model.CreateInstruction201Response](docs\CreateInstruction201Response.md)
 - [Model.CreateInstructionRequest](docs\CreateInstructionRequest.md)
 - [Model.CreateMskRequest](docs\CreateMskRequest.md)
 - [Model.CreateTransaction201Response](docs\CreateTransaction201Response.md)
 - [Model.CreateTransaction202Response](docs\CreateTransaction202Response.md)
 - [Model.CreateTransactionRequest](docs\CreateTransactionRequest.md)
 - [Model.CredentialType](docs\CredentialType.md)
 - [Model.CredentialTypeRepeat](docs\CredentialTypeRepeat.md)
 - [Model.Deferred](docs\Deferred.md)
 - [Model.FiRecipient](docs\FiRecipient.md)
 - [Model.LinkCiRequest](docs\LinkCiRequest.md)
 - [Model.MerchantSessionKeys](docs\MerchantSessionKeys.md)
 - [Model.Model3DSecure](docs\Model3DSecure.md)
 - [Model.Model3DSv2](docs\Model3DSv2.md)
 - [Model.PayPal](docs\PayPal.md)
 - [Model.PayPalPaypal](docs\PayPalPaypal.md)
 - [Model.Payment](docs\Payment.md)
 - [Model.PaymentMethod](docs\PaymentMethod.md)
 - [Model.PaymentPaymentMethod](docs\PaymentPaymentMethod.md)
 - [Model.Paypal](docs\Paypal.md)
 - [Model.PaypalPaymentMethod](docs\PaypalPaymentMethod.md)
 - [Model.PaypalPaymentMethodPaypal](docs\PaypalPaymentMethodPaypal.md)
 - [Model.PaypalShippingDetails](docs\PaypalShippingDetails.md)
 - [Model.Refund](docs\Refund.md)
 - [Model.Release](docs\Release.md)
 - [Model.Repeat](docs\Repeat.md)
 - [Model.RetrieveTransaction200Response](docs\RetrieveTransaction200Response.md)
 - [Model.RetrieveTransaction200ResponsePaymentMethod](docs\RetrieveTransaction200ResponsePaymentMethod.md)
 - [Model.RetrieveTransaction200ResponsePaymentMethodCard](docs\RetrieveTransaction200ResponsePaymentMethodCard.md)
 - [Model.ShippingDetails](docs\ShippingDetails.md)
 - [Model.StrongCustomerAuthentication](docs\StrongCustomerAuthentication.md)
 - [Model.StrongCustomerAuthenticationAcctInfo](docs\StrongCustomerAuthenticationAcctInfo.md)
 - [Model.StrongCustomerAuthenticationMerchantRiskIndicator](docs\StrongCustomerAuthenticationMerchantRiskIndicator.md)
 - [Model.StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo](docs\StrongCustomerAuthenticationThreeDSRequestorAuthenticationInfo.md)
 - [Model.StrongCustomerAuthenticationThreeDSRequestorPriorAuthenticationInfo](docs\StrongCustomerAuthenticationThreeDSRequestorPriorAuthenticationInfo.md)
 - [Model.Void](docs\Void.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="BasicAuth"></a>
### BasicAuth

- **Type**: HTTP basic authentication

<a name="BearerAuth"></a>
### BearerAuth

- **Type**: Bearer Authentication

