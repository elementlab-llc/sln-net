// **********************************************************************************************\
// Module Name:  ScreenableConcept.cs
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
    /// Описывает концепт, для которого может быть выполнен скрининг. 
    /// </summary>
    /// <summary lang="en">
    /// Defines a concept that may be screened.
    /// </summary>
    public abstract class ScreenableConcept : Concept
    {
        /// <summary>
        /// Признак, указывающий на необходимость выполнения скрининга в отношении этого концепта.
        /// Если значение true, то скрининг будет выполнен.
        /// </summary>
        /// <remarks>
        ///  <p>Значение по умолчанию <b>true</b>.</p>
        /// <p>Если скрининг ориентирован на пары концептов (например, скрининг взаимодействий ЛС), то будут обработаны только те пары, в которых хотя бы у одного концепта этот признак имеет значение true.</p>
        /// </remarks>
        /// <summary lang="en">
        /// This value defines whether or not this is to be screened.
        /// </summary>
        /// <remarks lang="en">
        /// <p>Default value is True</p>
        /// </remarks>
        public bool Screen { get; set; } = true;

        /// <summary>
        /// Произвольный код. Не используется сервисами скрининга.
        /// </summary>
        /// <summary lang="en">
        /// Any value. Not used by service.
        /// </summary>
        public string CustomCode { get; set; }

        /// <summary>
        /// Произвольное название. Не используется сервисами скрининга.
        /// </summary>
        /// <summary lang="en">
        /// Any value. Not used by service.
        /// </summary>
        public string CustomName { get; set; }
    }
}