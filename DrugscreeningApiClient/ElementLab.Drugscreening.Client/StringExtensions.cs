using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab
{
    internal static class StringExtensions
    {
        /// <summary>
        /// √арантирует, что исходна€ строка заканчиваетс€ заданным текстом
        /// </summary>
        /// <param name="source">»сходна€ строка</param>
        /// <param name="end">“екст, которым должна заканчиватьс€ исходна€ строка</param>
        /// <returns>—трока, заканчивающа€с€ заданным текстом</returns>
        public static string EnsureEndsWith(this string source, string end)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (!source.EndsWith(end))
                source += end;
            return source;
        }

        /// <summary>
        /// √арантирует, что исходна€ строка начинаетс€ с заданного текста
        /// </summary>
        /// <param name="source">»сходна€ строка</param>
        /// <param name="start">“екст, с которого должна начинатьс€ исходна€ строка</param>
        /// <returns>—трока, начинающа€с€ с заданного текста</returns>
        public static string EnsureStartsWith(this string source, string start)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (!source.StartsWith(start))
                source = start + source;
            return source;
        }
    }
}