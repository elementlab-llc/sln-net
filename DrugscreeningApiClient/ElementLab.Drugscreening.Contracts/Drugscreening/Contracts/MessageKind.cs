// **********************************************************************************************\
// Module Name:  MessageKind.cs
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
    /// Тип сообщения
    /// </summary>
    /// <summary lang="en">
    /// Defines type of the message
    /// </summary>
    
    public enum MessageKind
    {
        /// <summary>
        /// Информация
        /// </summary>
        /// <summary lang="en">
        /// Informational message
        /// </summary>
        Information,
        /// <summary>
        /// Предупреждение
        /// </summary>
        /// <summary lang="en">
        /// Warning message
        /// </summary>
        Warning,
        /// <summary>
        /// Ошибка
        /// </summary>
        /// <summary lang="en">
        /// Error message
        /// </summary>
        Error,
        /// <summary>
        /// Критическая ошибка
        /// </summary>
        /// <summary lang="en">
        /// Critical error message
        /// </summary>
        Critical
    }
}