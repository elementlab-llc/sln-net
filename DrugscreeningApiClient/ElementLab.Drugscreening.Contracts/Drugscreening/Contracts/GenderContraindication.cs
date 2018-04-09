// **********************************************************************************************\
// Module Name:  GenderContraindication.cs
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
    /// Описывает противопоказания по половой принадлежности пациента
    /// </summary>
    /// <summary lang="en">
    /// Defines contraindication between drug and patient's gender.
    /// </summary>
    
    public class GenderContraindication : Contraindication
    {
        /// <summary>
        /// Пол, к которому относится это противопоказание
        /// </summary>
        /// <summary lang="en">
        /// The gender related to this contraindication.
        /// </summary>
        
        public Gender Gender { get; set; }
    }
}