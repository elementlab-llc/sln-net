// **********************************************************************************************\
// Module Name:  Contraindication.cs
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
    /// Описание противопоказания
    /// </summary>
    /// <summary lang="en">
    /// Base type for all contraindications
    /// </summary>
    public abstract class Contraindication : ProfessionalResult
    {
        /// <summary>
        /// Уровень риска, связанный с противопоказанием.
        /// </summary>
        /// <summary lang="en">
        /// Level of the severity for this contraindication.
        /// </summary>
        
        public ContraindicationSeverityLevel Severity { get; set; }

        /// <summary>
        /// Состояние, для которого имеется противопоказание.
        /// </summary>
        /// <summary lang="en">
        /// Condition related to this contraindication.
        /// </summary>
        
        public Condition Condition { get; set; }
    }
}