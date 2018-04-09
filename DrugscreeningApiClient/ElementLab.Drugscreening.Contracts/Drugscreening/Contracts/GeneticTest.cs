// **********************************************************************************************\
// Module Name:  GeneticTest.cs
// Project:      ElementLab.Drugscreening.Contracts 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 
namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Предупреждение, связанное с фармакогенетическим тестированием.
    /// </summary>
    /// <summary lang="en">
    /// Used to define the pharmacogenetic testing recommendation.
    /// </summary>
    
    public class GeneticTest : ProfessionalResult
    {
        /// <summary>
        /// Уровень риска.
        /// </summary>
        /// <summary lang="en">
        /// Severity level for this result.
        /// </summary>
        
        public GeneticTestSeverityLevel Severity { get; set; }

        /// <summary>
        /// Степень необходимого вмешательства.
        /// </summary>
        /// <summary lang="en">
        /// Management level for this result.
        /// </summary>
        public CodedValueWithLevel Management { get; set; }

        /// <summary>
        /// Степень изученности.
        /// </summary>
        /// <summary lang="en">
        /// Documentation level for this result.
        /// </summary>
        public CodedValueWithLevel Documentation { get; set; }
    }
}