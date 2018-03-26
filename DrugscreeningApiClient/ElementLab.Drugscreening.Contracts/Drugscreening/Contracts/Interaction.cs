using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Описывает взаимодействие между лекарственными средствами, а также их взаимодействие с пищей и алкоголем.
    /// </summary>
    /// <summary lang="en">
    /// Used to define interaction between drugs, drug and food or alcohol
    /// </summary>
    
    public class Interaction : PatientResult
    {
        /// <summary>
        /// Текст предупреждения для пациента.
        /// </summary>
        /// <remarks>
        /// Этот текст может отсутствовать для некоторых взаимодействий.
        /// </remarks>
        /// <summary lang="en">
        /// Simplified alert for non-professional users.
        /// </summary>
        public string PatientAlert { get; set; }
        /// <summary>
        /// Текст реферата для пациента, в формате XML.
        /// </summary>
        /// <remarks>
        /// Этот текст может отсутствовать для некоторых взаимодействий.
        /// </remarks>
        /// <summary lang="en">
        /// Simplified monograph for non-professional users.
        /// </summary>
        /// <remarks lang="en">
        /// In XML format.
        /// </remarks>
        public string PatientMonograph { get; set; }
        /// <summary>
        /// Уровень риска.
        /// </summary>
        /// <summary lang="en">
        /// Severity level for this interaction.
        /// </summary>
        
        public InteractionSeverityLevel Severity { get; set; }
        /// <summary>
        /// Степень необходимого вмешательства при возникновении взаимодействия.
        /// </summary>
        /// <summary lang="en">
        /// Management level for this interaction.
        /// </summary>
        public InteractionManagementLevel Management { get; set; }
        /// <summary>
        /// Степень изученности данного взаимодействия.
        /// </summary>
        public InteractionDocumentationLevel Documentation { get; set; }
        /// <summary>
        /// Уровень противопоказания в соответствии с инструкцией.
        /// </summary>
        /// <summary lang="en">
        /// Documentation level for this interaction.
        /// </summary>
        public CodedValueWithLevel LabeledAvoidance { get; set; }
        /// <summary>
        /// Скорость возникновения взаимодействия.
        /// </summary>
        /// <summary lang="en">
        /// Onset for this interaction.
        /// </summary>
        public InteractionOnset Onset { get; set; }
    }
}