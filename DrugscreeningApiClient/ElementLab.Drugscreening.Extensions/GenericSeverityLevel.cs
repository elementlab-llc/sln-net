// **********************************************************************************************\
// Module Name:  GenericSeverityLevel.cs
// Project:      ElementLab.Drugscreening.Extensions 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 
namespace ElementLab.Drugscreening
{
    /// <summary>
    /// Обобщенный уровень риска, независимый от вида скрининга
    /// </summary>
    public enum GenericSeverityLevel
    {
        /// <summary>
        /// Высокий риск
        /// </summary>
        Major,
        /// <summary>
        /// Средний риск
        /// </summary>
        Moderate,
        /// <summary>
        /// Низкий риск
        /// </summary>
        Minor,
        /// <summary>
        /// Риск отсутствует
        /// </summary>
        None
    }
}