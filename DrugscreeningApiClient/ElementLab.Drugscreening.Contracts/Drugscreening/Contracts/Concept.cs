using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Базовый тип, предоставляющий информацию, общую для всех концептов, имеющихся в системе.
    /// </summary>
    /// <summary lang="en">
    /// Base type for all concepts.
    /// </summary>
    [DebuggerDisplay("{Type} - {Name} ({Code})")]
    
    public class Concept
    {
        /// <summary>
        /// Тип концепта.
        /// </summary>
        /// <summary lang="en">
        /// Type of this concept.
        /// </summary>
        
        public string Type { get; set; }
        /// <summary>
        /// Код, идентифицирующий концепт.
        /// </summary>
        /// <example>Например, для лекарственных средств идентификатором является уникальное целое число. 
        /// Для диагнозов из справочника МКБ-10 идентификатором является код, указанный в справочнике.</example>
        /// <summary lang="en">
        /// Unique code within a given type of concept.
        /// </summary>
        
        public string Code { get; set; }
        /// <summary>
        /// Наименование концепта.
        /// </summary>
        /// <summary lang="en">
        /// Name of this concept.
        /// </summary>
        
        public string Name { get; set; }
    }
}