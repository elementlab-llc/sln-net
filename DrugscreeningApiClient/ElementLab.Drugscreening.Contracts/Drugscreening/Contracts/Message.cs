using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Сообщение.
    /// </summary>
    /// <summary lang="en">
    /// System message
    /// </summary>
    
    public class Message
    {
        /// <summary>
        /// Код сообщения.
        /// </summary>
        /// <summary lang="en">
        /// Code of the message.
        /// </summary>
        
        public string Code { get; set; }
        /// <summary>
        /// Тип сообщения.
        /// </summary>
        /// <summary lang="en">
        /// Type of the message.
        /// </summary>
        
        public MessageKind Kind { get; set; }
        /// <summary>
        /// Текст сообщения.
        /// </summary>
        /// <summary lang="en">
        /// Text of the message.
        /// </summary>
        
        public string Text { get; set; }
        /// <summary>
        /// Данные, связанные с этим сообщением.
        /// </summary>
        /// <summary lang="en">
        /// Data related to the message.
        /// </summary>
        public object Data { get; set; }
    }
}