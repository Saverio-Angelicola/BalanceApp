using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Exceptions
{
    public class UnauthorizedAuthenticationException : Exception
    {
        public UnauthorizedAuthenticationException(string username) : base($"Unauthorized Account Access {username}") { }
    }
}
