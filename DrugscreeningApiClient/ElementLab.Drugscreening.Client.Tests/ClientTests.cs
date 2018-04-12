// **********************************************************************************************\
// Module Name:  ClientTests.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ElementLab.Drugscreening.Contracts;
using Moq;
using NUnit.Framework;

namespace ElementLab.Drugscreening.Client.Tests
{
    [TestFixture]
    public class ClientTests
    {
        [SetUp]
        public void TestInit()
        {
            _handler = new Mock<FakeHttpMessageHandler>() { CallBase = true };

            _handler
                .Setup(f => f.Send(It.Is(Request.PostTo("/account/token"))))
                .Returns((HttpRequestMessage req) => req.Anonymous(HttpStatusCode.OK, TestResponses.AccountToken));

            var connection = new ApiConnection(_handler.Object, "http://localhost", new ClientCredentials("TestUser", "TestPassword"));
            _client = new ApiClient(connection);
        }

        [TearDown]
        public void TestTeardown()
        {
            _client?.Dispose();
        }

        ApiClient _client;
        Mock<FakeHttpMessageHandler> _handler;

        [Test]
        public async Task GetConceptTypes()
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.GetOf("/concepts/types"))))
                .Returns((HttpRequestMessage req) => req.Authorized(HttpStatusCode.OK, TestResponses.GetConceptTypes));

            var types = await _client.GetConceptTypesAsync();

            Assert.That(types.Length, Is.EqualTo(2));
            Assert.That(types[0].Type, Is.EqualTo("Type1"));
            Assert.That(types[1].Type, Is.EqualTo("Type2"));
        }

        [Test]
        public async Task GetExternalConceptTypes()
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.GetOf("/concepts/types/external"))))
                .Returns((HttpRequestMessage req) => req.Authorized(HttpStatusCode.OK, TestResponses.GetExternalConceptTypes));

            var types = await _client.GetExternalConceptTypesAsync();

            Assert.That(types.Length, Is.EqualTo(2));
            Assert.That(types[0].Type, Is.EqualTo("urn:rlsnet:nomen"));
            Assert.That(types[1].Type, Is.EqualTo("urn:slovenia:cbz"));
        }

        [Test]
        public async Task ListConcepts()
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.GetOf("/concepts/list/type1"))))
                .Returns((HttpRequestMessage req) => req.Authorized(HttpStatusCode.OK, TestResponses.ListConcepts));

            var concepts = await _client.ListConceptsAsync("Type1");
            Assert.That(concepts.Concepts.Count, Is.EqualTo(1));
            Assert.That(concepts.FirstItemIndex, Is.EqualTo(0));
            Assert.That(concepts.HasMoreItems, Is.EqualTo(false));
            var c = concepts.Concepts[0];
            Assert.That(c.Code, Is.EqualTo("TST123"));
            Assert.That(c.Name, Is.EqualTo("Концепт1"));
            Assert.That(c.ResourceUrl, Is.EqualTo("http://localhost/concepts/type1?code=TST123"));
        }

        [Test]
        public async Task FindDrugByScope()
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.GetOf("/concepts/find/Drugs"))))
                .Returns((HttpRequestMessage req) => req.Authorized(() =>
                {
                    if (req.QueryParametersIs(new { q = "аспирин", searchBy = "text", limit = 50 }))
                        return req.CreateResponse(HttpStatusCode.OK, TestResponses.FindAspirinByScope);
                    return req.CreateResponse(HttpStatusCode.OK, "[]");
                }));

            var concepts = await _client.FindConceptsAsync("аспирин", SearchMethod.Text, SearchScope.Drugs);

            Assert.That(concepts.Length, Is.EqualTo(1));
            var c = concepts[0];
            Assert.That(c.Type, Is.EqualTo("DispensableDrug"));
            Assert.That(c.Code, Is.EqualTo("DD0000800"));
            Assert.That(c.Name, Is.EqualTo("Аспирин табл. 100мг"));
            Assert.That(c.ResourceUrl, Is.EqualTo("http://localhost/concepts/dispensabledrug?code=DD0000800"));
        }

        [Test]
        public async Task FindDrugByTypeByText()
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.GetOf("/concepts/find"))))
                .Returns((HttpRequestMessage req) => req.Authorized(() =>
                {
                    if (req.QueryParametersIs(new { q = "аспирин", type = "dispensableDrug,substance", searchBy = "Text", limit = 50 }))
                        return req.CreateResponse(HttpStatusCode.OK, TestResponses.FindAspirinByScope);

                    return req.CreateResponse(HttpStatusCode.OK, "[]");
                }));

            var concepts = await _client.FindConceptsAsync("аспирин", SearchMethod.Text, "DispensableDrug", "Substance");

            Assert.That(concepts.Length, Is.EqualTo(1));
            var c = concepts[0];
            Assert.That(c.Type, Is.EqualTo("DispensableDrug"));
            Assert.That(c.Code, Is.EqualTo("DD0000800"));
            Assert.That(c.Name, Is.EqualTo("Аспирин табл. 100мг"));
            Assert.That(c.ResourceUrl, Is.EqualTo("http://localhost/concepts/dispensabledrug?code=DD0000800"));
        }

        [Test]
        public async Task FindDrugByTypeByBarcode()
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.GetOf("/concepts/find"))))
                .Returns((HttpRequestMessage req) => req.Authorized(() =>
                {
                    if (req.QueryParametersIs(new { q = "4008500120002", type = "dispensableDrug", searchBy = "Barcode", limit = 50 }))
                        return req.CreateResponse(HttpStatusCode.OK, TestResponses.FindAspirinByScope);

                    return req.CreateResponse(HttpStatusCode.OK, "[]");
                }));

            var concepts = await _client.FindConceptsAsync("4008500120002", SearchMethod.Barcode, "DispensableDrug");

            Assert.That(concepts.Length, Is.EqualTo(1));
            var c = concepts[0];
            Assert.That(c.Type, Is.EqualTo("DispensableDrug"));
            Assert.That(c.Code, Is.EqualTo("DD0000800"));
            Assert.That(c.Name, Is.EqualTo("Аспирин табл. 100мг"));
            Assert.That(c.ResourceUrl, Is.EqualTo("http://localhost/concepts/dispensabledrug?code=DD0000800"));
        }

        [Test]
        public async Task FindDrugByTypeByBarcode_NoMatches()
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.GetOf("/concepts/find"))))
                .Returns((HttpRequestMessage req) => req.Authorized(HttpStatusCode.OK, "[]"));

            var concepts = await _client.FindConceptsAsync("4008500120002", SearchMethod.Barcode, "DispensableDrug");

            Assert.That(concepts.Length, Is.EqualTo(0));
        }

        [Test]
        [TestCase("DispensableDrug", "DD0009391")]
        public async Task ListInstructions(string type, string code)
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.GetOf("/instructions"))))
                .Returns((HttpRequestMessage req) => req.Authorized(() =>
                {
                    if (req.QueryParametersIs(new { type = type, code = code }))
                        return req.CreateResponse(HttpStatusCode.OK, TestResponses.InstructionsForWarfarin);

                    return req.CreateResponse(HttpStatusCode.OK, "[]");
                }));

            var items = await _client.ListInstructionsAsync(type, code);

            Assert.That(items.Length, Is.EqualTo(2));

            Assert.That(items[0].Code, Is.EqualTo("a32d6a19-a1c6-47fd-ad95-1a6e58e92212"));
            Assert.That(items[0].Name, Is.EqualTo("Варфарин, таблетки по 2,5 мг. ОЗОН, ООО (Россия)"));
            Assert.That(items[0].ContentUrl, Is.EqualTo("http://localhost/instructions/a32d6a19-a1c6-47fd-ad95-1a6e58e92212"));
        }

        [Test]
        [TestCase("a32d6a19-a1c6-47fd-ad95-1a6e58e92212")]
        public async Task GetInstructionContent(string code)
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.GetOf($"/instructions/{code}"))))
                .Returns((HttpRequestMessage req) => req.Authorized(HttpStatusCode.OK, TestResponses.ResourceManager.GetString($"Instruction_{code.Replace("-", "")}")));

            var instr = await _client.GetInstructionAsync(code);
            Assert.That(instr.Code, Is.EqualTo(code));
            Assert.That(instr.Content, Is.EqualTo("<Drug></Drug>"));
        }

        [Test]
        [TestCase("DispensableDrug", "DD0000800", "Аспирин табл. 100мг")]
        public async Task GetConcept(string type, string code, string name)
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.GetOf($"/concepts/{type}"))))
                .Returns((HttpRequestMessage req) => req.Authorized(() =>
                {
                    if (req.QueryParametersIs(new { code = code }))
                        return req.CreateResponse(HttpStatusCode.OK, TestResponses.AspirinConcept);

                    return req.CreateResponse(HttpStatusCode.NotFound, TestResponses.ResourceNotFound);
                }));

            var concept = await _client.GetConceptAsync(type, code);

            Assert.IsNotNull(concept);
            Assert.That(concept.Type, Is.EqualTo(type));
            Assert.That(concept.Code, Is.EqualTo(code));
            Assert.That(concept.Name, Is.EqualTo(name));
        }

        [Test]
        public void GetUnexistingConcept()
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.GetOf("/concepts/DispensableDrug"))))
                .Returns((HttpRequestMessage req) => req.Authorized(HttpStatusCode.NotFound, TestResponses.ResourceNotFound));

            Assert.ThrowsAsync<ApiResourceNotFoundException>(async () => await _client.GetConceptAsync("DispensableDrug", "XD0000800"));
        }

        [Test]
        public async Task ScreeningParameters()
        {
            ScreenRequest sentRequest = null;
            _handler
                .Setup(f => f.Send(It.Is(Request.PostTo("/screening"))))
                .Returns((HttpRequestMessage req) => req.Authorized(() =>
                {
                    var requestContent = req.Content.ReadAsStringAsync().Result;
                    sentRequest = ((ApiConnection)_client.Connection).Converter.Deserialize<ScreenRequest>(requestContent);

                    return req.CreateResponse(HttpStatusCode.OK, "{}");
                }));

            var request = CreateScreenRequest();
            await _client.ScreenAsync(request);

            Assert.AreEqual(request.Drugs.Count, sentRequest.Drugs.Count);
        }

        [Test]
        public async Task Screening()
        {
            _handler
                .Setup(f => f.Send(It.Is(Request.PostTo("/screening"))))
                .Returns((HttpRequestMessage req) => req.Authorized(HttpStatusCode.OK, TestResponses.AllScreenings));

            var request = CreateScreenRequest();
            var result = await _client.ScreenAsync(request);

            Assert.That(result.DrugDrugInteractions, Is.Not.Null);
            Assert.That(result.DrugFoodInteractions, Is.Not.Null);
            Assert.That(result.DrugAlcoholInteractions, Is.Not.Null);

            Assert.That(result.AllergicReactions, Is.Not.Null);
            Assert.That(result.AllergicReactions.Items.Count, Is.EqualTo(2));

            var alg1 = result.AllergicReactions.Items[0];
            Assert.That(alg1.AllergenClass, Is.EqualTo(new AllergenClass()
            {
                Type = "AllergenClass",
                Code = "ALGC0073",
                Name = "Варфарин и родственные препараты"
            }));
            Assert.That(alg1.Kind, Is.EqualTo("AllergicReactionAtClass"));
            Assert.That(alg1.Allergies[0], Is.EqualTo(request.Allergies[1]));

            Assert.That(result.AgeContraindications, Is.Not.Null);
            Assert.That(result.GenderContraindications, Is.Not.Null);
            Assert.That(result.PregnancyContraindications, Is.Not.Null);
            Assert.That(result.LactationContraindications, Is.Not.Null);
            Assert.That(result.DiseaseContraindications, Is.Not.Null);

            Assert.That(result.DuplicateTherapies, Is.Not.Null);
            Assert.That(result.DuplicateTherapies.Items.Count, Is.EqualTo(0));
            Assert.That(result.DuplicateTherapies.Messages.Count, Is.EqualTo(1));

            Assert.That(result.DopingAlerts, Is.Not.Null);
            Assert.That(result.GeneticTests, Is.Not.Null);
        }

        ScreenRequest CreateScreenRequest()
        {
            var request = new ScreenRequest()
            {
                Patient = new Patient()
                {
                    BirthDate = DateTime.Today.AddYears(-15),
                    Gender = Gender.Female,
                    Sport = new PatientSport()
                    {
                        Code = "NSP00087",
                        Name = "Сноуборд (Лыжный спорт/сноубординг (FIS))",
                        Period = CompetitionPeriod.InCompetition,
                        Role = "Athlete"
                    }
                },
                Drugs = new List<Drug>()
                {
                    new Drug()
                    {
                        Type = "Substance",
                        Code = "SUB000007",
                        Name = "Боластерон"
                    },
                    new Drug()
                    {
                        Type = "DispensableDrug",
                        Code = "DD0000800",
                        Name = "Аспирин табл. 100мг",
                        Schedule = new AdministrationSchedule()
                        {
                            FirstAdministration = DateTime.Today.AddDays(-1),
                            LastAdministration = DateTime.Today.AddDays(4)
                        }
                    },
                    new Drug()
                    {
                        Type = "DispensableDrug",
                        Code = "DD0009389",
                        Name = "Варфарекс табл. 3мг"
                    }
                },
                Allergies = new List<Allergy>()
                {
                    new Allergy()
                    {
                        Type = "AllergenClass",
                        Code = "ALGC0029",
                        Name = "Салицилаты"
                    },
                    new Allergy()
                    {
                        Type = "ScreenableIngredient",
                        Code = "SI002679",
                        Name = "Варфарин"
                    }
                },
                Diseases = new List<Disease>()
                {
                    new Disease()
                    {
                        Type = "ICD10CM",
                        Code = "D69.5",
                        Name = "Вторичная тромбоцитопения"
                    }
                },
                Options = new ScreeningOptions()
                {
                    IncludeMonographs = false,
                    IncludeInsignificantInactiveIngredients = true
                }
            };
            return request;
        }
    }
}
