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

namespace OpayoPaymentsNet.OpenAPI.Client
{
    /// <summary>
    /// A dictionary in which one key has many associated values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key</typeparam>
    /// <typeparam name="TValue">The type of the value associated with the key.</typeparam>
    public class Multimap<TKey, TValue> : IDictionary<TKey, IList<TValue>>
    {
        #region Private Fields

        private readonly Dictionary<TKey, IList<TValue>> _dictionary;

        #endregion Private Fields

        #region Constructors

        /// <summary>
        /// Empty Constructor.
        /// </summary>
        public Multimap()
        {
            _dictionary = new Dictionary<TKey, IList<TValue>>();
        }

        /// <summary>
        /// Constructor with comparer.
        /// </summary>
        /// <param name="comparer"></param>
        public Multimap(IEqualityComparer<TKey> comparer)
        {
            _dictionary = new Dictionary<TKey, IList<TValue>>(comparer);
        }

        #endregion Constructors

        #region Enumerators

        /// <summary>
        /// To get the enumerator.
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<KeyValuePair<TKey, IList<TValue>>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        /// <summary>
        /// To get the enumerator.
        /// </summary>
        /// <returns>Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        #endregion Enumerators

        #region Public Members
        /// <summary>
        /// Add values to Multimap
        /// </summary>
        /// <param name="item">Key value pair</param>
        public void Add(KeyValuePair<TKey, IList<TValue>> item)
        {
            if (!TryAdd(item.Key, item.Value))
                throw new InvalidOperationException("Could not add values to Multimap.");
        }

        /// <summary>
        /// Add Multimap to Multimap
        /// </summary>
        /// <param name="multimap">Multimap</param>
        public void Add(Multimap<TKey, TValue> multimap)
        {
            foreach (var item in multimap)
            {
                if (!TryAdd(item.Key, item.Value))
                    throw new InvalidOperationException("Could not add values to Multimap.");
            }
        }

        /// <summary>
        /// Clear Multimap
        /// </summary>
        public void Clear()
        {
            _dictionary.Clear();
        }

        /// <summary>
        /// Determines whether Multimap contains the specified item.
        /// </summary>
        /// <param name="item">Key value pair</param>
        /// <exception cref="NotImplementedException">Method needs to be implemented</exception>
        /// <returns>true if the Multimap contains the item; otherwise, false.</returns>
        public bool Contains(KeyValuePair<TKey, IList<TValue>> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Copy items of the Multimap to an array,
        ///     starting at a particular array index.
        /// </summary>
        /// <param name="array">The array that is the destination of the items copied
        ///     from Multimap. The array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="NotImplementedException">Method needs to be implemented</exception>
        public void CopyTo(KeyValuePair<TKey, IList<TValue>>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified item from the Multimap.
        /// </summary>
        /// <param name="item">Key value pair</param>
        /// <returns>true if the item is successfully removed; otherwise, false.</returns>
        /// <exception cref="NotImplementedException">Method needs to be implemented</exception>
        public bool Remove(KeyValuePair<TKey, IList<TValue>> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the number of items contained in the Multimap.
        /// </summary>
        public int Count => _dictionary.Count;

        /// <summary>
        /// Gets a value indicating whether the Multimap is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an item with the provided key and value to the Multimap.
        /// </summary>
        /// <param name="key">The object to use as the key of the item to add.</param>
        /// <param name="value">The object to use as the value of the item to add.</param>
        /// <exception cref="InvalidOperationException">Thrown when couldn't add the value to Multimap.</exception>
        public void Add(TKey key, IList<TValue> value)
        {
            if (value != null && value.Count > 0)
            {
                if (_dictionary.TryGetValue(key, out var list))
                {
                    foreach (var k in value) list.Add(k);
                }
                else
                {
                    list = new List<TValue>(value);
                    if (!TryAdd(key, list))
                        throw new InvalidOperationException("Could not add values to Multimap.");
                }
            }
        }

        /// <summary>
        /// Determines whether the Multimap contains an item with the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the Multimap.</param>
        /// <returns>true if the Multimap contains an item with
        ///     the key; otherwise, false.</returns>
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Removes item with the specified key from the Multimap.
        /// </summary>
        /// <param name="key">The key to locate in the Multimap.</param>
        /// <returns>true if the item is successfully removed; otherwise, false.</returns>
        public bool Remove(TKey key)
        {
            return TryRemove(key, out var _);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key, if the
        ///     key is found; otherwise, the default value for the type of the value parameter.
        ///     This parameter is passed uninitialized.</param>
        /// <returns> true if the object that implements Multimap contains
        ///     an item with the specified key; otherwise, false.</returns>
        public bool TryGetValue(TKey key, out IList<TValue> value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets or sets the item with the specified key.
        /// </summary>
        /// <param name="key">The key of the item to get or set.</param>
        /// <returns>The value of the specified key.</returns>
        public IList<TValue> this[TKey key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }

        /// <summary>
        /// Gets a System.Collections.Generic.ICollection containing the keys of the Multimap.
        /// </summary>
        public ICollection<TKey> Keys => _dictionary.Keys;

        /// <summary>
        /// Gets a System.Collections.Generic.ICollection containing the values of the Multimap.
        /// </summary>
        public ICollection<IList<TValue>> Values => _dictionary.Values;

        /// <summary>
        ///  Copy the items of the Multimap to an System.Array,
        ///     starting at a particular System.Array index.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the items copied
        ///     from Multimap. The System.Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            ((ICollection)_dictionary).CopyTo(array, index);
        }

        /// <summary>
        /// Adds an item with the provided key and value to the Multimap.
        /// </summary>
        /// <param name="key">The object to use as the key of the item to add.</param>
        /// <param name="value">The object to use as the value of the item to add.</param>
        /// <exception cref="InvalidOperationException">Thrown when couldn't add value to Multimap.</exception>
        public void Add(TKey key, TValue value)
        {
            if (value != null)
            {
                if (_dictionary.TryGetValue(key, out var list))
                {
                    list.Add(value);
                }
                else
                {
                    list = new List<TValue> { value };
                    if (!TryAdd(key, list))
                        throw new InvalidOperationException("Could not add value to Multimap.");
                }
            }
        }

        #endregion Public Members

        #region Private Members

        /**
         * Helper method to encapsulate generator differences between dictionary types.
         */
        private bool TryRemove(TKey key, out IList<TValue> value)
        {
            _dictionary.TryGetValue(key, out value);
            return _dictionary.Remove(key);
        }

        /**
         * Helper method to encapsulate generator differences between dictionary types.
         */
        private bool TryAdd(TKey key, IList<TValue> value)
        {
            try
            {
                _dictionary.Add(key, value);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
        #endregion Private Members
    }
}
