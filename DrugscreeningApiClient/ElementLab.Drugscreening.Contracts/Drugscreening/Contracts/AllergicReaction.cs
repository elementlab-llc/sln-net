﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Описание аллергической реакции
    /// </summary>
    /// <summary lang="en">
    /// Describes possible allergic reaction for input drug, substance or dietary supplement
    /// </summary>
    
    public class AllergicReaction : PatientResult
    {
        /// <summary>
        /// Вид аллергической реакции. Возможны следующие значения:
        /// AllergicReactionAtClass - реакция из-за отношения аллергена и препарата к одному классу аллергенов;
        /// AllergicReactionAtIngredient - реакция, связанная с тем, что назначаемый препарат содержит ингредиент, на который у пациента имеется аллегия.
        /// AllergicReactionAtComponent - реакция из-за наличия в препарате компонентов, на которые у пациента имеется аллергия.
        /// </summary>
        /// <summary lang="en">
        /// <para>Kind of allergic reaction:</para>
        /// <dl>
        ///   <dt>AllergicReactionAtClass</dt>
        ///     <dd>Allergic reaction based on AllergenClass</dd>
        ///   <dt>AllergicReactionAtIngredient</dt>
        ///     <dd>Allergic reaction based on common specific Ingredient</dd>
        ///   <dt>AllergicReactionAtComponent</dt>
        ///     <dd>Allergic reaction based on common components</dd>
        /// </dl>
        /// </summary>
        public string Kind { get; set; }
        /// <summary>
        /// Список аллергий (аллергенов), из-за которых возможно возникновение аллергической реакции.
        /// </summary>
        /// <summary lang="en">
        /// List of input allergens, which may cause this allergic reaction
        /// </summary>
        public IList<Allergy> Allergies { get; set; }
        /// <summary>
        /// Класс аллергенов, с которым связана аллергическая реакция. 
        /// </summary>
        /// <summary lang="en">
        /// Class of allergens, related to this allergic reaction
        /// </summary>
        public Concept AllergenClass { get; set; }
        /// <summary>
        /// Ингредиент, с которым связана эта аллергическая реакция.
        /// </summary>
        /// <summary lang="en">
        /// Ingredient, related to this allergic reaction
        /// </summary>
        public Concept Ingredient { get; set; }
        /// <summary>
        /// Список компонентов, с которыми связана эта аллергическая реакция.
        /// </summary>
        /// <summary lang="en">
        /// List of component names, related to this allergic reaction
        /// </summary>
        public IList<string> Components { get; set; }
    }
}