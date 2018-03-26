using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Содержит данные, необходимые для идентификации и аутентификации пользователя сервиса.
    /// </summary>
    /// <summary lang="en">
    /// Contains data, required for client identification and authorization
    /// </summary>
    
    public class ClientCredentials
    {
        /// <summary>
        /// Идентификатор пользователя сервиса (логин)
        /// </summary>
        /// <summary lang="en">
        /// Client Identifier (login)
        /// </summary>
        public string ClientId { get; }
        /// <summary>
        /// Секретный ключ, соответствующий идентификатору пользователя (пароль)
        /// </summary>
        /// <summary lang="en">
        /// Secret key (password)
        /// </summary>
        public string ClientSecret { get; }

        /// <summary>
        /// Инициализирует экземпляр класса ClientCredentials
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        public ClientCredentials(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}