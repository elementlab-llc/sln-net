// **********************************************************************************************\
// Module Name:  JsonDataConverter.cs
// Project:      ElementLab.Drugscreening.Client 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ElementLab.Drugscreening.Client
{
    public class JsonDataConverter: IDataConverter
    {
        static readonly JsonSerializerSettings _serializationSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = { new StringEnumConverter() },
            DateFormatString = "yyyy-MM-dd",
            DateTimeZoneHandling = DateTimeZoneHandling.Local,
            Formatting = Formatting.Indented
        };

        public string Serialize<T>(T obj) where T : class
        {
            return JsonConvert.SerializeObject(obj, _serializationSettings);
        }

        public T Deserialize<T>(string str) where T : class
        {
            return JsonConvert.DeserializeObject<T>(str, _serializationSettings);
        }
    }
}
