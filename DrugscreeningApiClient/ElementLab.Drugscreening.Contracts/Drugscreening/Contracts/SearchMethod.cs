using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Способ поиска
    /// </summary>
    /// <summary lang="en">
    /// Modes of searching for concepts.
    /// </summary>
    public enum SearchMethod
    {
        /// <summary>
        /// Нечеткий поиск по тексту
        /// </summary>
        /// <summary lang="en">
        /// Fuzzy search by input text.
        /// </summary>
        Text,
        /// <summary>
        /// Точный поиск по штрих-коду
        /// </summary>
        /// <summary lang="en">
        /// Exact search by barcode. Supported for DispensableDrug and DietarySupplement only.
        /// </summary>
        Barcode,
        /// <summary>
        /// Точный поиск по названию концепта
        /// </summary>
        /// <summary lang="en">
        /// Exact search by name.
        /// </summary>
        ExactName
    }
}
