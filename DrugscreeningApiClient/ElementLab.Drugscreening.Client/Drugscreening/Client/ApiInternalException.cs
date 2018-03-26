using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ElementLab.Drugscreening.Client
{
    /// <summary>
    /// Ошибка, вызванная внутренними проблемами API.
    /// </summary>
    public class ApiInternalException : ApiException
    {
        public ApiInternalException(HttpStatusCode code, string message)
            : base(code, message)
        {
        }
    }
}