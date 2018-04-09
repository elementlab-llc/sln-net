// **********************************************************************************************\
// Module Name:  ConceptType.cs
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
    /// Описывает тип концепта
    /// </summary>
    /// <summary lang="en">
    /// Describes type of the concept
    /// </summary>
    public sealed class ConceptType
    {
        /// <summary>
        /// Код типа концепта
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Название типа концепта
        /// </summary>
        public string Name { get; set; }
    }
}