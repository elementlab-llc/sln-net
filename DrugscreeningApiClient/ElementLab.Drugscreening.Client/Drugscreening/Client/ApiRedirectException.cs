using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ElementLab.Drugscreening.Client
{
    public class ApiRedirectException : ApiException
    {
        public ApiRedirectException(HttpStatusCode status, string message)
            : base(status, message)
        {
        }
    }
}