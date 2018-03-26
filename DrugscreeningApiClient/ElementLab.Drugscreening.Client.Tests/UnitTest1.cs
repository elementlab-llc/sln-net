using System;
using System.Globalization;
using System.Threading.Tasks;
using ElementLab.Drugscreening.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElementLab.Drugscreening.Client.Tests
{
    [TestClass]
    public class UnitTest1
    {
        ApiClient _client;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            _client = new ApiClient("https://testint.drugscreening.ru/v1", new ClientCredentials("SYSTEM", "1qaz2WSX3edc4RFV"));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _client.Dispose();
        }

        [TestMethod]
        public async Task TestMethod1()
        {

            var types = await _client.GetConceptTypesAsync();
            foreach (var t in types)
                TestContext.WriteLine($"{t.Type} \"{t.Name}\"");
        }

        [TestMethod]
        public async Task TestSearch()
        {
            await SearchFor("варфарин", new[] { "DispensableDrug" }, "DD0009391", "Варфарин табл. 2.5мг");
        }

        [TestMethod]
        public async Task TestListConcepts()
        {
            var concepts = await _client.ListConcepts("InteractionManagementLevel");
            foreach (var c in concepts)
                TestContext.WriteLine($"[{c.Code}] \"{c.Name}\"");
        }

        async Task SearchFor(string query, string[] types, string expectedSid, string expectedName)
        {
            var found = await _client.FindConceptsAsync(query, SearchMethod.Text, types);

            Assert.IsTrue(found.Length > 0, "Не найден");

            var fc = found[0];
            Assert.AreEqual(expectedSid, fc.Code);
            Assert.AreEqual(expectedName, fc.Name);
        }
    }
}
