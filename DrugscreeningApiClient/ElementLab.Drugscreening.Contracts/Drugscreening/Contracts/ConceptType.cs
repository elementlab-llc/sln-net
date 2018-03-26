using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Тип концепта
    /// </summary>
    /// <summary lang="en">
    /// Describes type of the concept
    /// </summary>
    public sealed class ConceptType
    {
        /// <summary>
        /// Код типа концепта
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Название типа концепта
        /// </summary>
        public string Name { get; set; }
    }
}