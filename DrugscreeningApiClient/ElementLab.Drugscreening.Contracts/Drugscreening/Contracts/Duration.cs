using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Период времени
    /// </summary>
    /// <summary lang="en">
    /// Period in time
    /// </summary>
    
    public class Duration
    {
        /// <summary>
        /// Продолжительность временного периода
        /// </summary>
        /// <summary lang="en">
        /// Length of the period in time
        /// </summary>
        
        public decimal Value { get; set; }
        /// <summary>
        /// Единица измерения времени
        /// </summary>
        /// <summary lang="en">
        /// Unit of measurements ("min", "second", "day" etc.)
        /// </summary>
        
        public string Unit { get; set; }
        /// <summary>
        /// Название периода времени.
        /// </summary>
        /// <remarks>
        /// Значение не требуется для входных параметров.
        /// </remarks>
        /// <summary lang="en">
        /// Name of this duration
        /// </summary>
        /// <remarks lang="en">
        /// Value may be omitted for input parameters.
        /// </remarks>
        public string Name { get; set; }
    }
}