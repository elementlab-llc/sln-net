// **********************************************************************************************\
// Module Name:  Immunosuppression.cs
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
    /// <inheritdoc />
    /// <summary>
    /// Предупреждение, связанное с иммуносупрессией.
    /// </summary>
    /// <summary lang="en">
    /// Defines result for the immunosuppression processing.
    /// </summary>
    public class Immunosuppression : ProfessionalResult
    {
        /// <summary>
        /// Уровень риска.
        /// </summary>
        /// <summary lang="en">
        /// Severity level for this result.
        /// </summary>
        
        public ImmunosuppressionSeverityLevel Severity { get; set; }

        /// <summary>
        /// Иммуносупрессорный эффект.
        /// </summary>
        /// <summary lang="en">
        /// Immunosuppression effect for this result.
        /// </summary>
        
        public ImmunosuppressionEffect Effect { get; set; }

        /// <summary>
        /// Ингредиент, вызывающий иммуносупрессорный эффект.
        /// </summary>
        /// <summary lang="en">
        /// Screenable ingredient that causes an immunosuppressive effect.
        /// </summary>
        public ScreenableIngredient Ingredient { get; set; }

        /// <summary>
        /// Пути введения препарата, относящиеся к этому предупреждению.
        /// </summary>
        /// <summary lang="en">
        /// Collection of routes related to this result.
        /// </summary>
        public IList<Concept> Routes { get; set; }
    }
}