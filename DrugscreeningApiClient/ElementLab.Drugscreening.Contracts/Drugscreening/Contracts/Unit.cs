using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Единица измерения
    /// </summary>
    /// <summary lang="en">
    /// Unit of measurement.
    /// </summary>
    
    public class Unit: CodedValue
    {
        /// <summary>
        /// Тип единицы измерения
        /// </summary>
        /// <summary lang="en">
        /// Type of the unit
        /// </summary>
        public UnitType UnitType { get; set; }
    }
}