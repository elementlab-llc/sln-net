using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <inheritdoc />
    /// <summary>
    /// Предупреждение, связанное с иммуносупрессией.
    /// </summary>
    /// <summary lang="en">
    /// Defines result for the immunosuppression processing.
    /// </summary>
    
    public class Immunosuppression : PatientResult
    {
        /// <summary>
        /// Уровень риска.
        /// </summary>
        /// <summary lang="en">
        /// Severity level for this result.
        /// </summary>
        
        public ImmunosuppressionSeverityLevel Severity { get; set; }

        /// <summary>
        /// Иммуносупрессорный эффект.
        /// </summary>
        /// <summary lang="en">
        /// Immunosuppression effect for this result.
        /// </summary>
        
        public ImmunosuppressionEffect Effect { get; set; }

        ///// <summary>
        ///// Состояние, для которого имеется предупреждение.
        ///// </summary>
        ///// <summary lang="en">
        ///// Condition related to this result.
        ///// </summary>
        //public RxCondition Condition { get; set; }

        ///// <summary>
        ///// Уточняющие состояния.
        ///// </summary>
        ///// <summary lang="en">
        ///// Qualifying conditions.
        ///// </summary>
        //public IList<RxCondition> QualifiedConditions { get; set; }
    }
}