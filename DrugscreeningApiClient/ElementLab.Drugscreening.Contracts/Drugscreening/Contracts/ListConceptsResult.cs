// **********************************************************************************************\
// Module Name:  ListConceptsResult.cs
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
    /// Описывает результат получения списка концептов
    /// </summary>
    public class ListConceptsResult
    {
        public int FirstItemIndex { get; }
        /// <summary>
        /// Указывает на наличие большего количества концептов
        /// </summary>
        public bool HasMoreItems { get; }

        /// <summary>
        /// Список концептов
        /// </summary>
        public IReadOnlyList<ConceptInfo> Concepts { get; }

        /// <summary>
        /// Инициализирует объект коллекции концептов
        /// </summary>
        /// <param name="source">Исходный список</param>
        /// <param name="firstItemIndex">Индекс первого запрошенного концепта</param>
        /// <param name="hasMoreItems">Признак наличия большего количества концептов</param>
        public ListConceptsResult(IReadOnlyList<ConceptInfo> source, int firstItemIndex, bool hasMoreItems)
        {
            Concepts = source;
            FirstItemIndex = firstItemIndex;
            HasMoreItems = hasMoreItems;
        }
    }
}