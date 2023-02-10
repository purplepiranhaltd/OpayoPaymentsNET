# Org.OpenAPITools.Api.CardIdentifiersApi

All URIs are relative to *https://pi-test.sagepay.com/api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CardIdentifiersCardIdentifierDelete**](CardIdentifiersApi.md#cardidentifierscardidentifierdelete) | **DELETE** /card-identifiers/{cardIdentifier} | Remove Card Identifier |
| [**CreateCi**](CardIdentifiersApi.md#createci) | **POST** /card-identifiers | Create a new Card Identifier |
| [**LinkCi**](CardIdentifiersApi.md#linkci) | **POST** /card-identifiers/{cardIdentifier}/security-code | Link a Card Identifier |

<a name="cardidentifierscardidentifierdelete"></a>
# **CardIdentifiersCardIdentifierDelete**
> void CardIdentifiersCardIdentifierDelete (string cardIdentifier)

Remove Card Identifier

Supply the `cardIdentifier` and we will remove it from our system

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CardIdentifiersCardIdentifierDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://pi-test.sagepay.com/api/v1";
            // Configure HTTP basic authorization: BasicAuth
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new CardIdentifiersApi(config);
            var cardIdentifier = "cardIdentifier_example";  // string | 

            try
            {
                // Remove Card Identifier
                apiInstance.CardIdentifiersCardIdentifierDelete(cardIdentifier);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CardIdentifiersApi.CardIdentifiersCardIdentifierDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CardIdentifiersCardIdentifierDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Remove Card Identifier
    apiInstance.CardIdentifiersCardIdentifierDeleteWithHttpInfo(cardIdentifier);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CardIdentifiersApi.CardIdentifiersCardIdentifierDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **cardIdentifier** | **string** |  |  |

### Return type

void (empty response body)

### Authorization

[BasicAuth](../README.md#BasicAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful operation |  -  |
| **400** | Invalid cardIdentifier supplied |  -  |
| **404** | The &#x60;cardIdentifier&#x60; was not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createci"></a>
# **CreateCi**
> CardIdentifiers CreateCi (CreateCiRequest createCiRequest = null)

Create a new Card Identifier

You need to have a valid `merchantSessionKey` before you can create a `cardIdentifier`.  The merchant session key expires after 400 seconds, after which is no longer be valid. It's also one time use, which means you'll need to generate a new `merchantSessionKey` for every `cardIdentifier`.  The merchant session key will allow 3 failed attempts to generate a card identifier before it's removed. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CreateCiExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://pi-test.sagepay.com/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CardIdentifiersApi(config);
            var createCiRequest = new CreateCiRequest(); // CreateCiRequest | Request payload (optional) 

            try
            {
                // Create a new Card Identifier
                CardIdentifiers result = apiInstance.CreateCi(createCiRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CardIdentifiersApi.CreateCi: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateCiWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a new Card Identifier
    ApiResponse<CardIdentifiers> response = apiInstance.CreateCiWithHttpInfo(createCiRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CardIdentifiersApi.CreateCiWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createCiRequest** | [**CreateCiRequest**](CreateCiRequest.md) | Request payload | [optional]  |

### Return type

[**CardIdentifiers**](CardIdentifiers.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | A new &#x60;cardIdentifier&#x60; has been successfully created. |  -  |
| **403** | Authentication error. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linkci"></a>
# **LinkCi**
> void LinkCi (Guid cardIdentifier, LinkCiRequest linkCiRequest = null)

Link a Card Identifier

 If you are using a reusable card identifier and require a security code check, you will need to link the reusable card identifier with the security code. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class LinkCiExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://pi-test.sagepay.com/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CardIdentifiersApi(config);
            var cardIdentifier = "cardIdentifier_example";  // Guid | 
            var linkCiRequest = new LinkCiRequest(); // LinkCiRequest | Request payload (optional) 

            try
            {
                // Link a Card Identifier
                apiInstance.LinkCi(cardIdentifier, linkCiRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CardIdentifiersApi.LinkCi: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the LinkCiWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Link a Card Identifier
    apiInstance.LinkCiWithHttpInfo(cardIdentifier, linkCiRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CardIdentifiersApi.LinkCiWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **cardIdentifier** | **Guid** |  |  |
| **linkCiRequest** | [**LinkCiRequest**](LinkCiRequest.md) | Request payload | [optional]  |

### Return type

void (empty response body)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | The &#x60;cardIdentifier&#x60; has been successfully linked to the security code. |  -  |
| **403** | Authentication error. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

