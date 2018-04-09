// **********************************************************************************************\
// Module Name:  DopingAlert.cs
// Project:      ElementLab.Drugscreening.Contracts 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using System.Collections.Generic;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Допинг-контроль
    /// </summary>
    /// <summary lang="en">
    /// Describes the result of doping-alert screening.
    /// </summary>
    
    public class DopingAlert : ProfessionalResult
    {
        /// <summary>
        /// Код класса предупреждения.
        /// </summary>
        /// <summary lang="en">
        /// Code alert class
        /// </summary>
        public string AlertClass { get; set; }

        /// <summary>
        /// Тип предупреждения.
        /// </summary>
        /// <summary lang="en">
        /// Type of the alert
        /// </summary>
        
        public string Kind { get; set; }

        /// <summary>
        /// Уровень риска.
        /// </summary>
        /// <summary lang="en">
        /// Severity level
        /// </summary>
        
        public DopingAlertSeverityLevel Severity { get; set; }

        /// <summary>
        /// Субстанция, вызывающая положительный результат при допинг-контроле.
        /// </summary>
        /// <summary lang="en">
        /// Substance
        /// </summary>
        public Concept Substance { get; set; }

        /// <summary>
        /// Список видов спорта, для которых запрещено использование субстанции и содержащих её препаратов.
        /// </summary>
        public ICollection<Concept> Sports { get; set; }

        /// <summary>
        /// true, если использование субстанции разрешено во внесоревновательный период.
        /// </summary>
        public bool AllowedOutOfCompetition { get; set; }

        /// <summary>
        /// true, если использование субстанции разрешено женщинам.
        /// </summary>
        public bool AllowedForFemales { get; set; }

        /// <summary>
        /// Описание раздела списка ВАДА
        /// </summary>
        /// <summary lang="en">
        /// Reference to WADA Prohibited List
        /// </summary>
        public WadaListReference ListSection { get; set; }
    }
}