// **********************************************************************************************\
// Module Name:  SearchMethod.cs
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
    /// Способ поиска
    /// </summary>
    /// <summary lang="en">
    /// Modes of searching for concepts.
    /// </summary>
    public enum SearchMethod
    {
        /// <summary>
        /// Нечеткий поиск по тексту
        /// </summary>
        /// <summary lang="en">
        /// Fuzzy search by input text.
        /// </summary>
        Text,
        /// <summary>
        /// Точный поиск по штрих-коду
        /// </summary>
        /// <summary lang="en">
        /// Exact search by barcode. Supported for DispensableDrug and DietarySupplement only.
        /// </summary>
        Barcode,
        /// <summary>
        /// Точный поиск по названию концепта
        /// </summary>
        /// <summary lang="en">
        /// Exact search by name.
        /// </summary>
        ExactName
    }
}
