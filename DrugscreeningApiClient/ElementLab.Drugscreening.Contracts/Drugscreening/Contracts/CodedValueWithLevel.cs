// **********************************************************************************************\
// Module Name:  CodedValueWithLevel.cs
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
    /// Концепт, характеризующийся некоторым "уровнем"
    /// </summary>
    
    public class CodedValueWithLevel : CodedValue
    {
        /// <summary>
        /// Числовое значение уровня.
        /// </summary>
        /// <remarks>
        /// В большинстве случаев, чем меньше значение, тем выше описываемый уровень.
        /// </remarks>
        
        public int Level { get; set; }
    }
}