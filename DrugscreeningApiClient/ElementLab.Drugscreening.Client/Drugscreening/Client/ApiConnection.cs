// **********************************************************************************************\
// Module Name:  ApiConnection.cs
// Project:      ElementLab.Drugscreening.Client 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ElementLab.Drugscreening.Contracts;
using ElementLab.Properties;
using Newtonsoft.Json;

namespace ElementLab.Drugscreening.Client
{
    public class ApiConnection : IApiConnection
    {
        const string CreateTokenUrl = "account/token";

        readonly ClientCredentials _credentials;
        readonly HttpClient _httpClient;
        readonly AsyncLock _tokenLock = new AsyncLock();
        readonly TraceSource _trace = new TraceSource(typeof(ApiClient).Namespace);
        volatile AuthenticationHeaderValue _token;

        IDataConverter _dataConverter;

        public IDataConverter Converter
        {
            get => _dataConverter ?? (_dataConverter = new JsonDataConverter());
            set => _dataConverter = value;
        }

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ApiConnection"/>
        /// </summary>
        /// <param name="url">Адрес сервиса скрининга</param>
        /// <param name="credentials">Данные, необходимые для идентификации и аутентификации пользователя сервиса</param>
        public ApiConnection(string url, ClientCredentials credentials) :
            this(null, url, credentials)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ApiConnection(HttpMessageHandler httpHandler, string url, ClientCredentials credentials)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException(Resources.E_Service_Url_could_not_be_empty, nameof(url));

            if (!url.EndsWith("/"))
                url += "/";

            _credentials = credentials;

            if (httpHandler == null)
            {
                httpHandler = new HttpClientHandler()
                {
                    AllowAutoRedirect = false,
                    UseCookies = false
                };
            }

            _httpClient = new HttpClient(httpHandler)
            {
                BaseAddress = new Uri(url)
            };
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        /// <summary>
        /// Выполняет авторизованный GET запрос к API
        /// </summary>
        /// <typeparam name="TResult">Тип данных результата</typeparam>
        /// <param name="resourceUrl">Относительный адрес ресурса</param>
        /// <param name="urlParameters">Параметры для формирования полного URL запроса</param>
        /// <returns>Результат запроса</returns>
        public Task<TResult> GetAsync<TResult>(string resourceUrl, object urlParameters)
            where TResult : class
        {
            return SendAuthorizedAsync<TResult>(HttpMethod.Get, resourceUrl, urlParameters, null);
        }

        /// <summary>
        /// Выполняет авторизованный POST запрос к API
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="resourceUrl">Относительный адрес ресурса</param>
        /// <param name="urlParameters">Параметры для формирования полного URL запроса</param>
        /// <param name="payload">Данные для передачи в теле запроса</param>
        /// <returns>Результат запроса</returns>
        public Task<TResult> PostAsync<TResult>(string resourceUrl, object urlParameters, object payload)
            where TResult : class
        {
            return SendAuthorizedAsync<TResult>(HttpMethod.Post, resourceUrl, urlParameters, payload);
        }

        async Task<AuthenticationHeaderValue> GetOrCreateTokenAsync(bool force)
        {
            if (_token == null || force)
            {
                using (await _tokenLock.LockAsync())
                {
                    if (_token == null || force)
                    {
                        var result = await SendAnonymousAsync<CreatedToken>(HttpMethod.Post, CreateTokenUrl, null, _credentials);
                        _token = new AuthenticationHeaderValue("Bearer", result.Token);
                    }
                }
            }

            return _token;
        }

        /// <summary>
        /// Выполняет авторизованный запрос к API
        /// </summary>
        /// <typeparam name="TResult">Тип результата</typeparam>
        /// <param name="method">Метод HTTP</param>
        /// <param name="url">Относительный адрес ресурса</param>
        /// <param name="urlParameters">Параметры для формирования полного URL запроса</param>
        /// <param name="payload">Данные для передачи в теле запроса</param>
        /// <returns>Результат запроса</returns>
        async Task<TResult> SendAuthorizedAsync<TResult>(HttpMethod method, string url, object urlParameters, object payload)
            where TResult : class
        {
            TResult result;
            using (_trace.Monitor($"{method} {url}"))
            {
                var isRetry = false;
                HttpResponseMessage responseMessage;
                while (true)
                {
                    var requestMessage = CreateRequestMessage(method, url, urlParameters, payload);
                    requestMessage.Headers.Authorization = await GetOrCreateTokenAsync(isRetry);

                    responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
                    if (responseMessage.StatusCode == HttpStatusCode.Unauthorized && !isRetry)
                        isRetry = true;
                    else
                        break;
                }

                result = await ReadResponseAsync<TResult>(responseMessage).ConfigureAwait(false);
            }
            return result;
        }

        /// <summary>
        /// Выполняет анонимный запрос к API
        /// </summary>
        /// <typeparam name="TResult">Тип результата</typeparam>
        /// <param name="method">Метод HTTP</param>
        /// <param name="url">Относительный адрес ресурса</param>
        /// <param name="urlParameters">Параметры для формирования полного URL запроса</param>
        /// <param name="payload">Данные для передачи в теле запроса</param>
        /// <returns>Результат запроса</returns>
        async Task<TResult> SendAnonymousAsync<TResult>(HttpMethod method, string url, object urlParameters, object payload)
            where TResult : class
        {
            TResult result;
            using (_trace.Monitor($"{method} {url}"))
            {
                var requestMessage = CreateRequestMessage(method, url, urlParameters, payload);
                var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
                result = await ReadResponseAsync<TResult>(responseMessage).ConfigureAwait(false);
            }
            return result;
        }

