# Org.OpenAPITools.Api.SeriesApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiSeriesGet**](SeriesApi.md#apiseriesget) | **GET** /api/Series |  |
| [**ApiSeriesListStartAmountGet**](SeriesApi.md#apiseriesliststartamountget) | **GET** /api/Series/list/{start}, {amount} |  |
| [**ApiSeriesNameQuantityPost**](SeriesApi.md#apiseriesnamequantitypost) | **POST** /api/Series/{name}, {quantity} |  |
| [**ApiSeriesPost**](SeriesApi.md#apiseriespost) | **POST** /api/Series |  |

<a id="apiseriesget"></a>
# **ApiSeriesGet**
> void ApiSeriesGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiSeriesGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new SeriesApi(config);

            try
            {
                apiInstance.ApiSeriesGet();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SeriesApi.ApiSeriesGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiSeriesGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiSeriesGetWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SeriesApi.ApiSeriesGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiseriesliststartamountget"></a>
# **ApiSeriesListStartAmountGet**
> List&lt;Series&gt; ApiSeriesListStartAmountGet (int start, int amount)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiSeriesListStartAmountGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new SeriesApi(config);
            var start = 56;  // int | 
            var amount = 56;  // int | 

            try
            {
                List<Series> result = apiInstance.ApiSeriesListStartAmountGet(start, amount);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SeriesApi.ApiSeriesListStartAmountGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiSeriesListStartAmountGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<Series>> response = apiInstance.ApiSeriesListStartAmountGetWithHttpInfo(start, amount);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SeriesApi.ApiSeriesListStartAmountGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **int** |  |  |
| **amount** | **int** |  |  |

### Return type

[**List&lt;Series&gt;**](Series.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiseriesnamequantitypost"></a>
# **ApiSeriesNameQuantityPost**
> void ApiSeriesNameQuantityPost (string name, int quantity)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiSeriesNameQuantityPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new SeriesApi(config);
            var name = "name_example";  // string | 
            var quantity = 56;  // int | 

            try
            {
                apiInstance.ApiSeriesNameQuantityPost(name, quantity);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SeriesApi.ApiSeriesNameQuantityPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiSeriesNameQuantityPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiSeriesNameQuantityPostWithHttpInfo(name, quantity);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SeriesApi.ApiSeriesNameQuantityPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** |  |  |
| **quantity** | **int** |  |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiseriespost"></a>
# **ApiSeriesPost**
> void ApiSeriesPost ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiSeriesPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new SeriesApi(config);

            try
            {
                apiInstance.ApiSeriesPost();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SeriesApi.ApiSeriesPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiSeriesPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiSeriesPostWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SeriesApi.ApiSeriesPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

