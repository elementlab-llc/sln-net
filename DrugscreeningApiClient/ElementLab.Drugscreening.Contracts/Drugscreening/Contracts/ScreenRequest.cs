using System;
using System.Collections.Generic;
using System.Linq;

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
        const RxScreeningTypes ContraindicationScreenings = RxScreeningTypes.AgeContraindications
                                                            | RxScreeningTypes.AllergicReactions
                                                            | RxScreeningTypes.DiseaseContraindications
                                                            | RxScreeningTypes.DrugAlcoholInteractions
                                                            | RxScreeningTypes.DrugDrugInteractions
                                                            | RxScreeningTypes.DrugFoodInteractions
                                                            | RxScreeningTypes.DuplicateTherapy
                                                            | RxScreeningTypes.GenderContraindications
                                                            | RxScreeningTypes.LactationContraindications
                                                            | RxScreeningTypes.PregnancyContraindications;

        const RxScreeningTypes InteractionScreenings = RxScreeningTypes.DrugAlcoholInteractions
                                                       | RxScreeningTypes.DrugDrugInteractions
                                                       | RxScreeningTypes.DrugFoodInteractions;

        const RxScreeningTypes AllScreenings = InteractionScreenings
                                               | ContraindicationScreenings
                                               | RxScreeningTypes.AllergicReactions
                                               | RxScreeningTypes.DuplicateTherapy
                                               | RxScreeningTypes.DopingAlerts
                                               | RxScreeningTypes.GeneticTesting
#if DEBUG || DEV
                                               | RxScreeningTypes.Dosing
                                               | RxScreeningTypes.Immunosuppression
#endif
                                               ;

        RxScreeningTypes _screeningTypes = AllScreenings;
        ScreeningOptions _options;

        /// <summary>
        /// Виды скринингов, которые необходимо выполнить
        /// </summary>
        /// <summary lang="en">
        /// Screening types to execute
        /// </summary>
        public RxScreeningTypes ScreeningTypes
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
        /// Список диагнозов, поставленных пациенту.
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