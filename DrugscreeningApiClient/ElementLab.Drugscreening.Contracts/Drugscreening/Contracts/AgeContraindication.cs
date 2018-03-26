using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Описание противопоказания по возрастному признаку
    /// </summary>
    /// <summary lang="en">
    /// Describes age contraindication for drug
    /// </summary>
    
    public class AgeContraindication : Contraindication
    {
        /// <summary>
        /// Нижняя граница возраста
        /// </summary>
        /// <summary lang="en">
        /// Beginning age for the contraindication.
        /// </summary>
        public Duration AgeLow { get; set; }
        /// <summary>
        /// Верхняя граница возраста
        /// </summary>
        /// <summary lang="en">
        /// Ending age for the contraindication.
        /// </summary>
        public Duration AgeHigh { get; set; }
    }
}