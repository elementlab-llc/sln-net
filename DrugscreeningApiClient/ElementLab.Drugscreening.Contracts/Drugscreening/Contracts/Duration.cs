// **********************************************************************************************\
// Module Name:  Duration.cs
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
    /// Период времени
    /// </summary>
    /// <summary lang="en">
    /// Period in time
    /// </summary>
    
    public class Duration
    {
        /// <summary>
        /// Продолжительность временного периода
        /// </summary>
        /// <summary lang="en">
        /// Length of the period in time
        /// </summary>
        
        public decimal Value { get; set; }

        /// <summary>
        /// Единица измерения времени
        /// </summary>
        /// <summary lang="en">
        /// Unit of measurements ("min", "second", "day" etc.)
        /// </summary>
        
        public string Unit { get; set; }

        /// <summary>
        /// Название периода времени.
        /// </summary>
        /// <remarks>
        /// Значение не требуется для входных параметров.
        /// </remarks>
        /// <summary lang="en">
        /// Name of this duration
        /// </summary>
        /// <remarks lang="en">
        /// Value may be omitted for input parameters.
        /// </remarks>
        public string Name { get; set; }
    }
}