// **********************************************************************************************\
// Module Name:  Allergy.cs
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
    {}
}