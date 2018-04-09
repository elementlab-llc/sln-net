// **********************************************************************************************\
// Module Name:  CreatedToken.cs
// Project:      ElementLab.Drugscreening.Contracts 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 
namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <summary lang="en">
    /// </summary>
    public class CreatedToken
    {
        /// <summary>
        /// Идентификатор пользователя API (логин)
        /// </summary>
        /// <summary lang="en">
        /// API client identifier (login)
        /// </summary>
        
        public string ClientId { get; set; }

        /// <summary>
        /// Токен для доступа к API
        /// </summary>
        /// <summary lang="en">
        /// API access token
        /// </summary>
        
        public string Token { get; set; }
    }
}