using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Доза лекарственного средства на один прием
    /// </summary>
    /// <exexample>
    /// 1 таблетка, 2 капсулы, 5 капель, 1 ед/кг
    /// </exexample>
    /// <summary lang="en">
    /// Used to define single dose of the drug to be taken.
    /// </summary>
    /// <example lang="en">
    /// 1 tablet, 2 capsules, 5 drops, 1ME/kg
    /// </example>
    
    public class DrugDose : List<UnitMeasurement>
    {
        /// <summary>
        /// Создает объект класса RxDose
        /// </summary>
        public DrugDose()
            : base()
        {
        }

        /// <summary>
        /// Создает объект класса RxDose
        /// </summary>
        /// <param name="source"></param>
        public DrugDose(IEnumerable<UnitMeasurement> source)
            : base(source)
        {
        }

        /// <summary>
        /// Создает объект класса RxDose
        /// </summary>
        public DrugDose(UnitMeasurement unitMeasurement)
            : base(1)
        {
            if (unitMeasurement == null) throw new ArgumentNullException(nameof(unitMeasurement));
            Add(unitMeasurement);
        }

        /// <summary>
        /// Создает объект класса RxDose
        /// </summary>
        public DrugDose(decimal value, string unit)
            : base(1)
        {
            Add(new UnitMeasurement(value, unit));
        }
    }
}