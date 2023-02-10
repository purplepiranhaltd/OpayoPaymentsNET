# Org.OpenAPITools.Api.InstructionsApi

All URIs are relative to *https://pi-test.sagepay.com/api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateInstruction**](InstructionsApi.md#createinstruction) | **POST** /transactions/{transactionId}/instructions | Create an Instruction |

<a name="createinstruction"></a>
# **CreateInstruction**
> CreateInstruction201Response CreateInstruction ( UNKNOWN_PARAMETER_NAME, CreateInstructionRequest createInstructionRequest = null)

Create an Instruction

When you create an instruction you need to specify the instruction type you want to apply. E.g. to void a transaction you need to specify the `instructionType` as `void`. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CreateInstructionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://pi-test.sagepay.com/api/v1";
            // Configure HTTP basic authorization: BasicAuth
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new InstructionsApi(config);
            var UNKNOWN_PARAMETER_NAME = new (); //  | 
            var createInstructionRequest = new CreateInstructionRequest(); // CreateInstructionRequest | Request payload (optional) 

            try
            {
                // Create an Instruction
                CreateInstruction201Response result = apiInstance.CreateInstruction(UNKNOWN_PARAMETER_NAME, createInstructionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InstructionsApi.CreateInstruction: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateInstructionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create an Instruction
    ApiResponse<CreateInstruction201Response> response = apiInstance.CreateInstructionWithHttpInfo(UNKNOWN_PARAMETER_NAME, createInstructionRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InstructionsApi.CreateInstructionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **UNKNOWN_PARAMETER_NAME** | [****](.md) |  |  |
| **createInstructionRequest** | [**CreateInstructionRequest**](CreateInstructionRequest.md) | Request payload | [optional]  |

### Return type

[**CreateInstruction201Response**](CreateInstruction201Response.md)

### Authorization

[BasicAuth](../README.md#BasicAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | A new &#x60;instruction&#x60; object has been created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

