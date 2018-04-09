// **********************************************************************************************\
// Module Name:  SearchScope.cs
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
    /// Область поиска
    /// </summary>
    /// <summary lang="en">
    /// Defines the scope for searching for concepts
    /// </summary>
    public enum SearchScope
    {
        /// <summary>
        /// Лекарственные средства
        /// </summary>
        /// <summary lang="en">
        /// Medicine drugs
        /// </summary>
        Drugs,
        /// <summary>
        /// Лекарственные средства и субстанции
        /// </summary>
        /// <summary lang="en">
        /// Medicine drugs and substances
        /// </summary>
        DrugsAndSubstances,
        /// <summary>
        /// Аллергены (лекарственные средства, классы аллергенов и ингредиенты)
        /// </summary>
        /// <summary lang="en">
        /// Allergens (medicine drugs, allergen classes and ingredients)
        /// </summary>
        Allergens,
        /// <summary>
        /// Диагнозы в соответствии со справочником МКБ-10
        /// </summary>
        /// <summary lang="en">
        /// Diseases in accordance with ICD-10
        /// </summary>
        Diseases,
        /// <summary>
        /// Состояния пациента
        /// </summary>
        /// <summary lang="en">
        /// Patient conditions
        /// </summary>
        Conditions,
        /// <summary>
        /// Виды спорта
        /// </summary>
        /// <summary lang="en">
        /// Kinds of sports
        /// </summary>
        Sports,
        /// <summary>
        /// Лекарственные средства, субстанции и БАДы
        /// </summary>
        /// <summary lang="en">
        /// Medicine drugs, substances and dietary supplements
        /// </summary>
        DrugsSubstancesAndDietarySupplements
    }
}