// **********************************************************************************************\
// Module Name:  AdministrationSchedule.cs
// Project:      ElementLab.Drugscreening.Contracts 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using System;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Схема приема лекарственного средства.
    /// </summary>
    /// 
    /// <summary lang="en">
    /// Defines drug adminstration schedule.
    /// </summary>
    public class AdministrationSchedule
    {
        /// <summary>
        /// Дата первого приема.
        /// </summary>
        public DateTime FirstAdministration { get; set; }

        /// <summary>
        /// Дата последнего приема. Значение может быть опущено.
        /// </summary>
        public DateTime? LastAdministration { get; set; }
    }
}