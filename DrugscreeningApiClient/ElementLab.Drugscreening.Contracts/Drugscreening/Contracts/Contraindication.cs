using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Описание противопоказания
    /// </summary>
    /// <summary lang="en">
    /// Base type for all contraindications
    /// </summary>
    public abstract class Contraindication : PatientResult
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