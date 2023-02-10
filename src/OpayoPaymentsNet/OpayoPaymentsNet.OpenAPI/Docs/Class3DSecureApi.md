# Org.OpenAPITools.Api.Class3DSecureApi

All URIs are relative to *https://pi-test.sagepay.com/api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**Create3DSecurev2**](Class3DSecureApi.md#create3dsecurev2) | **POST** /transactions/{transactionId}/3d-secure-challenge | Create a 3D Secure challenge response (3DSv2) |

<a name="create3dsecurev2"></a>
# **Create3DSecurev2**
> Card Create3DSecurev2 (Guid transactionId, Create3DSecurev2Request create3DSecurev2Request = null)

Create a 3D Secure challenge response (3DSv2)

We will create and return the 3D Secure object (containing the 3D result) within the transaction object.   **Please note that the `cRes` for a transaction has to be provided within 20 minutes from our initial response.** 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class Create3DSecurev2Example
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://pi-test.sagepay.com/api/v1";
            // Configure HTTP basic authorization: BasicAuth
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new Class3DSecureApi(config);
            var transactionId = "transactionId_example";  // Guid | 
            var create3DSecurev2Request = new Create3DSecurev2Request(); // Create3DSecurev2Request | Request payload (optional) 

            try
            {
                // Create a 3D Secure challenge response (3DSv2)
                Card result = apiInstance.Create3DSecurev2(transactionId, create3DSecurev2Request);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling Class3DSecureApi.Create3DSecurev2: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the Create3DSecurev2WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a 3D Secure challenge response (3DSv2)
    ApiResponse<Card> response = apiInstance.Create3DSecurev2WithHttpInfo(transactionId, create3DSecurev2Request);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling Class3DSecureApi.Create3DSecurev2WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **transactionId** | **Guid** |  |  |
| **create3DSecurev2Request** | [**Create3DSecurev2Request**](Create3DSecurev2Request.md) | Request payload | [optional]  |

### Return type

[**Card**](Card.md)

### Authorization

[BasicAuth](../README.md#BasicAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | A new &#x60;transaction&#x60; has been created with 3D Secure. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

