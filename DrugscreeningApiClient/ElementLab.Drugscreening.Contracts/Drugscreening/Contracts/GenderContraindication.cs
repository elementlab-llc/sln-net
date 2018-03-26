using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Описывает противопоказания по половой принадлежности пациента
    /// </summary>
    /// <summary lang="en">
    /// Defines contraindication between drug and patient's gender.
    /// </summary>
    
    public class GenderContraindication : Contraindication
    {
        /// <summary>
        /// Пол, к которому относится это противопоказание
        /// </summary>
        /// <summary lang="en">
        /// The gender related to this contraindication.
        /// </summary>
        
        public Gender Gender { get; set; }
    }
}