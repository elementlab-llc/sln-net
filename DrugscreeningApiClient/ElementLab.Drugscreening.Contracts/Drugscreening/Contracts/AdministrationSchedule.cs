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
    /// Описывает расписание и схему приема лекарственного средства.
    /// </summary>
    /// 
    /// <summary lang="en">
    /// Defines drug adminstration schedule and schema.
    /// </summary>
    public class AdministrationSchedule
    {
        /// <summary>
        /// Дата первого приема. Обязательный параметр.
        /// </summary>
        /// <summary lang="en">
        /// Date of the first administration.
        /// </summary>
        public DateTime FirstAdministration { get; set; }

        /// <summary>
        /// Дата последнего приема. Необязательный параметр, может быть null.
        /// </summary>
        /// <summary lang="en">
        /// Date of the last administration. Optional, may be null.
        /// </summary>
        public DateTime? LastAdministration { get; set; }

        /// <summary>
        /// Схема приема в виде текста. Необязательный параметр.
        /// </summary>
        public string Schema { get; set; }
    }
}