using System;
using System.Collections.Generic;
using System.Linq;

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