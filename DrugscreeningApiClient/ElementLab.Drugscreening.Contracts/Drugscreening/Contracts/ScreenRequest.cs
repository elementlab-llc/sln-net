// **********************************************************************************************\
// Module Name:  ScreenRequest.cs
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
    /// Данные запроса на выполнение скрининга
    /// </summary>
    /// <summary lang="en">
    /// Contains data for screening
    /// </summary>

    public class ScreenRequest
    {
        const ScreeningType ContraindicationScreenings = ScreeningType.AgeContraindications
                                                         | ScreeningType.DiseaseContraindications
                                                         | ScreeningType.GenderContraindications
                                                         | ScreeningType.LactationContraindications
                                                         | ScreeningType.PregnancyContraindications;

        const ScreeningType InteractionScreenings = ScreeningType.DrugAlcoholInteractions
                                                       | ScreeningType.DrugDrugInteractions
                                                       | ScreeningType.DrugFoodInteractions;

        const ScreeningType AllScreenings = InteractionScreenings
                                               | ContraindicationScreenings
                                               | ScreeningType.AllergicReactions
                                               | ScreeningType.DuplicateTherapy
                                               | ScreeningType.DopingAlerts
                                               | ScreeningType.GeneticTesting;

        ScreeningOptions _options;

        ScreeningType _screeningTypes = AllScreenings;

        /// <summary>
        /// Виды скринингов, которые необходимо выполнить
        /// </summary>
        /// <summary lang="en">
        /// Screening types to execute
        /// </summary>
        public ScreeningType ScreeningTypes
        {
            get => _screeningTypes;
            set => _screeningTypes = value == 0 ? AllScreenings : value;
        }

        /// <summary>
        /// Общая информация о пациенте.
        /// </summary>
        /// <summary lang="en">
        /// Information about patient
        /// </summary>
        public Patient Patient { get; set; }

        /// <summary>
        /// Перечень назначенных лекарственных средств
        /// </summary>
        /// <summary lang="en">
        /// List of prescribed drugs
        /// </summary>
        public List<Drug> Drugs { get; set; }

        /// <summary>
        /// Перечень известных аллергий, имеющихся у пациента.
        /// </summary>
        /// <summary lang="en">
        /// List of known allergies for this patient
        /// </summary>
        public List<Allergy> Allergies { get; set; }

        /// <summary>
        /// Список заболеваний, имеющихся у пациента.
        /// </summary>
        /// <summary lang="en">
        /// List of diseases for this patient
        /// </summary>
        public List<Disease> Diseases { get; set; }

        /// <summary>
        /// Параметры для более тонкой настройки процесса выполнения скрининга.
        /// </summary>
        /// <summary lang="en">
        /// Options for fine-tuning screening processes
        /// </summary>
        public ScreeningOptions Options
        {
            get => _options ?? (_options = new ScreeningOptions());
            set => _options = value;
        }
    }
}