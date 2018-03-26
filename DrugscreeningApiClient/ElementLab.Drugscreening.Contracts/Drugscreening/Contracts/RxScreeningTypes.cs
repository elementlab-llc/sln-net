using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Перечисляет все возможные виды скрининга.
    /// </summary>
    /// <summary lang="en">
    /// Types of the screenings.
    /// </summary>
    [Flags]
    
    public enum RxScreeningTypes
    {
        /// <summary>
        /// Скрининг взаимодействий лекарственных средств друг с другом.
        /// </summary>
        /// <summary lang="en">
        /// Interactions between drugs.
        /// </summary>
        DrugDrugInteractions = 1,
        /// <summary>
        /// Скрининг взаимодействий лекарственных средств с пищей.
        /// </summary>
        /// <summary lang="en">
        /// Interactions between drugs and food.
        /// </summary>
        DrugFoodInteractions = 2,
        /// <summary>
        /// Скрининг взаимодействий лекарственных средств с алкоголем.
        /// </summary>
        /// <summary lang="en">
        /// Interactions between drugs and alcohol.
        /// </summary>
        DrugAlcoholInteractions = 4,
        /// <summary>
        /// Скрининг возможных аллергических реакций.
        /// </summary>
        /// <summary lang="en">
        /// Allergic reactions.
        /// </summary>
        AllergicReactions = 8,
        /// <summary>
        /// Скрининг на наличие дупликативной терапии.
        /// </summary>
        /// <summary lang="en">
        /// Duplicate therapy.
        /// </summary>
        DuplicateTherapy = 16,
        /// <summary>
        /// Скрининг противопоказаний по возрастным характеристикам.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between drugs and age.
        /// </summary>
        AgeContraindications = 32,
        /// <summary>
        /// Скрининг противопоказаний по половой принадлежности.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between drugs and gender.
        /// </summary>
        GenderContraindications = 64,
        /// <summary>
        /// Скрининг противопоказаний при  лактации.
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between drugs and lactation.
        /// </summary>
        LactationContraindications = 128,
        /// <summary>
        /// Скрининг противопоказаний при беременности
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between drugs and pregnancy.
        /// </summary>
        PregnancyContraindications = 256,
        /// <summary>
        /// Скрининг противопоказаний при диагнозе
        /// </summary>
        /// <summary lang="en">
        /// Contraindications between drugs and diseases.
        /// </summary>
        DiseaseContraindications = 512,
        /// <summary>
        /// Допинг-контроль
        /// </summary>
        /// <summary lang="en">
        /// Doping alerts for drugs.
        /// </summary>
        DopingAlerts = 1024,
        /// <summary>
        /// Фармакогенетический скрининг
        /// </summary>
        /// <summary lang="en">
        /// Pharmacogenetic testing recommendations for drugs.
        /// </summary>
        GeneticTesting = 2048,
        /// <summary>
        /// Дозирование (предварительная ознакомительная версия, не используйте)
        /// </summary>
        /// <summary lang="en">
        /// Dosing alerts for drugs (early preview version, do not use)
        /// </summary>
        Dosing = 4096,
        /// <summary>
        /// Иммуносупрессия (в разработке, не используйте)
        /// </summary>
        Immunosuppression = 8192
#if DEV || DEBUG
#endif
    }
}
