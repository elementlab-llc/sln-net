// **********************************************************************************************\
// Module Name:  CompetitionPeriod.cs
// Project:      ElementLab.Drugscreening.Contracts 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 
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