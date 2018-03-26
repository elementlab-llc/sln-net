using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ElementLab.Drugscreening.Client
{
    /// <summary>
    /// ��������� ������, ��������� � �������������
    /// </summary>
    public class ApiSecurityException : ApiException
    {
        public ApiSecurityException(HttpStatusCode status, string message)
            : base(status, message)
        {
        }
    }
}