using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Описывает общую информацию о пациенте.
    /// </summary>
    /// <summary lang="en">
    /// Contains information about patient.
    /// </summary>
    
    public class Patient
    {
        /// <summary>
        /// Дата рождения.
        /// </summary>
        /// <remarks>
        /// Значение не обязательно, но может требоваться при выполнении некоторых видов скрининга
        /// </remarks>
        /// <summary lang="en">
        /// Date of birth of the patient.
        /// </summary>
        /// <remarks lang="en">
        /// Value may be required for certain screening types.
        /// </remarks>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Ожидаемая дата рождения (не обязательно).
        /// </summary>
        /// <summary lang="en">
        /// Expected date of birth.
        /// </summary>
        public DateTime? ExpectedBirthDate { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        /// <remarks>
        /// Значение не обязательно, но может требоваться при выполнении некоторых видов скрининга
        /// </remarks>
        /// <summary lang="en">
        /// Gender of the patient.
        /// </summary>
        /// <remarks lang="en">
        /// Value may be required for certain screening types.
        /// </remarks>
        public Gender Gender { get; set; }

#if DEBUG || DEV
        /// <summary>
        /// Масса тела. Значение указывается в килограммах.
        /// </summary>
        /// <remarks>
        /// Значение не обязательно, но может требоваться при выполнении некоторых видов скрининга
        /// </remarks>
        /// <summary lang="en">
        /// Body weight of the patient, in kilograms.
        /// </summary>
        /// <remarks lang="en">
        /// Value may be required for certain screening types.
        /// </remarks>
        public decimal? Weight { get; set; }
        /// <summary>
        /// Площадь поверхности тела. Значение в квадратных метрах.
        /// </summary>
        /// <summary lang="en">
        /// Body surface area, in square meters.
        /// </summary>
        /// <remarks lang="en">
        /// Value may be required for certain screening types.
        /// </remarks>
        public decimal? BodySurfaceArea { get; set; }
        /// <summary>
        /// Клиренс креатинина.
        /// </summary>
        /// <summary lang="en">
        /// Creatinine clearance.
        /// </summary>
        /// <remarks lang="en">
        /// Value may be required for certain screening types.
        /// </remarks>
        public RenalFunction CreatinineClearance { get; set; }
        /// <summary>
        /// Сывороточный креатинин.
        /// </summary>
        /// <summary lang="en">
        /// Serum creatinine.
        /// </summary>
        /// <remarks lang="en">
        /// Value may be required for certain screening types.
        /// </remarks>
        public RenalFunction SerumCreatinine { get; set; }
        /// <summary>
        /// Диурез.
        /// </summary>
        /// <summary lang="en">
        /// Urine output.
        /// </summary>
        /// <remarks lang="en">
        /// Value may be required for certain screening types.
        /// </remarks>
        public RenalFunction UrineOutput { get; set; }
#endif
        /// <summary>
        /// Вид спорта, которым занимается пациент.
        /// </summary>
        /// <summary lang="en">
        /// Sports related to the patient.
        /// </summary>
        public PatientSport Sport { get; set; }

    }
}