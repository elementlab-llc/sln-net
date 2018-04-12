// **********************************************************************************************\
// Module Name:  ConceptInfo.cs
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
    /// Описание концепта
    /// </summary>
    /// <summary lang="en">
    /// Description of the concept
    /// </summary>
    public class ConceptInfo : Concept
    {
        /// <summary>
        /// Адрес ресурса, обратившись к которому можно получить описание этого концепта.
        /// </summary>
        /// <summary lang="en">
        /// The address of the resource, referring to which you can get a description of this concept.
        /// </summary>
        
        public string ResourceUrl { get; set; }

        /// <summary>
        /// Дополнительные свойства концепта
        /// </summary>
        /// <summary lang="en">
        /// Additional properties of the concept.
        /// </summary>
        public object ExtendedProperties { get; set; }
    }
}