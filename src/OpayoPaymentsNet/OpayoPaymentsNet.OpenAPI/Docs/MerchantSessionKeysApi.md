# Org.OpenAPITools.Api.MerchantSessionKeysApi

All URIs are relative to *https://pi-test.sagepay.com/api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateMsk**](MerchantSessionKeysApi.md#createmsk) | **POST** /merchant-session-keys | Create a new Merchant Session Key |
| [**MerchantSessionKeysMerchantSessionKeyGet**](MerchantSessionKeysApi.md#merchantsessionkeysmerchantsessionkeyget) | **GET** /merchant-session-keys/{merchantSessionKey} | Check Merchant Session Key validity |

<a name="createmsk"></a>
# **CreateMsk**
> MerchantSessionKeys CreateMsk (CreateMskRequest createMskRequest = null)

Create a new Merchant Session Key

When you create a `merchantSessionKey` you must specify the Opayo vendor name linked to your API [authentication credentials](#section/Authentication).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CreateMskExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://pi-test.sagepay.com/api/v1";
            // Configure HTTP basic authorization: BasicAuth
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new MerchantSessionKeysApi(config);
            var createMskRequest = new CreateMskRequest(); // CreateMskRequest | Request payload (optional) 

            try
            {
                // Create a new Merchant Session Key
                MerchantSessionKeys result = apiInstance.CreateMsk(createMskRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MerchantSessionKeysApi.CreateMsk: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateMskWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a new Merchant Session Key
    ApiResponse<MerchantSessionKeys> response = apiInstance.CreateMskWithHttpInfo(createMskRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MerchantSessionKeysApi.CreateMskWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createMskRequest** | [**CreateMskRequest**](CreateMskRequest.md) | Request payload | [optional]  |

### Return type

[**MerchantSessionKeys**](MerchantSessionKeys.md)

### Authorization

[BasicAuth](../README.md#BasicAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | A new &#x60;merchantSessionKey&#x60; has been successfully created. |  -  |
| **403** | Authentication error. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="merchantsessionkeysmerchantsessionkeyget"></a>
# **MerchantSessionKeysMerchantSessionKeyGet**
> MerchantSessionKeys MerchantSessionKeysMerchantSessionKeyGet (string merchantSessionKey)

Check Merchant Session Key validity

Supply the `merchantSessionKey` and we will check its validity and return the `expiry`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class MerchantSessionKeysMerchantSessionKeyGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://pi-test.sagepay.com/api/v1";
            // Configure HTTP basic authorization: BasicAuth
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new MerchantSessionKeysApi(config);
            var merchantSessionKey = "merchantSessionKey_example";  // string | 

            try
            {
                // Check Merchant Session Key validity
                MerchantSessionKeys result = apiInstance.MerchantSessionKeysMerchantSessionKeyGet(merchantSessionKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MerchantSessionKeysApi.MerchantSessionKeysMerchantSessionKeyGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the MerchantSessionKeysMerchantSessionKeyGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Check Merchant Session Key validity
    ApiResponse<MerchantSessionKeys> response = apiInstance.MerchantSessionKeysMerchantSessionKeyGetWithHttpInfo(merchantSessionKey);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MerchantSessionKeysApi.MerchantSessionKeysMerchantSessionKeyGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **merchantSessionKey** | **string** |  |  |

### Return type

[**MerchantSessionKeys**](MerchantSessionKeys.md)

### Authorization

[BasicAuth](../README.md#BasicAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful operation |  -  |
| **400** | Invalid ID supplied |  -  |
| **404** | The &#x60;merchantSessionKey&#x60; was not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

