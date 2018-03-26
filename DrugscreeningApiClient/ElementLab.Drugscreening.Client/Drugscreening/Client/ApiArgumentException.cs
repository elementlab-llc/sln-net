using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ElementLab.Drugscreening.Client
{
    /// <summary>
    /// ��������� ������, ��������� ������������� �����������, ���������� ��� ��������� � API
    /// </summary>
    public class ApiArgumentException : ApiException
    {
        public ApiArgumentException(HttpStatusCode status, string message)
            : base(status, message)
        {
        }
    }
}