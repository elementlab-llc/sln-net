﻿// **********************************************************************************************\
// Module Name:  PatientSport.cs
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
    /// Описывает вид спорта, которым занимается пациент, с возможностью уточнения периода соревнований.
    /// </summary>
    
    public class PatientSport
    {
        /// <summary>
        /// Код вида спорта.
        /// </summary>
        /// <summary lang="en">
        /// Code of the sports.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Наименование вида спорта.
        /// </summary>
        /// <summary lang="en">
        /// Name of the sports.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Соревновательный период.
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию Unspecified
        /// </remarks>
        /// <summary lang="en">
        /// Period of the competitions.
        /// </summary>
        public CompetitionPeriod Period { get; set; }

        /// <summary>
        /// Код концепта RoleInSports, описывающий роль пациента в спорте (Спортсмен, Тренер и т.п.)
        /// </summary>
        /// <summary lang="en">
        /// Role of the patient in specified sports.
        /// </summary>
        public string Role { get; set; }
    }
}