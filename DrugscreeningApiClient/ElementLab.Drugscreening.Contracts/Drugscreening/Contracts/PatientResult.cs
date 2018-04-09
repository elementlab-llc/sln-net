// **********************************************************************************************\
// Module Name:  PatientResult.cs
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
    /// Описывает результат скрининга, имеющий адаптированные (пациентские) предупреждение и реферат.
    /// </summary>
    public class PatientResult : ProfessionalResult
    {
        /// <summary>
        /// Текст предупреждения для пациента.
        /// </summary>
        /// <remarks>
        /// Этот текст может отсутствовать для некоторых результатов скрининга.
        /// </remarks>
        /// <summary lang="en">
        /// Simplified alert for non-professional users.
        /// </summary>
        public string PatientAlert { get; set; }

        /// <summary>
        /// Текст реферата для пациента, в формате XML.
        /// </summary>
        /// <remarks>
        /// Этот текст может отсутствовать для некоторых результатов скрининга.
        /// </remarks>
        /// <summary lang="en">
        /// Simplified monograph for non-professional users.
        /// </summary>
        /// <remarks lang="en">
        /// In XML format.
        /// </remarks>
        public string PatientMonograph { get; set; }
    }
}