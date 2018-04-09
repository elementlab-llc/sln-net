// **********************************************************************************************\
// Module Name:  Gender.cs
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
    /// Пол пациента
    /// </summary>
    /// <summary lang="en">
    /// Gender
    /// </summary>
    
    public enum Gender
    {
        /// <summary>
        /// Не указан
        /// </summary>
        /// <summary lang="en">
        /// Gender not specified or undefined (any).
        /// </summary>
        Unspecified,
        /// <summary>
        /// Мужской
        /// </summary>
        /// <summary lang="en">
        /// Male
        /// </summary>
        Male,
        /// <summary>
        /// Женский
        /// </summary>
        /// <summary lang="en">
        /// Female
        /// </summary>
        Female
    }
}