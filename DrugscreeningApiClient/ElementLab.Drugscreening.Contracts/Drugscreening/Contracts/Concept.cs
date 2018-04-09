// **********************************************************************************************\
// Module Name:  Concept.cs
// Project:      ElementLab.Drugscreening.Contracts 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using System;
using System.Diagnostics;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Базовый тип, предоставляющий информацию, общую для всех концептов, имеющихся в системе.
    /// </summary>
    /// <summary lang="en">
    /// Base type for all concepts.
    /// </summary>
    [DebuggerDisplay("{Type} - {Name} ({Code})")]
    
    public class Concept
    {
        /// <summary>
        /// Тип концепта.
        /// </summary>
        /// <summary lang="en">
        /// Type of this concept.
        /// </summary>
        
        public string Type { get; set; }

        /// <summary>
        /// Код, идентифицирующий концепт.
        /// </summary>
        /// <example>Например, для лекарственных средств идентификатором является уникальное целое число. 
        /// Для диагнозов из справочника МКБ-10 идентификатором является код, указанный в справочнике.</example>
        /// <summary lang="en">
        /// Unique code within a given type of concept.
        /// </summary>
        
        public string Code { get; set; }

        /// <summary>
        /// Наименование концепта.
        /// </summary>
        /// <summary lang="en">
        /// Name of this concept.
        /// </summary>
        
        public string Name { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (!(obj is Concept otherConcept))
                return false;

            return string.Equals(Code, otherConcept.Code, StringComparison.OrdinalIgnoreCase)
                   && string.Equals(Type, otherConcept.Type, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        // ReSharper disable NonReadonlyMemberInGetHashCode
        public override int GetHashCode()
        {
            return (Type + "/" + Code).GetHashCode();
        }
        // ReSharper restore NonReadonlyMemberInGetHashCode
    }
}