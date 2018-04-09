// **********************************************************************************************\
// Module Name:  DuplicateTherapy.cs
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
    /// Дупликативная терапия
    /// </summary>
    /// <summary lang="en">
    /// Defines result for duplicate therapy processing.
    /// </summary>
    
    public class DuplicateTherapy : ProfessionalResult
    {
        /// <summary>
        /// Вид дупликативной терапии.
        /// </summary>
        /// <summary lang="en">
        /// Kind of this result. Possible values are:
        /// <dl>
        ///   <dt>DuplicateTherapyAtATCClass</dt>
        ///     <dd>Drugs related to same ATC class</dd>
        ///   <dt>DuplicateTherapyAtIngredient</dt>
        ///     <dd>Drugs contains same ingredient(s)</dd>
        ///   <dt>DuplicateTherapyAtClass</dt>
        ///     <dd>Drugs related to same therapy class</dd>
        /// </dl>
        /// </summary>
        
        public string Kind { get; set; }

        /// <summary>
        /// Класс АТХ, к которому относятся препараты, вызывающие дублирование. 
        /// Значение указывается для дупликативной терапии вида "DuplicateTherapyAtATCClass".
        /// </summary>
        /// <summary lang="en">
        /// ATC class related to this result if Kind is "DuplicateTherapyAtATCClass".
        /// </summary>
        public string ATCClass { get; set; }

        /// <summary>
        /// Ингредиенты, общие для лекарственных средств. Значение указывается для
        /// дупликативной терапии вида "DuplicateTherapyAtIngredient".
        /// </summary>
        /// <summary lang="en">
        /// Common drug ingredients related to this result if Kind is "DuplicateTherapyAtIngredient"
        /// </summary>
        public ICollection<string> CommonIngredients { get; set; }

        /// <summary>
        /// Класс дупликативной терапии. Значение указывается 
        /// только для дупликативной терапии вида "DuplicateTherapyAtClass".
        /// </summary>
        /// <summary lang="en">
        /// Class of ingredients that treated the same for Duplicate Therapy checking if Kind is "DuplicateTherapyAtClass".
        /// </summary>
        public Concept Class { get; set; }
    }
}