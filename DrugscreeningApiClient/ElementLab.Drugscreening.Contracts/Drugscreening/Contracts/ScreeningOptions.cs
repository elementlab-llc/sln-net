using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// ��������� ��� ������ ��������� ���������
    /// </summary>
    /// <summary lang="en">
    /// Defines parameters for screening fine-tuning.
    /// </summary>
    
    public class ScreeningOptions
    {
        DopingAlertsOptions _dopingAlerts;

        /// <summary>
        /// ������� ������������� ����� ��������������� ����������� � ������� ������������� ������� ��� ���������� ���������.
        /// </summary>
        /// <remarks>
        /// �������������� ��������. �� ��������� true
        /// </remarks>
        /// <summary lang="en">
        /// TRUE if insignificant inactive ingredients should be taken into account during allergic reactions processing.
        /// </summary>
        /// <remarks lang="en">
        /// Optional. Default is TRUE.
        /// </remarks>
        public bool IncludeInsignificantInactiveIngredients { get; set; } = true;

        /// <summary>
        /// true, ���� ���������� �������� ������ ��������� � ��������� ���������.
        /// </summary>
        /// <remarks>
        /// �������������� ��������. �� ��������� true
        /// </remarks>
        /// <summary lang="en">
        /// TRUE if monograph texts should be included in results.
        /// </summary>
        /// <remarks lang="en">
        /// Optional. Default is TRUE.
        /// </remarks>
        public bool IncludeMonographs { get; set; } = true;

        /// <summary>
        /// �������������� ��������� ��������� ����-�������
        /// </summary>
        /// <summary lang="en">
        /// Additional parameters for doping alerts processing.
        /// </summary>
        /// <remarks lang="en">
        /// Optional.
        /// </remarks>
        public DopingAlertsOptions DopingAlerts
        {
            get => _dopingAlerts ?? (_dopingAlerts = new DopingAlertsOptions());
            set => _dopingAlerts = value;
        }
    }
}