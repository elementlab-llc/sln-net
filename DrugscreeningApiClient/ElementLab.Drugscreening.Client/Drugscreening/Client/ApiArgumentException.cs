// **********************************************************************************************\
// Module Name:  ApiArgumentException.cs
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
    /// Описывает ошибку, вызванную неправильными параметрами, указанными при обращении к API
    /// </summary>
    public class ApiArgumentException : ApiException
    {
        public ApiArgumentException(HttpStatusCode status, string message)
            : base(status, message)
        {
        }
    }
}