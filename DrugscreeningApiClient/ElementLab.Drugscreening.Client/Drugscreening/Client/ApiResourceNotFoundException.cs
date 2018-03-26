using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ElementLab.Drugscreening.Client
{
    /// <summary>
    /// Ошибка, возникающая при отсутствии запрошенного ресурса.
    /// </summary>
    public class ApiResourceNotFoundException : ApiException
    {
        public ApiResourceNotFoundException(HttpStatusCode status, string message)
            : base(status, message)
        {
        }
    }
}