using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Значение в указанных единицах измерения
    /// </summary>
    /// <summary lang="en">
    /// Defines pair of the value and unit of measurement.
    /// </summary>
    
    public class UnitMeasurement
    {
        /// <summary>
        /// Значение
        /// </summary>
        /// <summary lang="en">
        /// The value.
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// Единица измерения
        /// </summary>
        /// <summary lang="en">
        /// The unit of measurement.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UnitMeasurement()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public UnitMeasurement(decimal value, string unit)
        {
            Value = value;
            Unit = unit;
        }
    }
}