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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers;
using RestSharpMethod = RestSharp.Method;
using Polly;
using OpayoPaymentsNet.OpenAPI.Model;

namespace OpayoPaymentsNet.OpenAPI.Client
{
    /// <summary>
    /// Allows RestSharp to Serialize/Deserialize JSON using our custom logic, but only when ContentType is JSON.
    /// </summary>
    internal class CustomJsonCodec : IRestSerializer, ISerializer, IDeserializer
    {
        private readonly IReadableConfiguration _configuration;
        private static readonly string _contentType = "application/json";
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            }
        };

        public CustomJsonCodec(IReadableConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CustomJsonCodec(JsonSerializerSettings serializerSettings, IReadableConfiguration configuration)
        {
            _serializerSettings = serializerSettings;
            _configuration = configuration;
        }

        /// <summary>
        /// Serialize the object into a JSON string.
        /// </summary>
        /// <param name="obj">Object to be serialized.</param>
        /// <returns>A JSON string.</returns>
        public string Serialize(object obj)
        {
            if (obj != null && obj is AbstractOpenAPISchema)
            {
                // the object to be serialized is an oneOf/anyOf schema
                return ((AbstractOpenAPISchema)obj).ToJson();
            }
            else
            {
                return JsonConvert.SerializeObject(obj, _serializerSettings);
            }
        }

        public string Serialize(Parameter bodyParameter) => Serialize(bodyParameter.Value);

        public T Deserialize<T>(RestResponse response)
        {
            var result = (T)Deserialize(response, typeof(T));
            return result;
        }

        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="type">Object type.</param>
        /// <returns>Object representation of the JSON string.</returns>
        internal object Deserialize(RestResponse response, Type type)
        {
            if (type == typeof(byte[])) // return byte array
            {
                return response.RawBytes;
            }

            // TODO: ? if (type.IsAssignableFrom(typeof(Stream)))
            if (type == typeof(Stream))
            {
                var bytes = response.RawBytes;
                if (response.Headers != null)
                {
                    var filePath = string.IsNullOrEmpty(_configuration.TempFolderPath)
                        ? Path.GetTempPath()
                        : _configuration.TempFolderPath;
                    var regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$");
                    foreach (var header in response.Headers)
                    {
                        var match = regex.Match(header.ToString());
                        if (match.Success)
                        {
                            string fileName = filePath + ClientUtils.SanitizeFilename(match.Groups[1].Value.Replace("\"", "").Replace("'", ""));
                            File.WriteAllBytes(fileName, bytes);
                            return new FileStream(fileName, FileMode.Open);
                        }
                    }
                }
                var stream = new MemoryStream(bytes);
                return stream;
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
            {
                return DateTime.Parse(response.Content, null, DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(string) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return Convert.ChangeType(response.Content, type);
            }

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(response.Content, type, _serializerSettings);
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        public ISerializer Serializer => this;
        public IDeserializer Deserializer => this;

        public string[] AcceptedContentTypes => RestSharp.Serializers.ContentType.JsonAccept;

        public SupportsContentType SupportsContentType => contentType =>
            contentType.EndsWith("json", StringComparison.InvariantCultureIgnoreCase) ||
            contentType.EndsWith("javascript", StringComparison.InvariantCultureIgnoreCase);

        public string ContentType
        {
            get { return _contentType; }
            set { throw new InvalidOperationException("Not allowed to set content type."); }
        }

        public DataFormat DataFormat => DataFormat.Json;
    }
    /// <summary>
    /// Provides a default implementation of an Api client (both synchronous and asynchronous implementations),
    /// encapsulating general REST accessor use cases.
    /// </summary>
    public partial class ApiClient : ISynchronousClient, IAsynchronousClient
    {
        private readonly string _baseUrl;

        /// <summary>
        /// Specifies the settings on a <see cref="JsonSerializer" /> object.
        /// These settings can be adjusted to accommodate custom serialization rules.
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; set; } = new JsonSerializerSettings
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            }
        };

        /// <summary>
        /// Allows for extending request processing for <see cref="ApiClient"/> generated code.
        /// </summary>
        /// <param name="request">The RestSharp request object</param>
        partial void InterceptRequest(RestRequest request);

        /// <summary>
        /// Allows for extending response processing for <see cref="ApiClient"/> generated code.
        /// </summary>
        /// <param name="request">The RestSharp request object</param>
        /// <param name="response">The RestSharp response object</param>
        partial void InterceptResponse(RestRequest request, RestResponse response);

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" />, defaulting to the global configurations' base url.
        /// </summary>
        public ApiClient()
        {
            _baseUrl = GlobalConfiguration.Instance.BasePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" />
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        public ApiClient(string basePath)
        {
            if (string.IsNullOrEmpty(basePath))
                throw new ArgumentException("basePath cannot be empty");

            _baseUrl = basePath;
        }

        /// <summary>
        /// Constructs the RestSharp version of an http method
        /// </summary>
        /// <param name="method">Swagger Client Custom HttpMethod</param>
        /// <returns>RestSharp's HttpMethod instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private RestSharpMethod Method(HttpMethod method)
        {
            RestSharpMethod other;
            switch (method)
            {
                case HttpMethod.Get:
                    other = RestSharpMethod.Get;
                    break;
                case HttpMethod.Post:
                    other = RestSharpMethod.Post;
                    break;
                case HttpMethod.Put:
                    other = RestSharpMethod.Put;
                    break;
                case HttpMethod.Delete:
                    other = RestSharpMethod.Delete;
                    break;
                case HttpMethod.Head:
                    other = RestSharpMethod.Head;
                    break;
                case HttpMethod.Options:
                    other = RestSharpMethod.Options;
                    break;
                case HttpMethod.Patch:
                    other = RestSharpMethod.Patch;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("method", method, null);
            }

            return other;
        }

        /// <summary>
        /// Provides all logic for constructing a new RestSharp <see cref="RestRequest"/>.
        /// At this point, all information for querying the service is known. Here, it is simply
        /// mapped into the RestSharp request.
        /// </summary>
        /// <param name="method">The http verb.</param>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>[private] A new RestRequest instance.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private RestRequest NewRequest(
            HttpMethod method,
            string path,
            RequestOptions options,
            IReadableConfiguration configuration)
        {
            if (path == null) throw new ArgumentNullException("path");
            if (options == null) throw new ArgumentNullException("options");
            if (configuration == null) throw new ArgumentNullException("configuration");

            RestRequest request = new RestRequest(path, Method(method));

            if (options.PathParameters != null)
            {
                foreach (var pathParam in options.PathParameters)
                {
                    request.AddParameter(pathParam.Key, pathParam.Value, ParameterType.UrlSegment);
                }
            }

            if (options.QueryParameters != null)
            {
                foreach (var queryParam in options.QueryParameters)
                {
                    foreach (var value in queryParam.Value)
                    {
                        request.AddQueryParameter(queryParam.Key, value);
                    }
                }
            }

            if (configuration.DefaultHeaders != null)
            {
                foreach (var headerParam in configuration.DefaultHeaders)
                {
                    request.AddHeader(headerParam.Key, headerParam.Value);
                }
            }

            if (options.HeaderParameters != null)
            {
                foreach (var headerParam in options.HeaderParameters)
                {
                    foreach (var value in headerParam.Value)
                    {
                        request.AddHeader(headerParam.Key, value);
                    }
                }
            }

            if (options.FormParameters != null)
            {
                foreach (var formParam in options.FormParameters)
                {
                    request.AddParameter(formParam.Key, formParam.Value);
                }
            }

            if (options.Data != null)
            {
                if (options.Data is Stream stream)
                {
                    var contentType = "application/octet-stream";
                    if (options.HeaderParameters != null)
                    {
                        var contentTypes = options.HeaderParameters["Content-Type"];
                        contentType = contentTypes[0];
                    }

                    var bytes = ClientUtils.ReadAsBytes(stream);
                    request.AddParameter(contentType, bytes, ParameterType.RequestBody);
                }
                else
                {
                    if (options.HeaderParameters != null)
                    {
                        var contentTypes = options.HeaderParameters["Content-Type"];
                        if (contentTypes == null || contentTypes.Any(header => header.Contains("application/json")))
                        {
                            request.RequestFormat = DataFormat.Json;
                        }
                        else
                        {
                            // TODO: Generated client user should add additional handlers. RestSharp only supports XML and JSON, with XML as default.
                        }
                    }
                    else
                    {
                        // Here, we'll assume JSON APIs are more common. XML can be forced by adding produces/consumes to openapi spec explicitly.
                        request.RequestFormat = DataFormat.Json;
                    }

                    request.AddJsonBody(options.Data);
                }
            }

            if (options.FileParameters != null)
            {
                foreach (var fileParam in options.FileParameters)
                {
                    foreach (var file in fileParam.Value)
                    {
                        var bytes = ClientUtils.ReadAsBytes(file);
                        var fileStream = file as FileStream;
                        if (fileStream != null)
                            request.AddFile(fileParam.Key, bytes, Path.GetFileName(fileStream.Name));
                        else
                            request.AddFile(fileParam.Key, bytes, "no_file_name_provided");
                    }
                }
            }

            return request;
        }

        private ApiResponse<T> ToApiResponse<T>(RestResponse<T> response)
        {
            T result = response.Data;
            string rawContent = response.Content;

            var transformed = new ApiResponse<T>(response.StatusCode, new Multimap<string, string>(), result, rawContent)
            {
                ErrorText = response.ErrorMessage,
                Cookies = new List<Cookie>()
            };

            if (response.Headers != null)
            {
                foreach (var responseHeader in response.Headers)
                {
                    transformed.Headers.Add(responseHeader.Name, ClientUtils.ParameterToString(responseHeader.Value));
                }
            }

            if (response.ContentHeaders != null)
            {
                foreach (var responseHeader in response.ContentHeaders)
                {
                    transformed.Headers.Add(responseHeader.Name, ClientUtils.ParameterToString(responseHeader.Value));
                }
            }

            if (response.Cookies != null)
            {
                foreach (var responseCookies in response.Cookies.Cast<Cookie>())
                {
                    transformed.Cookies.Add(
                        new Cookie(
                            responseCookies.Name,
                            responseCookies.Value,
                            responseCookies.Path,
                            responseCookies.Domain)
                        );
                }
            }

            return transformed;
        }

        private ApiResponse<T> Exec<T>(RestRequest req, RequestOptions options, IReadableConfiguration configuration)
        {
            var baseUrl = configuration.GetOperationServerUrl(options.Operation, options.OperationIndex) ?? _baseUrl;

            var cookies = new CookieContainer();

            if (options.Cookies != null && options.Cookies.Count > 0)
            {
                foreach (var cookie in options.Cookies)
                {
                    cookies.Add(new Cookie(cookie.Name, cookie.Value));
                }
            }

            var clientOptions = new RestClientOptions(baseUrl)
            {
                ClientCertificates = configuration.ClientCertificates,
                CookieContainer = cookies,
                MaxTimeout = configuration.Timeout,
                Proxy = configuration.Proxy,
                UserAgent = configuration.UserAgent
            };

            RestClient client = new RestClient(clientOptions)
                .UseSerializer(() => new CustomJsonCodec(SerializerSettings, configuration));

            InterceptRequest(req);

            RestResponse<T> response;
            if (RetryConfiguration.RetryPolicy != null)
            {
                var policy = RetryConfiguration.RetryPolicy;
                var policyResult = policy.ExecuteAndCapture(() => client.Execute(req));
                response = policyResult.Outcome == OutcomeType.Successful ? client.Deserialize<T>(policyResult.Result) : new RestResponse<T>
                {
                    Request = req,
                    ErrorException = policyResult.FinalException
                };
            }
            else
            {
                response = client.Execute<T>(req);
            }

            // if the response type is oneOf/anyOf, call FromJSON to deserialize the data
            if (typeof(AbstractOpenAPISchema).IsAssignableFrom(typeof(T)))
            {
                try
                {
                    response.Data = (T)typeof(T).GetMethod("FromJson").Invoke(null, new object[] { response.Content });
                }
                catch (Exception ex)
                {
                    throw ex.InnerException != null ? ex.InnerException : ex;
                }
            }
            else if (typeof(T).Name == "Stream") // for binary response
            {
                response.Data = (T)(object)new MemoryStream(response.RawBytes);
            }
            else if (typeof(T).Name == "Byte[]") // for byte response
            {
                response.Data = (T)(object)response.RawBytes;
            }
            else if (typeof(T).Name == "String") // for string response
            {
                response.Data = (T)(object)response.Content;
            }

            InterceptResponse(req, response);

            var result = ToApiResponse(response);
            if (response.ErrorMessage != null)
            {
                result.ErrorText = response.ErrorMessage;
            }

            if (response.Cookies != null && response.Cookies.Count > 0)
            {
                if (result.Cookies == null) result.Cookies = new List<Cookie>();
                foreach (var restResponseCookie in response.Cookies.Cast<Cookie>())
                {
                    var cookie = new Cookie(
                        restResponseCookie.Name,
                        restResponseCookie.Value,
                        restResponseCookie.Path,
                        restResponseCookie.Domain
                    )
                    {
                        Comment = restResponseCookie.Comment,
                        CommentUri = restResponseCookie.CommentUri,
                        Discard = restResponseCookie.Discard,
                        Expired = restResponseCookie.Expired,
                        Expires = restResponseCookie.Expires,
                        HttpOnly = restResponseCookie.HttpOnly,
                        Port = restResponseCookie.Port,
                        Secure = restResponseCookie.Secure,
                        Version = restResponseCookie.Version
                    };

                    result.Cookies.Add(cookie);
                }
            }
            return result;
        }

        private async Task<ApiResponse<T>> ExecAsync<T>(RestRequest req, RequestOptions options, IReadableConfiguration configuration, CancellationToken cancellationToken = default)
        {
            var baseUrl = configuration.GetOperationServerUrl(options.Operation, options.OperationIndex) ?? _baseUrl;

            var clientOptions = new RestClientOptions(baseUrl)
            {
                ClientCertificates = configuration.ClientCertificates,
                MaxTimeout = configuration.Timeout,
                Proxy = configuration.Proxy,
                UserAgent = configuration.UserAgent
            };

            RestClient client = new RestClient(clientOptions)
                .UseSerializer(() => new CustomJsonCodec(SerializerSettings, configuration));

            InterceptRequest(req);

            RestResponse<T> response;
            if (RetryConfiguration.AsyncRetryPolicy != null)
            {
                var policy = RetryConfiguration.AsyncRetryPolicy;
                var policyResult = await policy.ExecuteAndCaptureAsync((ct) => client.ExecuteAsync(req, ct), cancellationToken).ConfigureAwait(false);
                response = policyResult.Outcome == OutcomeType.Successful ? client.Deserialize<T>(policyResult.Result) : new RestResponse<T>
                {
                    Request = req,
                    ErrorException = policyResult.FinalException
                };
            }
            else
            {
                response = await client.ExecuteAsync<T>(req, cancellationToken).ConfigureAwait(false);
            }

            // if the response type is oneOf/anyOf, call FromJSON to deserialize the data
            if (typeof(AbstractOpenAPISchema).IsAssignableFrom(typeof(T)))
            {
                response.Data = (T)typeof(T).GetMethod("FromJson").Invoke(null, new object[] { response.Content });
            }
            else if (typeof(T).Name == "Stream") // for binary response
            {
                response.Data = (T)(object)new MemoryStream(response.RawBytes);
            }
            else if (typeof(T).Name == "Byte[]") // for byte response
            {
                response.Data = (T)(object)response.RawBytes;
            }

            InterceptResponse(req, response);

            var result = ToApiResponse(response);
            if (response.ErrorMessage != null)
            {
                result.ErrorText = response.ErrorMessage;
            }

            if (response.Cookies != null && response.Cookies.Count > 0)
            {
                if (result.Cookies == null) result.Cookies = new List<Cookie>();
                foreach (var restResponseCookie in response.Cookies.Cast<Cookie>())
                {
                    var cookie = new Cookie(
                        restResponseCookie.Name,
                        restResponseCookie.Value,
                        restResponseCookie.Path,
                        restResponseCookie.Domain
                    )
                    {
                        Comment = restResponseCookie.Comment,
                        CommentUri = restResponseCookie.CommentUri,
                        Discard = restResponseCookie.Discard,
                        Expired = restResponseCookie.Expired,
                        Expires = restResponseCookie.Expires,
                        HttpOnly = restResponseCookie.HttpOnly,
                        Port = restResponseCookie.Port,
                        Secure = restResponseCookie.Secure,
                        Version = restResponseCookie.Version
                    };

                    result.Cookies.Add(cookie);
                }
            }
            return result;
        }

        #region IAsynchronousClient
        /// <summary>
        /// Make a HTTP GET request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> GetAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Get, path, options, config), options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP POST request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PostAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Post, path, options, config), options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP PUT request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PutAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Put, path, options, config), options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP DELETE request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> DeleteAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Delete, path, options, config), options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP HEAD request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> HeadAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Head, path, options, config), options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP OPTION request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> OptionsAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Options, path, options, config), options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP PATCH request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PatchAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Patch, path, options, config), options, config, cancellationToken);
        }
        #endregion IAsynchronousClient

        #region ISynchronousClient
        /// <summary>
        /// Make a HTTP GET request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Get<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Get, path, options, config), options, config);
        }

        /// <summary>
        /// Make a HTTP POST request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Post<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Post, path, options, config), options, config);
        }

        /// <summary>
        /// Make a HTTP PUT request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Put<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Put, path, options, config), options, config);
        }

        /// <summary>
        /// Make a HTTP DELETE request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Delete<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Delete, path, options, config), options, config);
        }

        /// <summary>
        /// Make a HTTP HEAD request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Head<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Head, path, options, config), options, config);
        }

        /// <summary>
        /// Make a HTTP OPTION request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Options<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Options, path, options, config), options, config);
        }

        /// <summary>
        /// Make a HTTP PATCH request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Patch<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Patch, path, options, config), options, config);
        }
        #endregion ISynchronousClient
    }
}
