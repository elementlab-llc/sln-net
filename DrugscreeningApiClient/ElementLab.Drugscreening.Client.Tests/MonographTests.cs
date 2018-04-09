// **********************************************************************************************\
// Module Name:  MonographTests.cs
// Project:      ElementLab.Drugscreening.Client.Tests 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using ElementLab.Drugscreening.Contracts;
using NUnit.Framework;

namespace ElementLab.Drugscreening.Client.Tests
{
    [TestFixture]
    public class MonographTests
    {
        [Test]
        public void XmlToHtmlTransform()
        {
            var result = new DopingAlert()
            {
                ProfessionalMonograph = TestResponses.SimpleMonographXml
            };

            var html = result.GetProfessionalMonographHtml();
            Assert.That(html, Is.Not.Empty);
        }
    }
}
