using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Базовый тип для описания результатов любых видов скрининга
    /// </summary>
    /// <summary lang="en">
    /// Base type for all results of screening types.
    /// </summary>
    public abstract class PatientResult
    {
        /// <summary>
        /// Код результата скрининга
        /// </summary>
        /// <summary lang="en">
        /// Code of the result. Unique within a scope of the request.
        /// </summary>
        
        public string Code { get; set; }
        /// <summary>
        /// Текст предупреждения
        /// </summary>
        /// <summary lang="en">
        /// Text of the alert for professional users.
        /// </summary>
        
        public string Alert { get; set; }
        /// <summary>
        /// Текст реферата для профессиональных медиков, в формате XML.
        /// </summary>
        /// <summary lang="en">
        /// Monograph for the professional users. In XML format.
        /// </summary>
        public string ProfessionalMonograph { get; set; }
        /// <summary>
        /// Список лекарственных средств, относящихся к данному результату скрининга.
        /// </summary>
        /// <summary lang="en">
        /// List of the input drugs related to this result.
        /// </summary>
        
        public IList<Drug> Drugs { get; set; }
    }
}