using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Соревновательный период.
    /// </summary>
    /// <summary lang="en">
    /// Competition period.
    /// </summary>
    public enum CompetitionPeriod
    {
        /// <summary>
        /// Не указано.
        /// </summary>
        /// <summary lang="en">
        /// Any period.
        /// </summary>
        Unspecified,
        /// <summary>
        /// Вне соревнований.
        /// </summary>
        /// <summary lang="en">
        /// Out-of-competition period.
        /// </summary>
        OutOfCompetition,
        /// <summary>
        /// Во время соревнований.
        /// </summary>
        /// <summary lang="en">
        /// In-competition period.
        /// </summary>
        InCompetition
    }
}