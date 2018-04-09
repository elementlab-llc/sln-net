// **********************************************************************************************\
// Module Name:  IApiConnection.cs
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
using System.Threading.Tasks;

namespace ElementLab.Drugscreening.Client
{
    public interface IApiConnection: IDisposable
    {
        Task<TResult> GetAsync<TResult>(string resourceUrl, object urlParameters) where TResult : class;
        Task<TResult> PostAsync<TResult>(string resourceUrl, object urlParameters, object payload) where TResult : class;
    }
}