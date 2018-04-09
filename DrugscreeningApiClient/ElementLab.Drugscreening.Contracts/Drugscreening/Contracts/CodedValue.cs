// **********************************************************************************************\
// Module Name:  CodedValue.cs
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
    /// 
    /// </summary>
    
    public class CodedValue
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
    }
}