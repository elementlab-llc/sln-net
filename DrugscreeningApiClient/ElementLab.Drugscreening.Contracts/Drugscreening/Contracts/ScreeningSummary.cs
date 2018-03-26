using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Содержит все результаты, полученные при выполнении запрошенных видов скрининга.
    /// </summary>
    /// <summary lang="en">
    /// Contains all results for screening processing.
    /// </summary>
    
    public class ScreeningSummary
    {
        /// <summary>
        /// Уникальный идентификатор результата скрининга
        /// </summary>
        /// <summary lang="en">
        /// Globally unique identifier of the results.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Список сообщений, относящихся ко всем выполненным видам скрининга.
        /// </summary>
        /// <summary lang="en">
        /// Messages related to all of the processed screenings.
        /// </summary>
        public Message[] Messages { get; set; }
        /// <summary>
        /// Обнаруженные взаимодействия между лекарственными средствами.
        /// </summary>
        /// <summary lang="en">
        /// Interactions between input drugs.
        /// </summary>
        public ResultsCollection<Interaction> DrugDrugInteractions { get; set; }
        /// <summary>
        /// Обнаруженные взаимодействия между лекарственными средствами и пищей.
        /// </summary>
        /// <summary lang="en">
        /// Interactions between input drugs and food.
        /// </summary>
        public ResultsCollection<Interaction> DrugFoodInteractions { get; set; }
        /// <summary>
        /// Обнаруженные взаимодействия между лекарственными средствами и алкоголем.
        /// </summary>
        /// <summary lang="en">
        /// Interactions between input drugs and alcohol.
        /// </summary>
        public ResultsCollection<Interaction> DrugAlcoholInteractions { get; set; }
        /// <summary>
        /// Обнаруженные аллергические реакции.
        /// </summary>
        /// <summary lang="en">
        /// Allergic reactions.
        /// </summary>
        public ResultsCollection<AllergicReaction> AllergicReactions { get; set; }
        /// <summary>
        /// Обнаруженные противопоказания по возрастным характеристикам.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between input drugs and patient's age
        /// </summary>
        public ResultsCollection<AgeContraindication> AgeContraindications { get; set; }
        /// <summary>
        /// Обнаруженные противопоказания по половой принадлежности.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between input drugs and patient's gender.
        /// </summary>
        public ResultsCollection<GenderContraindication> GenderContraindications { get; set; }
        /// <summary>
        /// Обнаруженные противопоказания при лактации.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between input drugs and lactation.
        /// </summary>
        public ResultsCollection<LactationContraindication> LactationContraindications { get; set; }
        /// <summary>
        /// Обнаруженные противопоказания при беременности.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between input drugs and pregnancy.
        /// </summary>
        public ResultsCollection<PregnancyContraindication> PregnancyContraindications { get; set; }
        /// <summary>
        /// Обнаруженные противопоказания к диагнозам.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between input drugs and diseases.
        /// </summary>
        public ResultsCollection<DiseaseContraindication> DiseaseContraindications { get; set; }
        /// <summary>
        /// Обнаруженные дублирования терапии.
        /// </summary>
        /// <summary lang="en">
        /// Duplicate therapies.
        /// </summary>
        public ResultsCollection<DuplicateTherapy> DuplicateTherapies { get; set; }
        /// <summary>
        /// Обнаруженные предупреждения, связанные с допинг-контролем.
        /// </summary>
        /// <summary lang="en">
        /// Doping alerts.
        /// </summary>
        public ResultsCollection<DopingAlert> DopingAlerts { get; set; }
        /// <summary>
        /// Обнаруженные предупреждения о необходимости фармакогенетического тестирования.
        /// </summary>
        /// <summary lang="en">
        /// Pharmacogenetic testing recommendations.
        /// </summary>
        public ResultsCollection<GeneticTest> GeneticTests { get; set; }
    }
}