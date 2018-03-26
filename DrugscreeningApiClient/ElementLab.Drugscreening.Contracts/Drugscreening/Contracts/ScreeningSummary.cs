using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// �������� ��� ����������, ���������� ��� ���������� ����������� ����� ���������.
    /// </summary>
    /// <summary lang="en">
    /// Contains all results for screening processing.
    /// </summary>
    
    public class ScreeningSummary
    {
        /// <summary>
        /// ���������� ������������� ���������� ���������
        /// </summary>
        /// <summary lang="en">
        /// Globally unique identifier of the results.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// ������ ���������, ����������� �� ���� ����������� ����� ���������.
        /// </summary>
        /// <summary lang="en">
        /// Messages related to all of the processed screenings.
        /// </summary>
        public Message[] Messages { get; set; }
        /// <summary>
        /// ������������ �������������� ����� �������������� ����������.
        /// </summary>
        /// <summary lang="en">
        /// Interactions between input drugs.
        /// </summary>
        public ResultsCollection<Interaction> DrugDrugInteractions { get; set; }
        /// <summary>
        /// ������������ �������������� ����� �������������� ���������� � �����.
        /// </summary>
        /// <summary lang="en">
        /// Interactions between input drugs and food.
        /// </summary>
        public ResultsCollection<Interaction> DrugFoodInteractions { get; set; }
        /// <summary>
        /// ������������ �������������� ����� �������������� ���������� � ���������.
        /// </summary>
        /// <summary lang="en">
        /// Interactions between input drugs and alcohol.
        /// </summary>
        public ResultsCollection<Interaction> DrugAlcoholInteractions { get; set; }
        /// <summary>
        /// ������������ ������������� �������.
        /// </summary>
        /// <summary lang="en">
        /// Allergic reactions.
        /// </summary>
        public ResultsCollection<AllergicReaction> AllergicReactions { get; set; }
        /// <summary>
        /// ������������ ���������������� �� ���������� ���������������.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between input drugs and patient's age
        /// </summary>
        public ResultsCollection<AgeContraindication> AgeContraindications { get; set; }
        /// <summary>
        /// ������������ ���������������� �� ������� ��������������.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between input drugs and patient's gender.
        /// </summary>
        public ResultsCollection<GenderContraindication> GenderContraindications { get; set; }
        /// <summary>
        /// ������������ ���������������� ��� ��������.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between input drugs and lactation.
        /// </summary>
        public ResultsCollection<LactationContraindication> LactationContraindications { get; set; }
        /// <summary>
        /// ������������ ���������������� ��� ������������.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between input drugs and pregnancy.
        /// </summary>
        public ResultsCollection<PregnancyContraindication> PregnancyContraindications { get; set; }
        /// <summary>
        /// ������������ ���������������� � ���������.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between input drugs and diseases.
        /// </summary>
        public ResultsCollection<DiseaseContraindication> DiseaseContraindications { get; set; }
        /// <summary>
        /// ������������ ������������ �������.
        /// </summary>
        /// <summary lang="en">
        /// Duplicate therapies.
        /// </summary>
        public ResultsCollection<DuplicateTherapy> DuplicateTherapies { get; set; }
        /// <summary>
        /// ������������ ��������������, ��������� � ������-���������.
        /// </summary>
        /// <summary lang="en">
        /// Doping alerts.
        /// </summary>
        public ResultsCollection<DopingAlert> DopingAlerts { get; set; }
        /// <summary>
        /// ������������ �������������� � ������������� �������������������� ������������.
        /// </summary>
        /// <summary lang="en">
        /// Pharmacogenetic testing recommendations.
        /// </summary>
        public ResultsCollection<GeneticTest> GeneticTests { get; set; }
    }
}