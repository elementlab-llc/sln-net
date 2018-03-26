using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Концепт, характеризующийся некоторым "уровнем"
    /// </summary>
    
    public class CodedValueWithLevel : CodedValue
    {
        /// <summary>
        /// Числовое значение уровня.
        /// </summary>
        /// <remarks>
        /// В большинстве случаев, чем меньше значение, тем выше описываемый уровень.
        /// </remarks>
        
        public int Level { get; set; }
    }
}