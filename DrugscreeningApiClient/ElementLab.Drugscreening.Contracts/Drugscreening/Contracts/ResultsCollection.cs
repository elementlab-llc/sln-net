// **********************************************************************************************\
// Module Name:  ResultsCollection.cs
// Project:      ElementLab.Drugscreening.Contracts 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using System.Collections.Generic;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultsCollection<T> where T : ProfessionalResult
    {
        /// <summary>
        /// Список результатов скрининга
        /// </summary>
        public IList<T> Items { get; set; }

        /// <summary>
        /// Сообщения, относящиеся к конкретному виду скрининга
        /// </summary>
        /// <summary lang="en">
        /// Messages related to this screening type
        /// </summary>
        public IList<Message> Messages { get; set; }
    }
}