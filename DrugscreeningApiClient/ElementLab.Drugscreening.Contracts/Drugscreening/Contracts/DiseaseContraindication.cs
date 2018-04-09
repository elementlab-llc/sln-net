// **********************************************************************************************\
// Module Name:  DiseaseContraindication.cs
// Project:      ElementLab.Drugscreening.Contracts 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using System.Collections.Generic;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Описывает противопоказание при диагнозе, поставленном пациенту.
    /// </summary>
    /// <summary lang="en">
    /// Describes contraindication between drug and disease.
    /// </summary>
    
    public class DiseaseContraindication : Contraindication
    {
        /// <summary>
        /// Список диагнозов, имеющихся у пациента, к которым относится данное противопоказание.
        /// </summary>
        /// <summary lang="en">
        /// List of diseases related to this contraindication.
        /// </summary>
        
        public IList<Disease> Diseases { get; set; }
    }
}