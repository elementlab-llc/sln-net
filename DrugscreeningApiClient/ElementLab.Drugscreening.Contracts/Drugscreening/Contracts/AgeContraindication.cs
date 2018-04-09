// **********************************************************************************************\
// Module Name:  AgeContraindication.cs
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
    /// Описание противопоказания по возрастному признаку
    /// </summary>
    /// <summary lang="en">
    /// Describes age contraindication for drug
    /// </summary>
    public class AgeContraindication : Contraindication
    {
        /// <summary>
        /// Нижняя граница возраста
        /// </summary>
        /// <summary lang="en">
        /// Beginning age for the contraindication.
        /// </summary>
        public Duration AgeLow { get; set; }

        /// <summary>
        /// Верхняя граница возраста
        /// </summary>
        /// <summary lang="en">
        /// Ending age for the contraindication.
        /// </summary>
        public Duration AgeHigh { get; set; }
    }
}