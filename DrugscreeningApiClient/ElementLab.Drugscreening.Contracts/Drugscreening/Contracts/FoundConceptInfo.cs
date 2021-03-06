﻿// **********************************************************************************************\
// Module Name:  FoundConceptInfo.cs
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
    /// Описывает информацию о концепте, найденном при выполении поиска
    /// </summary>
    /// <summary lang="en">
    /// Used to describe found concept.
    /// </summary>
    
    public class FoundConceptInfo: ConceptInfo
    {
        /// <summary>
        /// Наименование концепта, предназначенное для отображения в пиклисте. 
        /// Значение может отличаться от значения Name в случае, когда, например, объект описывает синоним диагноза.
        /// </summary>
        /// <summary lang="en">
        /// Name of the concept for displaying in picklist.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Оценка степени соответствия концепта поисковому запросу. 
        /// Чем выше степень соответствия, тем больше это значение.
        /// </summary>
        /// <summary lang="en">
        /// Similarity rank for the concept. Higher value - higher similarity.
        /// </summary>
        public double Score { get; set; }
    }
}