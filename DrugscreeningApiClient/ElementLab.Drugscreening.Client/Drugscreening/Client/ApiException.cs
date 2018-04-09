// **********************************************************************************************\
// Module Name:  ApiException.cs
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
using System.Net;

namespace ElementLab.Drugscreening.Client
{
    /// <summary>
    /// Базовый класс для всех ошибок, связанных с обращениями к API.
    /// </summary>
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode code, string message)
            : base(message)
        {
            this.StatusCode = code;
        }

        public HttpStatusCode StatusCode { get; }
    }
}