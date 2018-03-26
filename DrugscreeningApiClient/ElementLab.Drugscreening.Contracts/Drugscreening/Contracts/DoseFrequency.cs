using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Описывает частоту приема лекарственного средства (количество приемов за период времени)
    /// </summary>
    /// <summary lang="en">
    /// Used to define when doses are to be taken.  They are in the form of number of doses per interval of time.
    /// </summary>
    public class DoseFrequency
    {
        /// <summary>
        /// Количество раз
        /// </summary>
        
        public decimal Value { get; set; }
        /// <summary>
        /// Интервал времени
        /// </summary>
        
        public decimal Interval { get; set; }
        /// <summary>
        /// Единица измерения интервала времени (секунда, минута, час, день, неделя, месяц или год).
        /// </summary>
        /// <remarks>
        /// Значение можно указывать на естественном языке по-английски или по-русски (week, month, days, дней, день, месяц и т.п.).
        /// </remarks>
        
        public string IntervalUnit { get; set; }
    }
}