// **********************************************************************************************\
// Module Name:  ContractExtensions.cs
// Project:      ElementLab.Drugscreening.Extensions 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using System;
using ElementLab.Drugscreening.Contracts;

namespace ElementLab.Drugscreening
{
    public static class ContractExtensions
    {
        /// <summary>
        /// Возвращает обобщенный уровень риска
        /// </summary>
        /// <param name="alert">Результат скрининга</param>
        /// <returns>Обобщенный уровень риска</returns>
        public static GenericSeverityLevel GetGenericSeverity(this Interaction alert)
        {
            switch (alert.Severity.Level)
            {
                case 10000:
                    return GenericSeverityLevel.Major;
                case 20000:
                    return GenericSeverityLevel.Moderate;
                case 30000:
                    return GenericSeverityLevel.Minor;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown Drug Interaction Severity Level: {alert.Severity.Level}");
            }
        }

        /// <summary>
        /// Возвращает обобщенный уровень риска
        /// </summary>
        /// <param name="alert">Результат скрининга</param>
        /// <returns>Обобщенный уровень риска</returns>
        public static GenericSeverityLevel GetGenericSeverity(this AllergicReaction alert)
        {
            return GenericSeverityLevel.Major;
        }

        /// <summary>
        /// Возвращает обобщенный уровень риска
        /// </summary>
        /// <param name="alert">Результат скрининга</param>
        /// <returns>Обобщенный уровень риска</returns>
        public static GenericSeverityLevel GetGenericSeverity(this Contraindication alert)
        {
            switch (alert.Severity.Level)
            {
                case 1:
                case 2:
                    return GenericSeverityLevel.Major;
                case 3:
                    return GenericSeverityLevel.Moderate;
                case 4:
                    return GenericSeverityLevel.Minor;
                case 5:
                    return GenericSeverityLevel.None;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown Contraindication Severity Level: {alert.Severity.Level}");
            }
        }

        /// <summary>
        /// Возвращает обобщенный уровень риска
        /// </summary>
        /// <param name="alert">Результат скрининга</param>
        /// <returns>Обобщенный уровень риска</returns>
        public static GenericSeverityLevel GetGenericSeverity(this DuplicateTherapy alert)
        {
            return GenericSeverityLevel.Moderate;
        }

        /// <summary>
        /// Возвращает обобщенный уровень риска для предупреждения по допингу
        /// </summary>
        /// <param name="alert">Результат скрининга</param>
        /// <returns>Обобщенный уровень риска</returns>
        public static GenericSeverityLevel GetGenericSeverity(this DopingAlert alert)
        {
            switch (alert.Severity.Level)
            {
                case 10000:
                    return GenericSeverityLevel.Major;
                case 20000:
                    return GenericSeverityLevel.Moderate;
                case 30000:
                    return GenericSeverityLevel.Minor;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown Doping Alert Severity Level: {alert.Severity.Level}");
            }
        }

        /// <summary>
        /// Возвращает обобщенный уровень риска
        /// </summary>
        /// <param name="alert">Результат скрининга</param>
        /// <returns>Обобщенный уровень риска</returns>
        public static GenericSeverityLevel GetGenericSeverity(this GeneticTest alert)
        {
            switch (alert.Severity.Level)
            {
                case 10000:
                    return GenericSeverityLevel.Major;
                case 20000:
                    return GenericSeverityLevel.Moderate;
                case 30000:
                    return GenericSeverityLevel.Minor;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown Genetic Test Severity Level: {alert.Severity.Level}");
            }
        }
    }
}
