using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Dtos.Auth
{
    public class AuthTokenDto
    {
        public string Token { get; set; }

        public AuthTokenDto(string token)
        {
            Token = token;
        }
    }
}
