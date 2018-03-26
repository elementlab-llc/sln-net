using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Пол пациента
    /// </summary>
    /// <summary lang="en">
    /// Gender
    /// </summary>
    
    public enum Gender
    {
        /// <summary>
        /// Не указан
        /// </summary>
        /// <summary lang="en">
        /// Gender not specified or undefined (any).
        /// </summary>
        Unspecified,
        /// <summary>
        /// Мужской
        /// </summary>
        /// <summary lang="en">
        /// Male
        /// </summary>
        Male,
        /// <summary>
        /// Женский
        /// </summary>
        /// <summary lang="en">
        /// Female
        /// </summary>
        Female
    }
}