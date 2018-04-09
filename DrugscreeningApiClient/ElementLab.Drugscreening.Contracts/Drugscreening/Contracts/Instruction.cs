// **********************************************************************************************\
// Module Name:  Instruction.cs
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
    /// Описывает инструкцию к лекарственному препарату или БАД.
    /// </summary>
    /// <summary lang="en">
    /// Defines instruction manual for medicine drug or dietary supplement.
    /// </summary>
    
    public class Instruction
    {
        /// <summary>
        /// Код инструкции
        /// </summary>
        /// <summary lang="en">
        /// Code of the instruction
        /// </summary>
        
        public string Code { get; set; }

        /// <summary>
        /// Название инструкции
        /// </summary>
        /// <summary lang="en">
        /// Title of the instruction
        /// </summary>
        
        public string Name { get; set; }

        /// <summary>
        /// URL для получения содержимого инструкции в формате XML
        /// </summary>
        /// <summary lang="en">
        /// Instruction's content URL
        /// </summary>
        
        public string ContentUrl { get; set; }
    }
}
