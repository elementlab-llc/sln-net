// **********************************************************************************************\
// Module Name:  Interaction.cs
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
    /// Описывает взаимодействие между лекарственными средствами, а также их взаимодействие с пищей и алкоголем.
    /// </summary>
    /// <summary lang="en">
    /// Used to define interaction between drugs, drug and food or alcohol
    /// </summary>
    
    public class Interaction : PatientResult
    {
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