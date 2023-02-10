# Org.OpenAPITools.Api.TransactionsApi

All URIs are relative to *https://pi-test.sagepay.com/api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateTransaction**](TransactionsApi.md#createtransaction) | **POST** /transactions | Create a Transaction |
| [**RetrieveTransaction**](TransactionsApi.md#retrievetransaction) | **GET** /transactions/{transactionId} | Retrieve a Transaction |

<a name="createtransaction"></a>
# **CreateTransaction**
> CreateTransaction201Response CreateTransaction (CreateTransactionRequest createTransactionRequest = null)

Create a Transaction

There are different request objects that can be sent, depending on the transaction type or payment method: 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CreateTransactionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://pi-test.sagepay.com/api/v1";
            // Configure HTTP basic authorization: BasicAuth
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new TransactionsApi(config);
            var createTransactionRequest = new CreateTransactionRequest(); // CreateTransactionRequest | Request payload (optional) 

            try
            {
                // Create a Transaction
                CreateTransaction201Response result = apiInstance.CreateTransaction(createTransactionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionsApi.CreateTransaction: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateTransactionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a Transaction
    ApiResponse<CreateTransaction201Response> response = apiInstance.CreateTransactionWithHttpInfo(createTransactionRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TransactionsApi.CreateTransactionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createTransactionRequest** | [**CreateTransactionRequest**](CreateTransactionRequest.md) | Request payload | [optional]  |

### Return type

[**CreateTransaction201Response**](CreateTransaction201Response.md)

### Authorization

[BasicAuth](../README.md#BasicAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | You will need to forward your customer according to the payment method or whether SCA is required |  -  |
| **201** | A new &#x60;transaction&#x60; has been created. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="retrievetransaction"></a>
# **RetrieveTransaction**
> RetrieveTransaction200Response RetrieveTransaction (string transactionId)

Retrieve a Transaction

Supply a valid `transactionId` and we will provide you with the transaction object.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class RetrieveTransactionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://pi-test.sagepay.com/api/v1";
            // Configure HTTP basic authorization: BasicAuth
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new TransactionsApi(config);
            var transactionId = "transactionId_example";  // string | 

            try
            {
                // Retrieve a Transaction
                RetrieveTransaction200Response result = apiInstance.RetrieveTransaction(transactionId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionsApi.RetrieveTransaction: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RetrieveTransactionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Retrieve a Transaction
    ApiResponse<RetrieveTransaction200Response> response = apiInstance.RetrieveTransactionWithHttpInfo(transactionId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TransactionsApi.RetrieveTransactionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **transactionId** | **string** |  |  |

### Return type

[**RetrieveTransaction200Response**](RetrieveTransaction200Response.md)

### Authorization

[BasicAuth](../README.md#BasicAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The &#x60;transaction&#x60; was retrieved successfully |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