        HttpRequestMessage CreateRequestMessage(HttpMethod method, string url, object urlParameters, object payload)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = method
            };

            if (urlParameters != null)
            {
                var list = new List<Tuple<string, string>>();
                list.AddRange(from PropertyDescriptor pd in TypeDescriptor.GetProperties(urlParameters)
                              let value = Convert.ToString(pd.GetValue(urlParameters))
                              where !string.IsNullOrWhiteSpace(value)
                              select Tuple.Create(pd.Name, value));
                if (list.Count > 0)
                {
                    for (var i = list.Count - 1; i >= 0; i--)
                    {
                        var pair = list[i];
                        var paramName = $"{{{pair.Item1}}}";
                        if (url.IndexOf(paramName, StringComparison.Ordinal) >= 0)
                        {
                            url = url.Replace(paramName, Uri.EscapeUriString(pair.Item2));
                            list.RemoveAt(i);
                        }
                    }
                    if (list.Count > 0)
                        url += "?" + string.Join("&", list.Select(t => $"{Uri.EscapeUriString(t.Item1)}={Uri.EscapeDataString(t.Item2)}"));
                }
            }

            if (method == HttpMethod.Post || method == HttpMethod.Put)
            {
                var json = Serialize(payload);
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            requestMessage.RequestUri = new Uri(url, UriKind.Relative);
            requestMessage.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue(System.Globalization.CultureInfo.CurrentCulture.Name));

            return requestMessage;
        }

        async Task<TResponse> ReadResponseAsync<TResponse>(HttpResponseMessage responseMessage)
            where TResponse : class
        {
            TResponse response = null;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseString = await responseMessage.Content.ReadAsStringAsync();
                response = Deserialize<TResponse>(responseString);
            }
            else
            {
                ErrorInfo errorInfo = null;
                if (responseMessage.Content != null)
                {
                    var errorJson = await responseMessage.Content.ReadAsStringAsync();
                    try
                    {
                        errorInfo = Deserialize<ErrorInfo>(errorJson);
                    }
                    catch (JsonSerializationException)
                    {
                    }
                }
                var message = errorInfo?.Message ?? responseMessage.ReasonPhrase;
                var error = CreateError(responseMessage.StatusCode, message);
                if (error != null)
                    throw error;
            }
            return response;
        }

        static Exception CreateError(HttpStatusCode status, string message)
        {
            switch (status)
            {
                case HttpStatusCode.OK:
                    return null;

                case HttpStatusCode.MultipleChoices:
                case HttpStatusCode.MovedPermanently:
                case HttpStatusCode.Found:
                case HttpStatusCode.SeeOther:
                case HttpStatusCode.NotModified:
                case HttpStatusCode.UseProxy:
                case HttpStatusCode.Unused:
                case HttpStatusCode.TemporaryRedirect:
                    return new ApiRedirectException(status, message);

                case HttpStatusCode.BadRequest:
                    return new ApiArgumentException(status, message);

                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.ProxyAuthenticationRequired:
                    return new ApiSecurityException(status, message);

                case HttpStatusCode.NotFound:
                    return new ApiResourceNotFoundException(status, message);

                case HttpStatusCode.RequestTimeout:
                case HttpStatusCode.MethodNotAllowed:
                case HttpStatusCode.NotAcceptable:
                case HttpStatusCode.UnsupportedMediaType:
                case HttpStatusCode.NotImplemented:
                case HttpStatusCode.InternalServerError:
                    return new ApiException(status, message);

                // ReSharper disable RedundantCaseLabel
                case HttpStatusCode.Continue:
                case HttpStatusCode.SwitchingProtocols:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.NonAuthoritativeInformation:
                case HttpStatusCode.NoContent:
                case HttpStatusCode.ResetContent:
                case HttpStatusCode.PartialContent:
                case HttpStatusCode.PaymentRequired:
                case HttpStatusCode.Conflict:
                case HttpStatusCode.Gone:
                case HttpStatusCode.LengthRequired:
                case HttpStatusCode.PreconditionFailed:
                case HttpStatusCode.RequestEntityTooLarge:
                case HttpStatusCode.RequestUriTooLong:
                case HttpStatusCode.RequestedRangeNotSatisfiable:
                case HttpStatusCode.ExpectationFailed:
                case HttpStatusCode.UpgradeRequired:
                case HttpStatusCode.BadGateway:
                case HttpStatusCode.ServiceUnavailable:
                case HttpStatusCode.GatewayTimeout:
                case HttpStatusCode.HttpVersionNotSupported:
                default:
                    return new ApiException(status, message);
            }
        }

        string Serialize<T>(T obj) where T : class
        {
            return Converter.Serialize(obj);
        }

        T Deserialize<T>(string str) where T : class
        {
            return Converter.Deserialize<T>(str);
        }
    }
}