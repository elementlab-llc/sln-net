using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Описывает содержимое инструкции
    /// </summary>
    /// <summary lang="en">
    /// Describes instruction's content
    /// </summary>
    
    public class InstructionContent
    {
        /// <summary>
        /// Код инструкции
        /// </summary>
        /// <summary lang="en">
        /// Code of the instruction
        /// </summary>
        
        public string Code { get; set; }
        /// <summary>
        /// Название инструкции
        /// </summary>
        /// <summary lang="en">
        /// Title of the instruction
        /// </summary>
        
        public string Name { get; set; }
        /// <summary>
        /// Адрес ресурса, обратившись к которому можно получить эту инструкцию
        /// </summary>
        /// <summary lang="en">
        /// URI for this instruction's content
        /// </summary>
        
        public string ResourceUrl { get; set; }
        /// <summary>
        /// Содержимое инструкции в формате XML
        /// </summary>
        /// <summary lang="en">
        /// Instruction's content in XML format
        /// </summary>
        
        public string Content { get; set; }
    }
}