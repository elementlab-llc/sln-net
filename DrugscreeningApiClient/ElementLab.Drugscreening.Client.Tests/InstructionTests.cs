using ElementLab.Drugscreening.Contracts;
using NUnit.Framework;

namespace ElementLab.Drugscreening.Client.Tests
{
    [TestFixture]
    public class InstructionTests
    {
        [Test]
        public void XmlToHtmlTransform()
        {
            var c = new InstructionContent()
            {
                Content = TestResponses.InstructionContent_a32d6a19a1c647fdad951a6e58e92212
            };

            var html = c.GetContentAsHtml();
            Assert.That(html, Is.Not.Empty);
            TestContext.WriteLine(html);
        }
    }
}