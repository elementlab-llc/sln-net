// **********************************************************************************************\
// Module Name:  WadaListReference.cs
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
    /// Описание раздела списка ВАДА
    /// </summary>
    /// <summary lang="en">
    /// Reference to WADA Prohibited List
    /// </summary>
    
    public class WadaListReference
    {
        /// <summary>
        /// Уникальный код.
        /// </summary>
        /// <summary lang="en">
        /// Code
        /// </summary>
        
        public string Code { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        /// <summary lang="en">
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на список WADA
        /// </summary>
        /// <summary lang="en">
        /// URL of WADA list
        /// </summary>
        public string Url { get; set; }
    }
}