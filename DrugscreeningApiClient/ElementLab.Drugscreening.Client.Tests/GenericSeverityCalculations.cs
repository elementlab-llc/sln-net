// **********************************************************************************************\
// Module Name:  GenericSeverityCalculations.cs
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
using ElementLab.Drugscreening.Contracts;
using NUnit.Framework;

namespace ElementLab.Drugscreening.Client.Tests
{
    [TestFixture]
    public class GenericSeverityCalculations
    {
        [Test]
        [TestCase(0)]
        [TestCase(6)]
        public void GenericSeverity_for_Invalid_Contraindication_Severity(int level)
        {
            var result = new AgeContraindication()
            {
                Severity = new ContraindicationSeverityLevel()
                {
                    Level = level
                }
            };
            Assert.That(() => result.GetGenericSeverity(), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0)]
        [TestCase(40000)]
        public void GenericSeverity_for_Invalid_DopingAlert_Severity(int level)
        {
            var result = new DopingAlert()
            {
                Severity = new DopingAlertSeverityLevel()
                {
                    Level = level
                }
            };
            Assert.That(() => result.GetGenericSeverity(), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0)]
        [TestCase(40000)]
        public void GenericSeverity_for_Invalid_GeneticTest_Severity(int level)
        {
            var result = new GeneticTest()
            {
                Severity = new GeneticTestSeverityLevel()
                {
                    Level = level
                }
            };
            Assert.That(() => result.GetGenericSeverity(), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0)]
        [TestCase(40000)]
        public void GenericSeverity_for_Invalid_Interaction_Severity(int level)
        {
            var result = new Interaction()
            {
                Severity = new InteractionSeverityLevel()
                {
                    Level = level
                }
            };
            Assert.That(() => result.GetGenericSeverity(), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test(ExpectedResult = GenericSeverityLevel.Major)]
        public GenericSeverityLevel GenericSeverityForAllergicReactions()
        {
            var result = new AllergicReaction();
            var generic = result.GetGenericSeverity();
            return generic;
        }

        [Test]
        [TestCase(1, ExpectedResult = GenericSeverityLevel.Major)]
        [TestCase(2, ExpectedResult = GenericSeverityLevel.Major)]
        [TestCase(3, ExpectedResult = GenericSeverityLevel.Moderate)]
        [TestCase(4, ExpectedResult = GenericSeverityLevel.Minor)]
        [TestCase(5, ExpectedResult = GenericSeverityLevel.None)]
        public GenericSeverityLevel GenericSeverityForContraindications(int level)
        {
            var result = new AgeContraindication()
            {
                 Severity = new ContraindicationSeverityLevel()
                 {
                      Level = level
                 }
            };
            var generic = result.GetGenericSeverity();
            return generic;
        }

        [Test]
        [TestCase(10000, ExpectedResult = GenericSeverityLevel.Major)]
        [TestCase(20000, ExpectedResult = GenericSeverityLevel.Moderate)]
        [TestCase(30000, ExpectedResult = GenericSeverityLevel.Minor)]
        public GenericSeverityLevel GenericSeverityForDopingAlerts(int level)
        {
            var result = new DopingAlert()
            {
                Severity = new DopingAlertSeverityLevel()
                {
                    Level = level
                }
            };
            var generic = result.GetGenericSeverity();
            return generic;
        }

        [Test(ExpectedResult = GenericSeverityLevel.Moderate)]
        public GenericSeverityLevel GenericSeverityForDuplicateTherapy()
        {
            var result = new DuplicateTherapy();
            var generic = result.GetGenericSeverity();
            return generic;
        }

        [Test]
        [TestCase(10000, ExpectedResult = GenericSeverityLevel.Major)]
        [TestCase(20000, ExpectedResult = GenericSeverityLevel.Moderate)]
        [TestCase(30000, ExpectedResult = GenericSeverityLevel.Minor)]
        public GenericSeverityLevel GenericSeverityForGeneticTests(int level)
        {
            var result = new GeneticTest()
            {
                Severity = new GeneticTestSeverityLevel()
                {
                    Level = level
                }
            };
            var generic = result.GetGenericSeverity();
            return generic;
        }

        [Test]
        [TestCase(10000, ExpectedResult = GenericSeverityLevel.Major)]
        [TestCase(20000, ExpectedResult = GenericSeverityLevel.Moderate)]
        [TestCase(30000, ExpectedResult = GenericSeverityLevel.Minor)]
        public GenericSeverityLevel GenericSeverityForInteractions(int level)
        {
            var result = new Interaction()
            {
                Severity = new InteractionSeverityLevel()
                {
                    Level = level
                }
            };
            var generic = result.GetGenericSeverity();
            return generic;
        }
    }
}