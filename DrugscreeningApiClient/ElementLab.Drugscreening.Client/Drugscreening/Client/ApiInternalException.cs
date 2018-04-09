// **********************************************************************************************\
// Module Name:  ApiInternalException.cs
// Project:      ElementLab.Drugscreening.Client 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using System.Net;

namespace ElementLab.Drugscreening.Client
{
    /// <summary>
    /// Ошибка, вызванная внутренними проблемами API.
    /// </summary>
    public class ApiInternalException : ApiException
    {
        public ApiInternalException(HttpStatusCode code, string message)
            : base(code, message)
        {
        }
    }
}