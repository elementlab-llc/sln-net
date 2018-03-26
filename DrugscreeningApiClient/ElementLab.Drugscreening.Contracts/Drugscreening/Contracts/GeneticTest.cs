using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Предупреждение, связанное с фармакогенетическим тестированием.
    /// </summary>
    /// <summary lang="en">
    /// Used to define the pharmacogenetic testing recommendation.
    /// </summary>
    
    public class GeneticTest : PatientResult
    {
        /// <summary>
        /// Уровень риска.
        /// </summary>
        /// <summary lang="en">
        /// Severity level for this result.
        /// </summary>
        
        public CodedValueWithLevel Severity { get; set; }
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