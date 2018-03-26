using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <summary lang="en">
    /// Renal function
    /// </summary>
    
    public class RenalFunction : List<UnitMeasurement>
    {
        /// <summary>
        /// Создает объект класса RxRenalFunction
        /// </summary>
        public RenalFunction()
            : base()
        {
        }

        /// <summary>
        /// Создает объект класса RxRenalFunction
        /// </summary>
        /// <param name="source"></param>
        public RenalFunction(IEnumerable<UnitMeasurement> source)
            : base(source)
        {
        }

        /// <summary>
        /// Создает объект класса RxRenalFunction
        /// </summary>
        public RenalFunction(UnitMeasurement unitMeasurement)
            : base(1)
        {
            if (unitMeasurement == null) throw new ArgumentNullException(nameof(unitMeasurement));
            this.Add(unitMeasurement);
        }

        /// <summary>
        /// Создает объект класса RxRenalFunction
        /// </summary>
        public RenalFunction(decimal value, string unit)
            : base(1)
        {
            this.Add(new UnitMeasurement(value, unit));
        }
    }
}