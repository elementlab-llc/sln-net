// **********************************************************************************************\
// Module Name:  ApiRedirectException.cs
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
    public class ApiRedirectException : ApiException
    {
        public ApiRedirectException(HttpStatusCode status, string message)
            : base(status, message)
        {
        }
    }
}