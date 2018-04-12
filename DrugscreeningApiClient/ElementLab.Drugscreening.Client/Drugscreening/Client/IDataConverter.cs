// **********************************************************************************************\
// Module Name:  IJsonConverter.cs
// Project:      ElementLab.Drugscreening.Client 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 
namespace ElementLab.Drugscreening.Client
{
    public interface IDataConverter
    {
        string Serialize<T>(T obj) where T : class;
        T Deserialize<T>(string str) where T : class;
    }
}