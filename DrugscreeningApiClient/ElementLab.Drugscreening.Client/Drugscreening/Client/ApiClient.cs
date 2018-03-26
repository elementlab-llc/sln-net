using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ElementLab.Drugscreening.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ElementLab.Drugscreening.Client
{
    public class ApiClient : IDisposable
    {
        const int FindConceptsLimit = 50;

        /// <summary>
        /// Предоставляет доступ к настройкам json-сериализатора.
        /// </summary>
        static readonly JsonSerializerSettings _serializationSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = { new StringEnumConverter() },
            DateFormatString = "yyyy-MM-dd",
            DateTimeZoneHandling = DateTimeZoneHandling.Local,
            Formatting = Formatting.Indented
        };

        readonly TraceSource _trace = new TraceSource(typeof(ApiClient).Namespace);
        readonly ClientCredentials _credentials;
        HttpClient _client;

        volatile AuthenticationHeaderValue _token;
        readonly object _tokenLock = new object();

        CultureInfo _cultureInfo;

        public CultureInfo Culture
        {
            get => _cultureInfo ?? System.Threading.Thread.CurrentThread.CurrentCulture;
            set => _cultureInfo = value;
        }

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ApiClient"/>
        /// </summary>
        /// <param name="url">Адрес сервиса скрининга</param>
        /// <param name="credentials">Данные, необходимые для идентификации и аутентификации пользователя сервиса</param>
        public ApiClient(string url, ClientCredentials credentials)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException("Service Base Url cannot be empty", nameof(url));

            _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));

            url = url.EnsureEndsWith("/");

            _trace.TraceEvent(TraceEventType.Verbose, 0, "Service Base Url: {0}", url);

            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                UseCookies = false
            };
            _client = new HttpClient(handler)
            {
                BaseAddress = new Uri(url)
            };
        }

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
                _client = null;
            }
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Возвращает список типов концептов
        /// </summary>
        /// <returns>Список типов концептов</returns>
        public Task<ConceptType[]> GetConceptTypesAsync()
        {
            const string url = "concepts/types";
            return GetAsync<ConceptType[]>(url);
        }

        /// <summary>
        /// Возвращает список концептов указанного типа
        /// </summary>
        /// <param name="type">Тип концептов</param>
        /// <param name="start">Индекс первого элемента списка</param>
        /// <param name="pageSize">Максимальное количество возвращаемых концептов</param>
        /// <returns>Список концептов</returns>
        public Task<ConceptInfo[]> ListConcepts(string type, int start = 0, int pageSize = 50)
        {
            const string url = "concepts/list/{type}";
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentNullException(nameof(type));

            return GetAsync<ConceptInfo[]>(url, new {type = type, start = start, pageSize = pageSize});
        }

        /// <summary>
        /// Выполняет поиск концептов с типами, соответствующими указанной области поиска
        /// </summary>
        /// <param name="query">Запрос для поиска</param>
        /// <param name="method">Метод поиска</param>
        /// <param name="scope">Область поиска концептов</param>
        /// <returns>Список найденных концептов</returns>
        public Task<FoundConceptInfo[]> FindConceptsAsync(string query, SearchMethod method, SearchScope scope)
        {
            const string url = "concepts/find/{scope}";
            if (string.IsNullOrWhiteSpace(query))
                return Task.FromResult(new FoundConceptInfo[0]);

            return GetAsync<FoundConceptInfo[]>(url, new { q = query, scope = scope, searchBy = method, limit = FindConceptsLimit });
        }

        /// <summary>
        /// Выполняет поиск концептов
        /// </summary>
        /// <param name="query">Запрос для поиска</param>
        /// <param name="method">Метод поиска</param>
        /// <param name="types">Список типов концептов</param>
        /// <returns>Список найденных концептов</returns>
        public Task<FoundConceptInfo[]> FindConceptsAsync(string query, SearchMethod method, params string[] types)
        {
            const string url = "concepts/find";

            if (string.IsNullOrWhiteSpace(query) || types == null || types.Length == 0)
                return Task.FromResult(new FoundConceptInfo[0]);

            return GetAsync<FoundConceptInfo[]>(url, new { q = query, type = string.Join(",", types), searchBy = method, limit = FindConceptsLimit });
        }

        /// <summary>
        /// Возвращает информацию о концепте.
        /// </summary>
        /// <param name="conceptType">Тип концепта.</param>
        /// <param name="conceptCode">Системный идентификатор концепта.</param>
        /// <returns></returns>
        public Task<ConceptInfo> GetConceptAsync(string conceptType, int conceptCode)
        {
            const string url = "concepts/{conceptType}";

            return GetAsync<ConceptInfo>(url, new { type = conceptType, code = conceptCode });
        }

        /// <summary>
        /// Возвращает результаты скрининга лекарственных препаратов.
        /// </summary>
        /// <param name="request">Параметры для выполнения скрининга.</param>
        /// <returns>Результат скрининга.</returns>
        public Task<ScreeningSummary> ScreenAsync(ScreenRequest request)
        {
            const string url = "screening";

            return PostAsync<ScreenRequest, ScreeningSummary>(url, null, request);
        }

        void EnsureAuthorized()
        {
            if (_token == null)
            {
                lock (_tokenLock)
                {
                    if (_token == null)
                    {
                        Authorize().Wait();
                    }
                }
            }
        }

        async Task Authorize()
        {
            _token = null;
            var result = await ExecuteSendAsync<ClientCredentials, CreatedToken>(HttpMethod.Post, "account/token", null, _credentials);
            _token = new AuthenticationHeaderValue("Bearer", result.Token);
        }

        Task<TResponse> GetAsync<TResponse>(string url, object urlParameters = null)
            where TResponse : class
        {
            return SendAsync<object, TResponse>(HttpMethod.Get, url, urlParameters, null);
        }

        Task<TResponse> PostAsync<TRequest, TResponse>(string url, object urlParameters, TRequest request)
            where TRequest : class
            where TResponse : class
        {
            return SendAsync<TRequest, TResponse>(HttpMethod.Post, url, urlParameters, request);
        }

        Task<TResponse> SendAsync<TRequest, TResponse>(HttpMethod method, string url, object urlParameters, TRequest payload)
            where TRequest : class
            where TResponse : class
        {
            EnsureAuthorized();
            return ExecuteSendAsync<TRequest, TResponse>(method, url, urlParameters, payload);
        }

        async Task<TResponse> ExecuteSendAsync<TRequest, TResponse>(HttpMethod method, string url, object urlParameters, TRequest payload)
            where TRequest : class
            where TResponse : class
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

            if (method == HttpMethod.Post)
            {
                var json = Serialize(payload);
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            requestMessage.RequestUri = new Uri(url, UriKind.Relative);
            requestMessage.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue(Culture.Name));

            if (_token != null)
                requestMessage.Headers.Authorization = _token;

            TResponse response;
            using (_trace.Monitor($"{method.Method} {url}"))
            {
                var text = requestMessage.ToString();
                if (_trace.Switch.ShouldTrace(TraceEventType.Verbose))
                    _trace.Verbose(text);
                var responseMessage = await _client.SendAsync(requestMessage).ConfigureAwait(false);
                response = await ReadResponseAsync<TResponse>(responseMessage).ConfigureAwait(false);
            }

            return response;
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        class ErrorInfo
        {
            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public string Message { get; set; }
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
                case HttpStatusCode.Continue:
                case HttpStatusCode.SwitchingProtocols:
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.NonAuthoritativeInformation:
                case HttpStatusCode.NoContent:
                case HttpStatusCode.ResetContent:
                case HttpStatusCode.PartialContent:
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

        string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, _serializationSettings);
        }

        T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _serializationSettings);
        }
    }
}
