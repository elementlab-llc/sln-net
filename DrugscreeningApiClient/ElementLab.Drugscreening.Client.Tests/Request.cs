// **********************************************************************************************\
// Module Name:  Request.cs
// Project:      ElementLab.Drugscreening.Client.Tests 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace ElementLab.Drugscreening.Client.Tests
{
    static class Request
    {
        public static Expression<Func<HttpRequestMessage, bool>> GetOf(string uri)
        {
            return r => r.Method == HttpMethod.Get && r.RequestUri.AbsolutePath.Equals(uri, StringComparison.OrdinalIgnoreCase);
        }

        public static Expression<Func<HttpRequestMessage, bool>> PostTo(string uri)
        {
            return r => r.Method == HttpMethod.Post && r.RequestUri.AbsolutePath.Equals(uri, StringComparison.OrdinalIgnoreCase);
        }

        public static HttpResponseMessage Anonymous(this HttpRequestMessage request, Func<HttpResponseMessage> func)
        {
            return func();
        }

        public static HttpResponseMessage Anonymous(this HttpRequestMessage request, HttpStatusCode statusCode, string content)
        {
            return request.Anonymous(() => request.CreateResponse(statusCode, content));
        }

        public static HttpResponseMessage Authorized(this HttpRequestMessage request, Func<HttpResponseMessage> func)
        {
            var auth = request.Headers.Authorization;
            if (auth != null && "Bearer".Equals(auth.Scheme, StringComparison.OrdinalIgnoreCase) && auth.Parameter == "TestToken")
                return func();

            return request.CreateResponse(HttpStatusCode.Unauthorized, null);
        }

        public static HttpResponseMessage Authorized(this HttpRequestMessage request, HttpStatusCode statusCode, string content)
        {
            return request.Authorized(() => request.CreateResponse(statusCode, content));
        }

        public static HttpResponseMessage CreateResponse(this HttpRequestMessage request, HttpStatusCode statusCode, string content)
        {
            var response = new HttpResponseMessage(statusCode)
            {
                RequestMessage = request
            };

            if (content != null)
                response.Content = new StringContent(content, Encoding.UTF8, "application/json");

            return response;
        }

        public static bool QueryParametersIs(this HttpRequestMessage request, object parameters)
        {
            var expectedPairs = from PropertyDescriptor pd in TypeDescriptor.GetProperties(parameters)
                                 let value = Convert.ToString(pd.GetValue(parameters))
                                 where !string.IsNullOrWhiteSpace(value)
                                 select new { Name = pd.Name, Value = value };

            var expected = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
            foreach (var e in expectedPairs)
                expected.Add(e.Name, e.Value);

            var actual = HttpUtility.ParseQueryString(request.RequestUri.Query);

            if (expected.Count != actual.Count)
                return false;

            var comparer = StringComparer.OrdinalIgnoreCase;
            return expected.AllKeys.OrderBy(key => key, comparer).SequenceEqual(actual.AllKeys.OrderBy(key => key, comparer), comparer)
                   && expected.AllKeys
                       .All(key => expected.GetValues(key).OrderBy(val => val, comparer)
                           .SequenceEqual(actual.GetValues(key).OrderBy(val => val, comparer), comparer));
        }
    }
}