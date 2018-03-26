using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    
    public class CodedValue
    {
        /// <summary>
        /// Уникальный код.
        /// </summary>
        /// <summary lang="en">
        /// Code
        /// </summary>
        
        public string Code { get; set; }
        /// <summary>
        /// Название.
        /// </summary>
        /// <summary lang="en">
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}