// **********************************************************************************************\
// Module Name:  ApiClient.cs
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
using System.Linq;
using System.Threading.Tasks;
using ElementLab.Drugscreening.Contracts;
using ElementLab.Properties;

namespace ElementLab.Drugscreening.Client
{
    public class ApiClient : IDisposable
    {
        const int FindConceptsLimit = 50;
        static readonly DateTime _emptyDate = new DateTime(1900, 1, 1);
        readonly bool _ownsConnection = false;

        public IApiConnection Connection { get; }

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ApiClient"/>
        /// </summary>
        /// <param name="connection"></param>
        public ApiClient(IApiConnection connection)
        {
            Connection = connection;
            _ownsConnection = false;
        }

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ApiClient"/>
        /// </summary>
        public ApiClient(string baseUrl, ClientCredentials credentials)
            : this(new ApiConnection(baseUrl, credentials))
        {
            _ownsConnection = true;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_ownsConnection)
                Connection?.Dispose();
        }

        /// <summary>
        /// Возвращает список типов концептов
        /// </summary>
        /// <returns>Список типов концептов</returns>
        public Task<ConceptType[]> GetConceptTypesAsync()
        {
            return GetAsync<ConceptType[]>(Urls.GetConceptTypes);
        }

        /// <summary>
        /// Возвращает список типов концептов из "внешних" справочников
        /// </summary>
        /// <returns>Список типов концептов</returns>
        public Task<ConceptType[]> GetExternalConceptTypesAsync()
        {
            return GetAsync<ConceptType[]>(Urls.GetExternalConceptTypes);
        }

        /// <summary>
        /// Возвращает список концептов указанного типа
        /// </summary>
        /// <param name="type">Тип концептов</param>
        /// <param name="start">Индекс первого элемента списка</param>
        /// <param name="pageSize">Максимальное количество возвращаемых концептов</param>
        /// <returns>Список концептов</returns>
        public async Task<ListConceptsResult> ListConceptsAsync(string type, int start = 0, int pageSize = 50)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentNullException(nameof(type));

            // запрашивается на 1 концепт больше, чтобы понять - есть ли еще концепты
            var concepts = await GetAsync<ConceptInfo[]>(Urls.ListConceptsOfType, new { type = type, start = start, pageSize = pageSize + 1 });

            var result = new ListConceptsResult(concepts.Take(pageSize).ToArray(), start, concepts.Length > pageSize);
            return result;
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
            if (string.IsNullOrWhiteSpace(query))
                return Task.FromResult(new FoundConceptInfo[0]);

            return GetAsync<FoundConceptInfo[]>(Urls.FindConceptsByScope, new { q = query, scope = scope, searchBy = method, limit = FindConceptsLimit });
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
            if (string.IsNullOrWhiteSpace(query) || types == null || types.Length == 0)
                return Task.FromResult(new FoundConceptInfo[0]);

            return GetAsync<FoundConceptInfo[]>(Urls.FindConceptsByType, new { q = query, type = string.Join(",", types), searchBy = method, limit = FindConceptsLimit });
        }

        /// <summary>
        /// Возвращает информацию о концепте
        /// </summary>
        /// <param name="conceptType">Тип концепта</param>
        /// <param name="conceptCode">Код концепта</param>
        /// <returns>Описание концепта</returns>
        public Task<ConceptInfo> GetConceptAsync(string conceptType, string conceptCode)
        {
            if (string.IsNullOrWhiteSpace(conceptType))
                throw new ArgumentException(Resources.E_Missing_Concept_Type, nameof(conceptType));
            if (string.IsNullOrWhiteSpace(conceptCode))
                throw new ArgumentException(Resources.E_Missing_Concept_Code, nameof(conceptCode));

            return GetAsync<ConceptInfo>(Urls.GetConcept, new { type = conceptType, code = conceptCode });
        }

        /// <summary>
        /// Возвращает список инструкций для заданного концепта
        /// </summary>
        /// <param name="conceptType">Тип концепта</param>
        /// <param name="conceptCode">Код концепта</param>
        /// <returns>Информация об имеющихся инструкциях</returns>
        public Task<Instruction[]> ListInstructionsAsync(string conceptType, string conceptCode)
        {
            if (string.IsNullOrWhiteSpace(conceptType))
                throw new ArgumentException(Resources.E_Missing_Concept_Type, nameof(conceptType));
            if (string.IsNullOrWhiteSpace(conceptCode))
                throw new ArgumentException(Resources.E_Missing_Concept_Code, nameof(conceptCode));

            return GetAsync<Instruction[]>(Urls.ListInstructions, new { type = conceptType, code = conceptCode });
        }

        /// <summary>
        /// Возвращает содержимое инструкции
        /// </summary>
        /// <param name="instructionCode">Код инструкции</param>
        /// <returns>Объект, описывающий содержимое инструкции</returns>
        public Task<InstructionContent> GetInstructionAsync(string instructionCode)
        {
            if (string.IsNullOrWhiteSpace(instructionCode))
                throw new ArgumentException(Resources.E_Missing_Instruction_Code, nameof(instructionCode));

            return GetAsync<InstructionContent>(Urls.GetInstructionContent, new { code = instructionCode });
        }

        /// <summary>
        /// Выполняет скрининг лекарственных препаратов
        /// </summary>
        /// <param name="request">Параметры для выполнения скрининга</param>
        /// <returns>Результат скрининга</returns>
        public Task<ScreeningSummary> ScreenAsync(ScreenRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            // очистить пустые поля, чтобы не передавать лишние данные
            if (request.Patient != null)
            {
                var patient = request.Patient;
                if (patient.BirthDate.HasValue && patient.BirthDate.Value < _emptyDate)
                    patient.BirthDate = null;

                if (patient.BodySurfaceArea == 0)
                    patient.BodySurfaceArea = null;
                if (patient.Weight == 0)
                    patient.Weight = null;

                if (patient.ExpectedBirthDate.HasValue && patient.ExpectedBirthDate.Value < _emptyDate)
                    patient.ExpectedBirthDate = null;

                var sport = patient.Sport;
                if (sport != null)
                {
                    if (string.IsNullOrWhiteSpace(sport.Role))
                        sport.Role = null;
                }
            }
            if (request.Allergies?.Count == 0)
                request.Allergies = null;

            if (request.Diseases?.Count == 0)
                request.Diseases = null;

            return PostAsync<ScreeningSummary>(Urls.Screening, null, request);
        }

        Task<TResponse> GetAsync<TResponse>(string url, object urlParameters = null)
            where TResponse : class
        {
            return Connection.GetAsync<TResponse>(url, urlParameters);
        }

        Task<TResponse> PostAsync<TResponse>(string url, object urlParameters, object request)
            where TResponse : class
        {
            return Connection.PostAsync<TResponse>(url, urlParameters, request);
        }

        static class Urls
        {
            public const string GetConceptTypes = "concepts/types";
            public const string GetExternalConceptTypes = "concepts/types/external";
            public const string ListConceptsOfType = "concepts/list/{type}";
            public const string FindConceptsByScope = "concepts/find/{scope}";
            public const string FindConceptsByType = "concepts/find";
            public const string GetConcept = "concepts/{type}";
            public const string Screening = "screening";
            public const string ListInstructions = "instructions";
            public const string GetInstructionContent = "instructions/{code}";
        }
    }
}
