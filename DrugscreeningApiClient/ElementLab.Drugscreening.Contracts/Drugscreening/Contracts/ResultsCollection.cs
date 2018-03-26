using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultsCollection<T> where T : PatientResult
    {
        /// <summary>
        /// ������ ����������� ���������
        /// </summary>
        public IList<T> Items { get; set; }
        /// <summary>
        /// ���������, ����������� � ����������� ���� ���������
        /// </summary>
        /// <summary lang="en">
        /// Messages related to this screening type
        /// </summary>
        public IList<Message> Messages { get; set; }
    }
}