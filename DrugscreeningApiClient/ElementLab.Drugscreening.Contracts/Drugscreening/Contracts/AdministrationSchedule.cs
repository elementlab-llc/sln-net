using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Схема приема лекарственного средства.
    /// </summary>
    /// <remarks>
    /// Длительность приема может определена указанием значения либо для поля LastAdministration,
    /// либо для поля Duration. Если указаны значения обоих полей, используется значение Duration.
    /// </remarks>
    /// 
    /// <summary lang="en">
    /// Defines drug adminstration schedule.
    /// </summary>
    /// <remarks lang="en">
    /// Duration could be specified by <i>LastAdministration</i> field, or by Duration field.
    /// If both values are specified Duration field value is used.
    /// </remarks>
    public class AdministrationSchedule
    {
        /// <summary>
        /// Дата первого приема.
        /// </summary>
        public DateTime FirstAdministration { get; set; }
        /// <summary>
        /// Дата последнего приема.
        /// </summary>
        public DateTime? LastAdministration { get; set; }
        /// <summary>
        /// Длительность приема лекарственного средства.
        /// </summary>
        public Duration Duration { get; set; }
    }
}