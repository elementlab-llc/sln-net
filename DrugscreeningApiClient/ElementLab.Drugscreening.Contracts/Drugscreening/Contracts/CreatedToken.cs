

using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <summary lang="en">
    /// </summary>
    public class CreatedToken
    {
        /// <summary>
        /// ������������� ������������ API (�����)
        /// </summary>
        /// <summary lang="en">
        /// API client identifier (login)
        /// </summary>
        
        public string ClientId { get; set; }
        /// <summary>
        /// ����� ��� ������� � API
        /// </summary>
        /// <summary lang="en">
        /// API access token
        /// </summary>
        
        public string Token { get; set; }
    }
}