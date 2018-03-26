using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Описание концепта
    /// </summary>
    /// <summary lang="en">
    /// Description of the concept
    /// </summary>
    
    public class ConceptInfo : Concept
    {
        /// <summary>
        /// Системный идентификатор концепта.
        /// </summary>
        /// <summary lang="en">
        /// Internal identifier of the concept.
        /// </summary>
        
        public int UniqueId { get; set; }
        /// <summary>
        /// Адрес ресурса, обратившись к которому можно получить описание этого концепта.
        /// </summary>
        /// <summary lang="en">
        /// The address of the resource, referring to which you can get a description of this concept.
        /// </summary>
        
        public string ResourceUrl { get; set; }
        /// <summary>
        /// Дополнительные свойства концепта
        /// </summary>
        /// <summary lang="en">
        /// Additional properties of the concept.
        /// </summary>
        public object ExtendedProperties { get; set; }
    }
}