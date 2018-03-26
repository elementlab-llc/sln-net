using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Концепт, описывающий аллергию, имеющуюся у пациента.
    /// Допустимые типы концептов:
    /// <ul>
    ///   <li>AllergenClass</li>
    ///   <li>ScreenableIngredient</li>
    ///   <li>DispensableDrug</li>
    ///   <li>GenericDrug</li>
    ///   <li>DrugName</li>
    ///   <li>GenericName</li>
    /// </ul>
    /// </summary>
    /// <summary lang="en">
    /// Defines a known allergy for the patient.
    /// Valid concept types are:
    /// <ul>
    ///   <li>AllergenClass</li>
    ///   <li>ScreenableIngredient</li>
    ///   <li>DispensableDrug</li>
    ///   <li>GenericDrug</li>
    ///   <li>DrugName</li>
    ///   <li>GenericName</li>
    /// </ul>
    /// </summary>
    
    public class Allergy : ScreenableConcept
    {
    }
}