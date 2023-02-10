# Org.OpenAPITools.Api.ApplePaySessionApi

All URIs are relative to *https://pi-test.sagepay.com/api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateAPSession**](ApplePaySessionApi.md#createapsession) | **POST** /apple-pay-session | Create an Apple Pay Session |

<a name="createapsession"></a>
# **CreateAPSession**
> ApplePaySession CreateAPSession (CreateAPSessionRequest createAPSessionRequest = null)

Create an Apple Pay Session

When you create an Apple Pay Session you must specify the Opayo vendor name linked to your API [authentication credentials](#section/Authentication).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CreateAPSessionExample
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
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplePaySessionApi.CreateAPSession: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateAPSessionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create an Apple Pay Session
    ApiResponse<ApplePaySession> response = apiInstance.CreateAPSessionWithHttpInfo(createAPSessionRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ApplePaySessionApi.CreateAPSessionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createAPSessionRequest** | [**CreateAPSessionRequest**](CreateAPSessionRequest.md) | Request payload | [optional]  |

### Return type

[**ApplePaySession**](ApplePaySession.md)

### Authorization

[BasicAuth](../README.md#BasicAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | A new Apple Pay Session has been successfully created. |  -  |
| **403** | Authentication error. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

