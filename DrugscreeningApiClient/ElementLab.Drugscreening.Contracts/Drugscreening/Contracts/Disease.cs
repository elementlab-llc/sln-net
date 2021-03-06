﻿// **********************************************************************************************\
// Module Name:  Disease.cs
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
    /// Диагноз/заболевание.
    /// </summary>
    /// <summary lang="en">
    /// Disease
    /// </summary>
    public class Disease : ScreenableConcept
    {
        /// <summary>
        /// Признак основного заболевания.
        /// </summary>
        public bool IsPrimary { get; set; }
    }
}