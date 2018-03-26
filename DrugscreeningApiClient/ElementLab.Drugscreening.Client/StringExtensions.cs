using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab
{
    internal static class StringExtensions
    {
        /// <summary>
        /// �����������, ��� �������� ������ ������������� �������� �������
        /// </summary>
        /// <param name="source">�������� ������</param>
        /// <param name="end">�����, ������� ������ ������������� �������� ������</param>
        /// <returns>������, ��������������� �������� �������</returns>
        public static string EnsureEndsWith(this string source, string end)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (!source.EndsWith(end))
                source += end;
            return source;
        }

        /// <summary>
        /// �����������, ��� �������� ������ ���������� � ��������� ������
        /// </summary>
        /// <param name="source">�������� ������</param>
        /// <param name="start">�����, � �������� ������ ���������� �������� ������</param>
        /// <returns>������, ������������ � ��������� ������</returns>
        public static string EnsureStartsWith(this string source, string start)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (!source.StartsWith(start))
                source = start + source;
            return source;
        }
    }
}