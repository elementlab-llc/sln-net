// **********************************************************************************************\
// Module Name:  DopingAlertsOptions.cs
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
    /// Дополнительные параметры скрининга анти-допинга
    /// </summary>
    /// <summary lang="en">
    /// Contains parameters for doping alerts processing fine-tuning.
    /// </summary>
    public class DopingAlertsOptions
    {
        /// <summary>
        /// true, если при скрининге не нужно учитывать указанный пол пациента
        /// </summary>
        /// <summary lang="en">
        /// true if specified patient's gender should be ignored during processing.
        /// </summary>
        public bool IgnoreGender { get; set; }

        /// <summary>
        /// true, если при скрининге не нужно учитывать указанный соревновательный период
        /// </summary>
        /// <summary lang="en">
        /// true if specified competition period should be ignored during processing.
        /// </summary>
        public bool IgnoreCompetitionPeriod { get; set; }
    }
}