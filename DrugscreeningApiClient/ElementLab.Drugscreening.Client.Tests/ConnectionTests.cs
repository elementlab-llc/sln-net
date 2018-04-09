// **********************************************************************************************\
// Module Name:  ConnectionTests.cs
// Project:      ElementLab.Drugscreening.Client.Tests 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using System.Net;
using System.Net.Http;
using ElementLab.Drugscreening.Contracts;
using Moq;
using NUnit.Framework;

namespace ElementLab.Drugscreening.Client.Tests
{
    [TestFixture]
    public class ConnectionTests
    {
        [SetUp]
        public void TestInit()
        {
            _handler = new Mock<FakeHttpMessageHandler>() { CallBase = true };
            _connection = new ApiConnection(_handler.Object, "http://localhost", new ClientCredentials("TestUser", "TestPassword"));
        }

        [TearDown]
        public void TestTeardown()
        {
            _connection?.Dispose();
        }

        IApiConnection _connection;
        Mock<FakeHttpMessageHandler> _handler;

        public void TestAuthorization()
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.PostTo("/account/token"))))
                .Returns((HttpRequestMessage req) =>
                {

                    return req.Anonymous(HttpStatusCode.OK, TestResponses.AccountToken);
                });

        }
    }
}