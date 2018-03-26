using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ElementLab.Drugscreening.Client
{
    /// <summary>
    /// ������� ����� ��� ���� ������, ��������� � ����������� � API.
    /// </summary>
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public ApiException(HttpStatusCode code, string message)
            : base(message)
        {
            this.StatusCode = code;
        }
    }
}